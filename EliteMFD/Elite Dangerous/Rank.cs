namespace EliteMFD.EliteDangerous
{
    class Rank
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public Rank(string type, int rank)
        {
            Type = type;
            Name = GetRankName(rank);
        }

        /// <summary>
        /// Converts the rank number to the name depending on Type
        /// </summary>
        /// <param name="rank">Rank number</param>
        /// <returns>Rank Name</returns>
        private string GetRankName(int rank)
        {
            if (Type == "Combat")
            {
                switch (rank)
                {
                    default:
                        return "Harmless";
                    case 1:
                        return "Mostly Harmless";
                    case 2:
                        return "Novice";
                    case 3:
                        return "Competent";
                    case 4:
                        return "Expert";
                    case 5:
                        return "Master";
                    case 6:
                        return "Dangerous";
                    case 7:
                        return "Deadly";
                    case 8:
                        return "Elite";
                }
            }
            else if (Type == "Trade")
            {
                switch (rank)
                {
                    default:
                        return "Penniless";
                    case 1:
                        return "Mostly Penniless";
                    case 2:
                        return "Peddler";
                    case 3:
                        return "Dealer";
                    case 4:
                        return "Merchant";
                    case 5:
                        return "Broker";
                    case 6:
                        return "Entrepreneur";
                    case 7:
                        return "Tycoon";
                    case 8:
                        return "Elite";
                }
            }
            else if (Type == "Exploration")
            {
                switch (rank)
                {
                    default:
                        return "Aimless";
                    case 1:
                        return "Mostly Aimless";
                    case 2:
                        return "Scout";
                    case 3:
                        return "Surveyor";
                    case 4:
                        return "Explorer";
                    case 5:
                        return "Pathfinder";
                    case 6:
                        return "Ranger";
                    case 7:
                        return "Pioneer";
                    case 8:
                        return "Elite";
                }
            }
            else if (Type == "Federation")
            {
                switch (rank)
                {
                    default:
                        return "None";
                    case 1:
                        return "Recruit";
                    case 2:
                        return "Cadet";
                    case 3:
                        return "Midshipman";
                    case 4:
                        return "Petty Officer";
                    case 5:
                        return "Chief Petty Officer";
                    case 6:
                        return "Warrant Officer";
                    case 7:
                        return "Ensign";
                    case 8:
                        return "Lieutenant";
                    case 9:
                        return "Lt. Commander";
                    case 10:
                        return "Post Commander";
                    case 11:
                        return "Post Captain";
                    case 12:
                        return "Rear Admiral";
                    case 13:
                        return "Vice Admiral";
                    case 14:
                        return "Admiral";
                }
            }
            else if (Type == "Empire")
            {
                switch (rank)
                {
                    default:
                        return "None";
                    case 1:
                        return "Outsider";
                    case 2:
                        return "Serf";
                    case 3:
                        return "Master";
                    case 4:
                        return "Squire";
                    case 5:
                        return "Knight";
                    case 6:
                        return "Lord";
                    case 7:
                        return "Baron";
                    case 8:
                        return "Viscount";
                    case 9:
                        return "Count";
                    case 10:
                        return "Earl";
                    case 11:
                        return "Marquis";
                    case 12:
                        return "Duke";
                    case 13:
                        return "Prince";
                    case 14:
                        return "King";
                }
            }
            else if (Type == "CQC")
            {
                switch (rank)
                {
                    default:
                        return "Helpless";
                    case 1:
                        return "Mostly Helpless";
                    case 2:
                        return "Amateur";
                    case 3:
                        return "Semi Professional";
                    case 4:
                        return "Professional";
                    case 5:
                        return "Champion";
                    case 6:
                        return "Hero";
                    case 7:
                        return "Legend";
                    case 8:
                        return "Elite";
                }
            }

            return "Unknown"; //something has really gone wrong if this happens
        }
    }
}
