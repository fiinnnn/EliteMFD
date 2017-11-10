using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class JetConeBoostEntry : JournalEntry
    {
        #region parameters
        public double BoostValue { get; set; }
        #endregion

        public JetConeBoostEntry(JObject entry) : base(entry)
        {
            BoostValue = entry.Value<double>("BoostValue");
        }
    }
}
