using System;

namespace EliteMFD.EDSM
{
    interface IEDSMStatus
    {
        DateTime lastUpdate { get; set; }
        string type { get; set; }
        string message { get; set; }
        int status { get; set; }
    }

    class EDSMStatus : IEDSMStatus
    {
        public DateTime lastUpdate { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public int status { get; set; }
    }
}
