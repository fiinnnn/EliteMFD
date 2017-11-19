namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IUSSDropEntry : IJournalEntry
    {
        string USSType { get; set; }
        int USSThreat { get; set; }
    }

    partial class JournalEntry : IUSSDropEntry
    {
        public string USSType { get; set; }
        public int USSThreat { get; set; }
    }
}
