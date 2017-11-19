namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface ILaunchFighterEntry : IJournalEntry
    {
        bool PlayerControlled { get; set; }
    }

    partial class JournalEntry : ILaunchFighterEntry
    {
        public bool PlayerControlled { get; set; }
    }
}
