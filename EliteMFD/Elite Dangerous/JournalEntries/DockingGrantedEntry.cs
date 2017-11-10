using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class DockingGrantedEntry : StationInfo
    {
        #region parameters
        public int LandingPad { get; set; }
        #endregion

        public DockingGrantedEntry(JObject entry) : base(entry)
        {
            LandingPad = entry.Value<int>("LandingPad");
        }
    }
}
