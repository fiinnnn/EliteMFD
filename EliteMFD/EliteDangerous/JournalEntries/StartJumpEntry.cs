using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class StartJumpEntry : JournalEntry
    {
        #region parameters
        public string JumpType { get; set; }
        #endregion

        public StartJumpEntry(JObject entry) : base(entry)
        {
            JumpType = entry.Value<string>("JumpType");
        }
    }
}