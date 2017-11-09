using Vector3D;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class LocationEntry : SystemInfo
    {
        #region parameters
        public bool Docked { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        #endregion

        public LocationEntry(JObject entry) : base(entry)
        {
            Docked = entry.Value<bool?>("Docked") ?? false;
            if (Docked)
            {
                StationName = entry.Value<string>("StationName");
                StationType = entry.Value<string>("StationType");
            }
        }
    }
}
