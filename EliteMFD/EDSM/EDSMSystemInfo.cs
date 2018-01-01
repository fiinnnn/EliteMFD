using System.Windows.Media.Media3D;

namespace EliteMFD.EDSM
{
    interface IEDSMSystemInfo
    {
        string name { get; set; }
        Point3D coords { get; set; }
        bool coordsLocked { get; set; }
    }

    class EDSMSystemInfo : IEDSMSystemInfo
    {
        public string name { get; set; }
        public Point3D coords { get; set; }
        public bool coordsLocked { get; set; }
    }
}
