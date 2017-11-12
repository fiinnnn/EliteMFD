using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class DockingDeniedEntry : StationInfo
    {
        #region parameters
        public string Reason { get; set; }
        #endregion

        public DockingDeniedEntry(JObject entry) : base(entry)
        {
            Reason = entry.Value<string>("Reason");
        }
    }
}
