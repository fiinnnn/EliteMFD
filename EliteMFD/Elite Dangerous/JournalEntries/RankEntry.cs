using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class RankEntry : JournalEntry
    {
        #region parameters
        public int Combat { get; set; }
        public int Trade { get; set; }
        public int Explore { get; set; }
        public int Empire { get; set; }
        public int Federation { get; set; }
        public int CQC { get; set; }
        #endregion

        public RankEntry(JObject entry) : base(entry)
        {
            Combat = entry.Value<int>("Combat");
            Trade = entry.Value<int>("Trade");
            Explore = entry.Value<int>("Explore");
            Empire = entry.Value<int>("Empire");
            Federation = entry.Value<int>("Federation");
            CQC = entry.Value<int>("CQC");
        }
    }
}
