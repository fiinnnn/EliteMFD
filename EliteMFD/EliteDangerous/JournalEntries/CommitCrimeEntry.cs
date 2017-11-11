using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class CommitCrimeEntry : JournalEntry
    {
        #region parameters
        public string CrimeType { get; set; }
        public long? Fine { get; set; }
        public long? Bounty { get; set; }
        #endregion

        public CommitCrimeEntry(JObject entry) : base(entry)
        {
            CrimeType = entry.Value<string>("CrimeType");
            Fine = entry.Value<long?>("Fine");
            Bounty = entry.Value<long?>("Bounty");
        }
    }
}
