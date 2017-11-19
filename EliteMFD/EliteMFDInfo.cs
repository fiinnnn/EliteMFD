using System;
using EliteMFD.EliteDangerous;
using EliteMFD.EliteDangerous.JournalEntries;
using Vector3D;

namespace EliteMFD
{
    public class EliteMFDInfo
    {
        #region public properties
        public string CommanderName { get; private set; }
        public string ShipName { get; private set; }
        public string ShipId { get; private set; }
        public string SysName { get; private set; }

        public string Fuel => $"Fuel:{Math.Round(_fuelLevel, 1)}/{Math.Round(_fuelCapacity, 1)}t";
        public string Distance => "Dist:" + Math.Round(CalcDistance(_currentPosition, _destinationPosition), 2) + "ly";
        public string LandingPad => "Pad:" + (_padNumber > 0 ? _padNumber.ToString() : "");
        public string LastRefined => "Refined:" + _refined;
        public string ShieldStatus => "Shields:" + (_shields ? "Up" : "Down");

        public string CombatRank => "Cbt:" + _combatRank.Name();
        public string TradeRank => "Trd:" + _tradeRank.Name();
        public string ExplorationRank => "Exp:"  + _explorationRank.Name();
        public string FederationRank => "Fed:" + _federationRank.Name();
        public string EmpireRank => "Emp:" + _empireRank.Name();
        public string CqcRank => "CQC:" + _cqcRank.Name();
        #endregion

        #region private properties

        private double _fuelLevel;
        private double _fuelCapacity;
        private int _padNumber;
        private string _refined;
        private bool _shields = true;

        private Vector _currentPosition = new Vector(0, 0, 0);
        private readonly Vector _destinationPosition = new Vector(0, 0, 0);

        private CombatRank _combatRank = EliteDangerous.CombatRank.Harmless;
        private TradeRank _tradeRank = EliteDangerous.TradeRank.Penniless;
        private ExplorationRank _explorationRank = EliteDangerous.ExplorationRank.Aimless;
        private FederationRank _federationRank = EliteDangerous.FederationRank.None;
        private EmpireRank _empireRank = EliteDangerous.EmpireRank.None;
        private CqcRank _cqcRank = EliteDangerous.CqcRank.Helpless;
        #endregion

        private Journal journal;

        private readonly Action _propertyChangedCallback;

        public EliteMFDInfo(Action propertyChangedCallback)
        {
            this._propertyChangedCallback = propertyChangedCallback;

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
                _padNumber = entry.LandingPad;
            }
            else if (entry.Event == "DockingTimeout" || entry.Event == "DockingCancelled" || entry.Event == "Docked")
            {
                _padNumber = 0;
            }
            else if (entry.Event == "FSDJump")
            {
                SysName = entry.StarSystem;
                _currentPosition = entry.StarPos;
                _fuelLevel = entry.FuelLevel;
            }
            else if (entry.Event == "FuelScoop")
            {
                _fuelLevel = entry.Total;
            }
            else if (entry.Event == "LoadGame")
            {
                CommanderName = "CMDR " + entry.Commander;
                ShipName = entry.ShipName;
                ShipId = entry.ShipIdent;
                _fuelLevel = entry.FuelLevel;
                _fuelCapacity = entry.FuelCapacity;
            }
            else if (entry.Event == "Location")
            {
                SysName = entry.StarSystem;
                _currentPosition = entry.StarPos;
            }
            else if (entry.Event == "MiningRefined")
            {
                _refined = entry.Type;
            }
            else if (entry.Event == "Rank" || entry.Event == "Promotion")
            {
                if (entry.Combat != null) _combatRank = (CombatRank) entry.Combat;
                if (entry.Trade != null) _tradeRank = (TradeRank) entry.Trade;
                if (entry.Explore != null) _explorationRank = (ExplorationRank) entry.Explore;
                if (entry.Federation != null) _federationRank = (FederationRank) entry.Federation;
                if (entry.Empire != null) _empireRank = (EmpireRank) entry.Empire;
                if (entry.CQC != null) _cqcRank = (CqcRank) entry.CQC;
            }
            else if (entry.Event == "RefuelAll" || entry.Event == "RefuelPartial")
            {
                _fuelLevel += entry.Amount;
            }
            else if (entry.Event == "ShieldState")
            {
                _shields = entry.ShieldsUp;
            }

            _propertyChangedCallback();
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
