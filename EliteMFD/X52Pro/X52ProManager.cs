using System;
using System.Collections.Generic;
using DirectOutputCSharpWrapper;

namespace EliteMFD.X52Pro
{
    class X52ProManager
    {
        private readonly List<IntPtr> attachedDevices;

        private readonly Dictionary<int, string[]> pages;
        public int ActivePage { get; private set; }

        private readonly DirectOutput directOutput;

        protected readonly DirectOutput.PageCallback changeActivePageCallback;
        protected readonly DirectOutput.DeviceCallback deviceChangeCallback;

        /// <summary>
        /// Creates a new X52ProManager and finds all currently connected devices
        /// </summary>
        /// <param name="appName">App name for the DirectOutput library</param>
        public X52ProManager(string appName)
        {
            directOutput = new DirectOutput();
            directOutput.Initialize(appName);

            attachedDevices = FindDevices();
            pages = new Dictionary<int, string[]>();

            changeActivePageCallback = ChangeActivePage;
            deviceChangeCallback = DeviceChange;

            directOutput.RegisterDeviceCallback(deviceChangeCallback);

            foreach (IntPtr device in attachedDevices)
            {
                directOutput.RegisterPageCallback(device, changeActivePageCallback);
            }
        }

        /// <summary>
        /// Gets called on page change and changes the active page
        /// </summary>
        private void ChangeActivePage(IntPtr device, int page, bool activated, IntPtr target)
        {
            if (activated)
            {
                ActivePage = page;
                UpdateDisplay();
            }
        }

        /// <summary>
        /// Gets called when a device is connected/disconnected
        /// </summary>
        private void DeviceChange(IntPtr device, bool added, IntPtr target)
        {
            if (added && !attachedDevices.Contains(device))
            {
                attachedDevices.Add(device);
                directOutput.RegisterPageCallback(device, changeActivePageCallback);
                foreach (var page in pages)
                {
                    var active = page.Key == ActivePage ? DirectOutput.IsActive : 0;
                    directOutput.AddPage(device, page.Key, active);
                }

                UpdateDisplay();
            }
            else if (attachedDevices.Contains(device))
                attachedDevices.Remove(device);
        }

        /// <summary>
        /// Find all currently connected devices
        /// </summary>
        public List<IntPtr> FindDevices()
        {
            List<IntPtr> devices = new List<IntPtr>();
            directOutput.Enumerate((device, _) => {
                devices.Add(device);
            });
            return devices;
        }

        /// <summary>
        /// Cleans up the DirectOutput library and removes all connected devices from the X52ProManager
        /// </summary>
        public void Deinitialize()
        {
            directOutput.Deinitialize();
            attachedDevices.Clear();
        }

        /// <summary>
        /// Add a page to all connected devices
        /// </summary>
        /// <param name="pageNum">Number of the page to be added</param>
        /// <param name="makeActive">If set to true the page will be made active after adding</param>
        public void AddPage(int pageNum, bool makeActive = false)
        {
            if (pages.ContainsKey(pageNum)) return;

            var active = makeActive ? DirectOutput.IsActive : 0;

            pages.Add(pageNum, new string[3]);

            foreach (var device in attachedDevices)
            {
                directOutput.AddPage(device, pageNum, active);
            }

            if (makeActive) UpdateDisplay();
        }

        /// <summary>
        /// Removes a page from all connected devices
        /// </summary>
        /// <param name="pageNum">Page to be removed</param>
        public void RemovePage(int pageNum)
        {
            if (!pages.ContainsKey(pageNum)) return;

            foreach (var device in attachedDevices)
            {
                directOutput.RemovePage(device, pageNum);
                pages.Remove(pageNum);
            }
        }

        /// <summary>
        /// Adds a string to the specified page on all connected devices
        /// </summary>
        /// <param name="page">Page to contain the string</param>
        /// <param name="index">String index, refer to DirectOutput documentation</param>
        /// <param name="msg">The message to print</param>
        public void SetString(int page, int index, string msg)
        {
            string[] pageStrings = pages[page];
            pageStrings[index] = msg;

            UpdateDisplay();
        }

        /// <summary>
        /// Displays the active page
        /// </summary>
        private void UpdateDisplay()
        {
            string[] pageStrings = pages[ActivePage];

            foreach (var device in attachedDevices)
            {
                for (int i = 0; i < 3; i++)
                    if (pageStrings[i] != null) directOutput.SetString(device, ActivePage, i, pageStrings[i]);
            }
        }
    }
}
