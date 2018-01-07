namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IDockedEntry : IStationInfo
    {
        bool CockpitBreach { get; set; }
    }

    partial class JournalEntry : IDockedEntry
    {
        public bool CockpitBreach { get; set; }
    }
}
