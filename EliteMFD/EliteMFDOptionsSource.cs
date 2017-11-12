using System.Collections.Generic;

namespace EliteMFD
{
    internal static class EliteMFDOptionsSource
    {
        public static IEnumerable<string> Options => options;

        private static readonly string[] options =
        {
            "Commander name",
            "Ship name",
            "Ship ID",
            "Current location",
            "Distance from Sol",
            "Fuel level",
            "Assigned landing pad",
            "Last refined material",
            "Shield state",
            "Combat rank",
            "Trade rank",
            "Exploration rank",
            "Federation rank",
            "Empire rank",
            "CQC rank"
        };
    }
}
