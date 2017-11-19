namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IShieldStateEntry : IJournalEntry
    {
        bool ShieldsUp { get; set; }
    }

    partial class JournalEntry : IShieldStateEntry
    {
        public bool ShieldsUp { get; set; }
    }
}
