using System;
using System.Globalization;
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
            Timestamp = DateTime.ParseExact(entry.Value<string>("timestamp"), "G", CultureInfo.InvariantCulture);
            Event = entry.Value<string>("event");
        }
    }
}
