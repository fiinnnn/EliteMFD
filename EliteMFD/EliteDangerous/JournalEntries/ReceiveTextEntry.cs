using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class ReceiveTextEntry : JournalEntry
    {
        #region parameters
        public string From { get; set; }
        public string Message { get; set; }
        public string Channel { get; set; }
        #endregion

        public ReceiveTextEntry(JObject entry) : base(entry)
        {
            From = entry.Value<string>("From");
            Message = entry.Value<string>("Message");
            Channel = entry.Value<string>("Channel");
        }
    }
}