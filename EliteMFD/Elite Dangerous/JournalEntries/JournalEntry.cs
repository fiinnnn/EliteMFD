using System;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class JournalEntry
    {
        #region parameters
        public DateTime Timestamp { get; set; }
        public string Event { get; set; }
        #endregion

        public JournalEntry(JObject entry)
        {
            Timestamp = DateTime.Parse(entry.Value<string>("timestamp"));
            Event = entry.Value<string>("event");
        }
    }
}
