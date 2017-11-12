using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class MiningRefinedEntry : JournalEntry
    {
        #region parameters
        public string Type { get; set; }
        #endregion

        public MiningRefinedEntry(JObject entry) : base(entry)
        {
            Type = entry.Value<string>("Type");
        }
    }
}