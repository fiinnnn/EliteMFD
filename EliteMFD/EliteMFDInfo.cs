using System;
using EliteMFD.EliteDangerous;
using Vector3D;

namespace EliteMFD
{
    public class EliteMFDInfo
    {
        public event EventHandler PropertiesUpdated;

        #region public properties
        public string CommanderName { get; private set; }
        public string ShipName { get; private set; }
        public string ShipId { get; private set; }
        public string SysName { get; private set; }

        public string Fuel { get; private set; }
        public string Distance { get; private set; }
        public string LandingPad { get; private set; }
        public string LastRefined { get; private set; }
        public string ShieldStatus { get; private set; }

        public string CombatRank { get; private set; }
        public string TradeRank { get; private set; }
        public string ExplorationRank { get; private set; }
        public string FederationRank { get; private set; }
        public string EmpireRank { get; private set; }
        public string CQCRank { get; private set; }
        #endregion

        #region private properties
        private double FuelLevel { get; set; }
        private double FuelCapacity { get; set; }
        private int PadNumber { get; set; }
        private string Refined { get; set; }
        private bool Shields { get; set; } = true;
        private Rank RankCombat { get; set; } = new Rank("Combat", 0);
        private Rank RankTrade { get; set; } = new Rank("Trade", 0);
        private Rank RankExplore { get; set; } = new Rank("Exploration", 0);
        private Rank RankFederation { get; set; } = new Rank("Federation", 0);
        private Rank RankEmpire { get; set; } = new Rank("Empire", 0);
        private Rank RankCQC { get; set; } = new Rank("CQC", 0);
        private Vector CurrentPosition { get; set; } = new Vector(0, 0, 0);
        private Vector DestinationPosition { get; set; } = new Vector(0, 0, 0);
        #endregion

        private Journal journal;

        public EliteMFDInfo()
        {
            journal = new Journal(ParseEntry);
        }

        /// <summary>
        /// Get info from entry and update properties accordingly
        /// </summary>
        /// <param name="entry"></param>
        private void ParseEntry(JournalEntry entry)
        {
            if (entry.Event == "DockingGranted")
            {
                DockingGrantedEntry dockInfo = (DockingGrantedEntry)entry;
                PadNumber = dockInfo.LandingPad;
            }
            else if (entry.Event == "DockingTimeout" || entry.Event == "DockingCancelled" || entry.Event == "Docked")
            {
                PadNumber = 0;
            }
            else if (entry.Event == "FSDJump")
            {
                FSDJumpEntry jumpInfo = (FSDJumpEntry)entry;
                SysName = jumpInfo.StarSystem;
                CurrentPosition = jumpInfo.StarPos;
                FuelLevel = jumpInfo.FuelLevel;
            }
            else if (entry.Event == "FuelScoop")
            {
                FuelScoopEntry scoopInfo = (FuelScoopEntry)entry;
                FuelLevel = scoopInfo.Total;
            }
            else if (entry.Event == "LoadGame")
            {
                LoadGameEntry loadGameInfo = (LoadGameEntry)entry;
                CommanderName = "CMDR " + loadGameInfo.Commander;
                ShipName = loadGameInfo.ShipName;
                ShipId = loadGameInfo.ShipIdent;
                FuelLevel = loadGameInfo.FuelLevel;
                FuelCapacity = loadGameInfo.FuelCapacity;
            }
            else if (entry.Event == "Location")
            {
                LocationEntry locationInfo = (LocationEntry)entry;
                SysName = locationInfo.StarSystem;
                CurrentPosition = locationInfo.StarPos;
            }
            else if (entry.Event == "MiningRefined")
            {
                MiningRefinedEntry refinedInfo = (MiningRefinedEntry)entry;
                Refined = refinedInfo.Type;
            }
            else if (entry.Event == "Promotion")
            {
                PromotionEntry promotionInfo = (PromotionEntry)entry;
                switch (promotionInfo.RankName)
                {
                    case "Combat":
                        RankCombat = new Rank("Combat", promotionInfo.NewRank);
                        break;
                    case "Trade":
                        RankTrade = new Rank("Trade", promotionInfo.NewRank);
                        break;
                    case "Explore":
                        RankExplore = new Rank("Exploration", promotionInfo.NewRank);
                        break;
                    case "Federation":
                        RankFederation = new Rank("Federation", promotionInfo.NewRank);
                        break;
                    case "Empire":
                        RankEmpire = new Rank("Empire", promotionInfo.NewRank);
                        break;
                    case "CQC":
                        RankCQC = new Rank("CQC", promotionInfo.NewRank);
                        break;
                }
            }
            else if (entry.Event == "Rank")
            {
                RankEntry rankInfo = (RankEntry)entry;
                RankCombat = new Rank("Combat", rankInfo.Combat);
                RankTrade = new Rank("Trade", rankInfo.Trade);
                RankExplore = new Rank("Exploration", rankInfo.Explore);
                RankFederation = new Rank("Federation", rankInfo.Federation);
                RankEmpire = new Rank("Empire", rankInfo.Empire);
                RankCQC = new Rank("CQC", rankInfo.CQC);
            }
            else if (entry.Event == "RefuelAll" || entry.Event == "RefuelPartial")
            {
                RefuelEntry refuelInfo = (RefuelEntry)entry;
                FuelLevel += refuelInfo.Amount;
            }
            else if (entry.Event == "ShieldState")
            {
                ShieldStateEntry shieldInfo = (ShieldStateEntry)entry;
                Shields = shieldInfo.ShieldsUp;
            }

            UpdateProperties();
        }

        /// <summary>
        /// Update the public properties using the updated information
        /// </summary>
        private void UpdateProperties()
        {
            Fuel = "Fuel:" + Math.Round(FuelLevel, 1).ToString() + "/" + Math.Round(FuelCapacity, 1).ToString() + "t";
            LandingPad = "Pad:" + (PadNumber > 0 ? PadNumber.ToString() : "");
            LastRefined = "Refined:" + Refined;
            ShieldStatus = "Shields:" + (Shields ? "Up" : "Down");
            Distance = "Dist:" + Math.Round(CalcDistance(CurrentPosition, DestinationPosition), 2) + "ly";
            CombatRank = "Cbt:" + RankCombat.Name;
            TradeRank = "Trd:" + RankTrade.Name;
            ExplorationRank = "Exp:" + RankExplore.Name;
            FederationRank = "Fed:" + RankFederation.Name;
            EmpireRank = "Emp:" + RankEmpire.Name;
            CQCRank = "CQC:" + RankCQC.Name;

            PropertiesUpdated(this, EventArgs.Empty);
        }

        #region utility methods
 
        /// <summary>
        /// Gets the distance between two coordinates
        /// </summary>
        /// <param name="pos1">Coordinates of position 1</param>
        /// <param name="pos2">Coordinates of position 2</param>
        /// <returns>Distance</returns>
        private double CalcDistance(Vector pos1, Vector pos2)
        {
            double dx = Math.Abs(pos1.X - pos2.X);
            double dy = Math.Abs(pos1.Y - pos2.Y);
            double dz = Math.Abs(pos1.Z - pos2.Z);
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2) + Math.Pow(dz, 2));
        }
        #endregion
    }
}
