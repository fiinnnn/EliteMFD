using System;
using System.Collections.Generic;
using DirectOutputCSharpWrapper;

namespace EliteMFD.X52Pro
{
    class X52ProManager
    {
        private List<X52Pro> attachedDevices;
        private DirectOutput directOutput;

        public X52ProManager(string appName)
        {
            directOutput = new DirectOutput();
            directOutput.Initialize(appName);
        }

        public void FindDevices()
        {
            directOutput.Enumerate((IntPtr device, IntPtr context) => { attachedDevices.Add(new X52Pro(device)); });
        }
    }
}
