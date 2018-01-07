namespace EliteMFD.EliteDangerous
{
    static class RankExtensions
    {
        public static string Name(this CombatRank rank)
        {
            switch (rank)
            {
                case CombatRank.Harmless:
                    return "Harmless";
                case CombatRank.MostlyHarmless:
                    return "Mostly Harmless";
                case CombatRank.Novice:
                    return "Novice";
                case CombatRank.Competent:
                    return "Competent";
                case CombatRank.Expert:
                    return "Expert";
                case CombatRank.Master:
                    return "Master";
                case CombatRank.Dangerous:
                    return "Dangerous";
                case CombatRank.Deadly:
                    return "Deadly";
                case CombatRank.Elite:
                    return "Elite";
                default:
                    return "Unknown";
            }
        }

        public static string Name(this TradeRank rank)
        {
            switch (rank)
            {
                case TradeRank.Penniless:
                    return "Penniless";
                case TradeRank.MostlyPenniless:
                    return "Mostly Penniless";
                case TradeRank.Peddler:
                    return "Peddler";
                case TradeRank.Dealer:
                    return "Dealer";
                case TradeRank.Merchant:
                    return "Merchant";
                case TradeRank.Broker:
                    return "Broker";
                case TradeRank.Entrepreneur:
                    return "Entrepreneur";
                case TradeRank.Tycoon:
                    return "Tycoon";
                case TradeRank.Elite:
                    return "Elite";
                default:
                    return "Unknown";
            }
        }

        public static string Name(this ExplorationRank rank)
        {
            switch (rank)
            {
                case ExplorationRank.Aimless:
                    return "Aimless";
                case ExplorationRank.MostlyAimless:
                    return "Mostly Aimless";
                case ExplorationRank.Scout:
                    return "Scout";
                case ExplorationRank.Surveyor:
                    return "Surveyor";
                case ExplorationRank.Trailblazer:
                    return "Trailblazer";
                case ExplorationRank.Pathfinder:
                    return "Pathfinder";
                case ExplorationRank.Ranger:
                    return "Ranger";
                case ExplorationRank.Pioneer:
                    return "Pioneer";
                case ExplorationRank.Elite:
                    return "Elite";
                default:
                    return "Unknown";
            }
        }

        public static string Name(this FederationRank rank)
        {
            switch (rank)
            {
                case FederationRank.None:
                    return "None";
                case FederationRank.Recruit:
                    return "Recruit";
                case FederationRank.Cadet:
                    return "Cadet";
                case FederationRank.Midshipman:
                    return "Midshipman";
                case FederationRank.PettyOfficer:
                    return "Petty Officer";
                case FederationRank.ChiefPettyOfficer:
                    return "Chief Petty Officer";
                case FederationRank.WarrantOfficer:
                    return "Warrant Officer";
                case FederationRank.Ensign:
                    return "Ensign";
                case FederationRank.Lieutenant:
                    return "Lieutenant";
                case FederationRank.LieutenantCommander:
                    return "Lt. Commander";
                case FederationRank.PostCommander:
                    return "Post Commander";
                case FederationRank.PostCaptain:
                    return "Post Captain";
                case FederationRank.RearAdmiral:
                    return "Rear Admiral";
                case FederationRank.ViceAdmiral:
                    return "Vice Admiral";
                case FederationRank.Admiral:
                    return "Admiral";
                default:
                    return "Unknown";
            }
        }

        public static string Name(this EmpireRank rank)
        {
            switch (rank)
            {
                case EmpireRank.None:
                    return "None";
                case EmpireRank.Outsider:
                    return "Outsider";
                case EmpireRank.Serf:
                    return "Serf";
                case EmpireRank.Master:
                    return "Master";
                case EmpireRank.Squire:
                    return "Squire";
                case EmpireRank.Knight:
                    return "Knight";
                case EmpireRank.Lord:
                    return "Lord";
                case EmpireRank.Baron:
                    return "Baron";
                case EmpireRank.Viscount:
                    return "Viscount";
                case EmpireRank.Count:
                    return "Count";
                case EmpireRank.Earl:
                    return "Earl";
                case EmpireRank.Marquis:
                    return "Marquis";
                case EmpireRank.Duke:
                    return "Duke";
                case EmpireRank.Prince:
                    return "Prince";
                case EmpireRank.King:
                    return "King";
                default:
                    return "Unknown";
            }
        }

        public static string Name(this CqcRank rank)
        {
            switch (rank)
            {
                case CqcRank.Helpless:
                    return "Helpless";
                case CqcRank.MostlyHelpless:
                    return "Mostly Helpless";
                case CqcRank.Amateur:
                    return "Amateur";
                case CqcRank.SemiProfessional:
                    return "Semi Professional";
                case CqcRank.Professional:
                    return "Professional";
                case CqcRank.Champion:
                    return "Champion";
                case CqcRank.Hero:
                    return "Hero";
                case CqcRank.Legend:
                    return "Legend";
                case CqcRank.Elite:
                    return "Elite";
                default:
                    return "Unknown";
            }
        }
    }
}
