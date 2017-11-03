using System;

namespace EliteMFD.X52Pro
{
    class X52Pro
    {
        private IntPtr device;

        public IntPtr Device
        {
            get { return device; }
        }

        public X52Pro(IntPtr device)
        {
            this.device = device;
        }
    }
}
