using System;
using System.Collections.Generic;
using DirectOutputCSharpWrapper;

namespace EliteMFD.X52Pro
{
    class X52ProManager
    {
        private readonly List<IntPtr> attachedDevices;

        private readonly List<int> pages;
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
            attachedDevices = new List<IntPtr>();
            pages = new List<int>();
            directOutput.Initialize(appName);
            FindDevices();

            changeActivePageCallback = ChangeActivePage;
            deviceChangeCallback = DeviceChange;

            directOutput.RegisterDeviceChangeCallback(deviceChangeCallback);

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
                ActivePage = page;
        }

        /// <summary>
        /// Gets called when a device is connected/disconnected
        /// </summary>
        private void DeviceChange(IntPtr device, bool added, IntPtr target)
        {
            if (added && !attachedDevices.Contains(device))
            {
                attachedDevices.Add(device);
                foreach (var page in pages)
                {
                    var active = page == ActivePage ? DirectOutput.IsActive : 0;
                    directOutput.AddPage(device, page, active);
                }
            }
            else if (attachedDevices.Contains(device))
                attachedDevices.Remove(device);
        }

        /// <summary>
        /// Find all currently connected devices
        /// </summary>
        public void FindDevices()
        {
            attachedDevices.Clear(); //clear list before adding all connected devices
            directOutput.Enumerate((device, _) => {
                attachedDevices.Add(device);
            });
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
            if (pages.Contains(pageNum)) return;

            var active = makeActive ? DirectOutput.IsActive : 0;

            pages.Add(pageNum);

            foreach (var device in attachedDevices)
            {
                directOutput.AddPage(device, pageNum, active);
            }
        }

        /// <summary>
        /// Removes a page from all connected devices
        /// </summary>
        /// <param name="pageNum">Page to be removed</param>
        public void RemovePage(int pageNum)
        {
            if (!pages.Contains(pageNum)) return;

            foreach (var device in attachedDevices)
            {
                directOutput.RemovePage(device, pageNum);
                pages.Remove(pageNum);
            }
        }

        /// <summary>
        /// Prints a string on all connected devices
        /// </summary>
        /// <param name="index">String index, refer to DirectOutput documentation</param>
        /// <param name="msg">The message to print</param>
        public void SetString(int index, string msg)
        {
            foreach (var device in attachedDevices)
            {
                if (msg != null) directOutput.SetString(device, ActivePage, index, msg);
            }
        }
    }
}
