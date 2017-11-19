using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous.JournalEntries
{
    interface IMiningRefinedEntry : IJournalEntry
    {
        string Type { get; set; }
    }

    partial class JournalEntry : IMiningRefinedEntry
    {
        public string Type { get; set; }
    }
}
