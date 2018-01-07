using System;
using System.Collections.Generic;
using DirectOutputCSharpWrapper;

namespace EliteMFD.X52Pro
{
    class X52ProManager
    {
        private readonly List<IntPtr> _attachedDevices;

        private readonly Dictionary<int, string[]> _pages;
        private readonly List<int> _activePage;

        private readonly DirectOutput _directOutput;

        private readonly DirectOutput.PageCallback _changeActivePageCallback;
        private readonly DirectOutput.DeviceCallback _deviceChangeCallback;

        /// <summary>
        /// Creates a new X52ProManager and finds all currently connected devices
        /// </summary>
        /// <param name="appName">App name for the DirectOutput library</param>
        public X52ProManager(string appName)
        {
            _directOutput = new DirectOutput();
            _directOutput.Initialize(appName);

            _attachedDevices = FindDevices();
            _pages = new Dictionary<int, string[]>();

            _activePage = new List<int>();

            _changeActivePageCallback = ChangeActivePage;
            _deviceChangeCallback = DeviceChange;

            _directOutput.RegisterDeviceChangeCallback(_deviceChangeCallback);

            foreach (var device in _attachedDevices)
            {
                _directOutput.RegisterPageCallback(device, _changeActivePageCallback);
            }
        }

        /// <summary>
        /// Gets called on page change and changes the active page
        /// </summary>
        private void ChangeActivePage(IntPtr device, int page, bool activated, IntPtr target)
        {
            if (activated)
            {
                _activePage.Add(page);
                UpdateDisplay();
            }
            else
            {
                _activePage.Remove(page);
            }
        }

        /// <summary>
        /// Gets called when a device is connected/disconnected
        /// </summary>
        private void DeviceChange(IntPtr device, bool added, IntPtr target)
        {
            if (added && !_attachedDevices.Contains(device))
            {
                _attachedDevices.Add(device);
                _directOutput.RegisterPageCallback(device, _changeActivePageCallback);
                foreach (var page in _pages)
                {
                    var active = _activePage.Contains(page.Key) ? DirectOutput.IsActive : 0;
                    _directOutput.AddPage(device, page.Key, active);
                }

                UpdateDisplay();
            }
            else if (_attachedDevices.Contains(device))
                _attachedDevices.Remove(device);
        }

        /// <summary>
        /// Cleans up the DirectOutput library and removes all connected devices from the X52ProManager
        /// </summary>
        public void Deinitialize()
        {
            _directOutput.Deinitialize();
            _attachedDevices.Clear();
        }

        /// <summary>
        /// Add a page to all connected devices
        /// </summary>
        /// <param name="pageNum">Number of the page to be added</param>
        /// <param name="makeActive">If set to true the page will be made active after adding</param>
        public void AddPage(int pageNum, bool makeActive = false)
        {
            if (_pages.ContainsKey(pageNum)) return;

            var active = makeActive ? DirectOutput.IsActive : 0;

            _pages.Add(pageNum, new string[3]);

            foreach (var device in _attachedDevices)
            {
                _directOutput.AddPage(device, pageNum, active);
            }

            if (!makeActive) return;
            _activePage.Clear();
            _activePage.Add(pageNum);
            UpdateDisplay();
        }

        /// <summary>
        /// Removes a page from all connected devices
        /// </summary>
        /// <param name="pageNum">Page to be removed</param>
        public void RemovePage(int pageNum)
        {
            if (!_pages.ContainsKey(pageNum)) return;

            foreach (var device in _attachedDevices)
            {
                _directOutput.RemovePage(device, pageNum);
                _pages.Remove(pageNum);
            }

            if (_activePage.Contains(pageNum))
                _activePage.Remove(pageNum);
        }

        /// <summary>
        /// Adds a string to the specified page on all connected devices
        /// </summary>
        /// <param name="page">Page to contain the string</param>
        /// <param name="index">String index, refer to DirectOutput documentation</param>
        /// <param name="msg">The message to print</param>
        public void SetString(int page, int index, string msg)
        {
            if (!_pages.ContainsKey(page)) return;

            var pageStrings = _pages[page];
            pageStrings[index] = msg;

            UpdateDisplay();
        }

        /// <summary>
        /// Find all currently connected devices
        /// </summary>
        private List<IntPtr> FindDevices()
        {
            var devices = new List<IntPtr>();
            _directOutput.Enumerate((device, _) => {
                devices.Add(device);
            });
            return devices;
        }

        /// <summary>
        /// Displays the active page
        /// </summary>
        private void UpdateDisplay()
        {
            if (_activePage.Count != 1) return;

            var pageStrings = _pages[_activePage[0]];

            foreach (var device in _attachedDevices)
            {
                for (var i = 0; i < 3; i++)
                    if (pageStrings[i] != null) _directOutput.SetString(device, _activePage[0], i, pageStrings[i]);
            }
        }
    }
}
