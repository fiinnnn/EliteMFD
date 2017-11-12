using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class StationInfo : JournalEntry
    {
        #region parameters
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public string StationFaction { get; set; }
        public string StationAllegiance { get; set; }
        public string StationEconomy { get; set; }
        public string StationGovernment { get; set; }
        public double? DistFromStarLS { get; set; }
        #endregion

        public StationInfo(JObject entry) : base(entry)
        {
            StationName = entry.Value<string>("StationName");
            StationType = entry.Value<string>("StationType");
            StarSystem = entry.Value<string>("StarSystem");
            StationFaction = entry.Value<string>("StationFaction");
            StationAllegiance = entry.Value<string>("StationAllegiance");
            StationEconomy = entry.Value<string>("StationEconomy_Localised");
            StationGovernment = entry.Value<string>("StationGovernment_Localised");
            DistFromStarLS = entry.Value<double?>("DistFromStarLS");
        }
    }
}