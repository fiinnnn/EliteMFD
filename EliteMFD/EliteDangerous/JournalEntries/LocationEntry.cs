namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface ILocationEntry : ISystemInfo
    {
        bool Docked { get; set; }
        string StationName { get; set; }
        string StationType { get; set; }
    }

    partial class JournalEntry : ILocationEntry
    {
        public bool Docked { get; set; }
    }
}
