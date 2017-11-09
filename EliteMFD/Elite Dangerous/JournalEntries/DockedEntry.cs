using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class DockedEntry : StationInfo
    {
        #region parameters
        public bool CockpitBreach { get; set; }
        #endregion

        public DockedEntry(JObject entry) : base(entry)
        {
            CockpitBreach = entry.Value<bool>("CockpitBreach");
        }
    }
}
