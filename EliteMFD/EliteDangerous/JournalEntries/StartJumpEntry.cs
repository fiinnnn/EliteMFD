namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IStartJumpEntry : IJournalEntry
    {
        string JumpType { get; set; }
    }

    partial class JournalEntry : IStartJumpEntry
    {
        public string JumpType { get; set; }
    }
}
