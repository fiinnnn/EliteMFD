namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IRefuelEntry : IJournalEntry
    {
        long Cost { get; set; }
        double Amount { get; set; }
    }

    partial class JournalEntry : IRefuelEntry
    {
        public long Cost { get; set; }
        public double Amount { get; set; }
    }
}
