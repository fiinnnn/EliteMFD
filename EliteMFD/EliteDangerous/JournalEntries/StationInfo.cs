namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IStationInfo
    {
        string StationName { get; set; }
        string StationType { get; set; }
        string StarSystem { get; set; }
        string StationFaction { get; set; }
        string StationAllegiance { get; set; }
        string StationEconomy { get; set; }
        string StationGovernment { get; set; }
        double? DistFromStarLS { get; set; }
    }

    partial class JournalEntry
    {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public string StationFaction { get; set; }
        public string StationAllegiance { get; set; }
        public string StationEconomy { get; set; }
        public string StationGovernment { get; set; }
        public double? DistFromStarLS { get; set; }
    }
}