using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class BountyEntry : JournalEntry
    {
        #region parameters
        public long TotalReward { get; set; }
        #endregion

        public BountyEntry(JObject entry) : base(entry)
        {
            TotalReward = entry.Value<long>("TotalReward");
        }
    }
}
