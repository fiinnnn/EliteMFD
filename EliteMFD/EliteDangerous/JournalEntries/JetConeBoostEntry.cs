namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IJetConeBoostEntry : IJournalEntry
    {
        double BoostValue { get; set; }
    }

    partial class JournalEntry : IJetConeBoostEntry
    {
        public double BoostValue { get; set; }
    }
}
