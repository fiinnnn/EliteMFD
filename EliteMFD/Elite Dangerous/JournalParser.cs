using System;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace EliteMFD.EliteDangerous
{
    class JournalParser
    {
        public JournalParser()
        {
        }

        public JournalEntry ParseLine(string line)
        {
            JObject entry = JObject.Parse(line);

            switch (entry.Value<string>("event"))
            {
                default:
                    return new JournalEntry(entry);

                case "LoadGame":
                    return new LoadGameEntry(entry);

                case "FSDJump":
                    return new FSDJumpEntry(entry);

                case "FuelScoop":
                    return new FuelScoopEntry(entry);
            }
        }
    }
}
