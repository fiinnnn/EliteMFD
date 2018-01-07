namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IBountyEntry : IJournalEntry
    {
        long TotalReward { get; set; }
    }

    partial class JournalEntry : IBountyEntry
    {
        public long TotalReward { get; set; }
    }
}
