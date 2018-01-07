namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IReceiveTextEntry : IJournalEntry
    {
        string From { get; set; }
        string Message { get; set; }
        string Channel { get; set; }
    }

    partial class JournalEntry : IReceiveTextEntry
    {
        public string From { get; set; }
        public string Message { get; set; }
        public string Channel { get; set; }
    }
}
