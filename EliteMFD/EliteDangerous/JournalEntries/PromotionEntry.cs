using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class PromotionEntry : JournalEntry
    {
        #region parameters
        public string RankName { get; set; }
        public int NewRank { get; set; }
        #endregion

        public PromotionEntry(JObject entry) : base(entry)
        {
            int? combatRank = entry.Value<int?>("Combat");
            if (combatRank.HasValue)
            {
                RankName = "Combat";
                NewRank = combatRank.GetValueOrDefault();
            }

            int? tradeRank = entry.Value<int?>("Trade");
            if (tradeRank.HasValue)
            {
                RankName = "Trade";
                NewRank = tradeRank.GetValueOrDefault();
            }

            int? exploreRank = entry.Value<int?>("Explore");
            if (exploreRank.HasValue)
            {
                RankName = "Explore";
                NewRank = exploreRank.GetValueOrDefault();
            }

            int? cqcRank = entry.Value<int?>("CQC");
            if (cqcRank.HasValue)
            {
                RankName = "CQC";
                NewRank = cqcRank.GetValueOrDefault();
            }

            int? federationRank = entry.Value<int?>("Federation");
            if (federationRank.HasValue)
            {
                RankName = "Federation";
                NewRank = federationRank.GetValueOrDefault();
            }
            int? empireRank = entry.Value<int?>("Empire");
            if (empireRank.HasValue)
            {
                RankName = "Empire";
                NewRank = empireRank.GetValueOrDefault();
            }
        }
    }
}