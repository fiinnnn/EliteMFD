using System;
using System.ComponentModel;
using EliteMFD.EliteDangerous;
using Vector3D;

namespace EliteMFD
{
    public class EliteMFDInfo
    {
        public event EventHandler PropertiesUpdated;

        #region public properties
        public string Fuel { get; set; }
        public string Distance { get; set; }
        public string ExplorationRank { get; set; }
        #endregion

        #region private properties
        private double FuelLevel { get; set; }
        private double FuelCapacity { get; set; }
        private Rank RankExplore { get; set; } = new Rank("Exploration", 0);
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
            if (entry.Event == "FSDJump")
            {
                FSDJumpEntry jumpInfo = (FSDJumpEntry)entry;
                FuelLevel = jumpInfo.FuelLevel;
                CurrentPosition = jumpInfo.StarPos;
            }
            else if (entry.Event == "FuelScoop")
            {
                FuelScoopEntry scoopInfo = (FuelScoopEntry)entry;
                FuelLevel = scoopInfo.Total;
            }
            else if (entry.Event == "LoadGame")
            {
                LoadGameEntry loadGameInfo = (LoadGameEntry)entry;
                FuelLevel = loadGameInfo.FuelLevel;
                FuelCapacity = loadGameInfo.FuelCapacity;
            }
            else if (entry.Event == "Location")
            {
                LocationEntry locationInfo = (LocationEntry)entry;
                CurrentPosition = locationInfo.StarPos;
            }
            else if (entry.Event == "Promotion")
            {
                PromotionEntry promotionInfo = (PromotionEntry)entry;
                if (promotionInfo.RankName == "Explore")
                {
                    RankExplore = new Rank("Exploration", promotionInfo.NewRank);
                }
            }
            else if (entry.Event == "Rank")
            {
                RankEntry rankInfo = (RankEntry)entry;
                RankExplore = new Rank("Exploration", rankInfo.Explore);
            }
            else if (entry.Event == "RefuelAll" || entry.Event == "RefuelPartial")
            {
                RefuelEntry refuelInfo = (RefuelEntry)entry;
                FuelLevel += refuelInfo.Amount;
            }

            UpdateProperties();
        }

        /// <summary>
        /// Update the public properties using the updated information
        /// </summary>
        private void UpdateProperties()
        {
            Fuel = "Fuel:" + Math.Round(FuelLevel, 1).ToString() + "/" + Math.Round(FuelCapacity, 1).ToString() + "t";
            Distance = "Dist:" + Math.Round(CalcDistance(CurrentPosition, DestinationPosition), 2) + "ly";
            ExplorationRank = "Exp:" + RankExplore.Name;
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
