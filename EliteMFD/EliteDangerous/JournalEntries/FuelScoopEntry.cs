namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IFuelScoopEntry : IJournalEntry
    {
        double Scooped { get; set; }
        double Total { get; set; }
    }

    partial class JournalEntry : IFuelScoopEntry
    {
        public double Scooped { get; set; }
        public double Total { get; set; }
    }
}
