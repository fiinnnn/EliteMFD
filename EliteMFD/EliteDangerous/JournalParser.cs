using EliteMFD.EliteDangerous.JournalEntries;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EliteMFD.EliteDangerous
{
    class JournalParser
    {
        public static JournalEntry ParseLine(string line)
        {
            return JsonConvert.DeserializeObject<JournalEntry>(line);
        }
    }
}
