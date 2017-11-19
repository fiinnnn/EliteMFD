namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface ICommitCrimeEntry : IJournalEntry
    {
        string CrimeType { get; set; }
        long? Fine { get; set; }
        long? Bounty { get; set; }
    }

    partial class JournalEntry : ICommitCrimeEntry
    {
        public string CrimeType { get; set; }
        public long? Fine { get; set; }
        public long? Bounty { get; set; }
    }
}
