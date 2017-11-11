using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class ShieldStateEntry : JournalEntry
    {
        #region parameters
        public bool ShieldsUp { get; set; }
        #endregion

        public ShieldStateEntry(JObject entry) : base(entry)
        {
            ShieldsUp = entry.Value<bool>("ShieldsUp");
        }
    }
}