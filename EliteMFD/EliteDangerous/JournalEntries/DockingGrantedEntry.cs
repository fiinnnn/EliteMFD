namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IDockingGrantedEntry : IStationInfo
    {
        int LandingPad { get; set; }
    }

    partial class JournalEntry : IDockingGrantedEntry
    {
        public int LandingPad { get; set; }
    }
}
