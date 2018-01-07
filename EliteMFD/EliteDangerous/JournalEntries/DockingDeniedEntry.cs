namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IDockingDeniedEntry : IStationInfo
    {
        string Reason { get; set; }
    }

    partial class JournalEntry : IDockingDeniedEntry
    {
        public string Reason { get; set; }
    }
}
