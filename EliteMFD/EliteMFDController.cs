using System;
using System.Collections.Generic;
using EliteMFD.X52Pro;

namespace EliteMFD
{
    public class EliteMFDController
    {
        public IEnumerable<string> Options => EliteMFDOptionsSource.Options;

        public string SelectedLine1Option
        {
            get { return _selectedLine1Option; }
            set
            {
                _selectedLine1Option = value;
                UpdateDisplay(this, EventArgs.Empty);
            }
        }

        public string SelectedLine2Option
        {
            get { return _selectedLine2Option; }
            set
            {
                _selectedLine2Option = value; 
                UpdateDisplay(this, EventArgs.Empty);
            }
        }

        public string SelectedLine3Option
        {
            get { return _selectedLine3Option; }
            set
            {
                _selectedLine3Option = value;
                UpdateDisplay(this, EventArgs.Empty);
            }
        }

        private string _selectedLine1Option;
        private string _selectedLine2Option;
        private string _selectedLine3Option;

        private X52ProManager x52Pro;
        private EliteMFDInfo mfdInfo;

        public EliteMFDController()
        {
            mfdInfo = new EliteMFDInfo();
            mfdInfo.PropertiesUpdated += UpdateDisplay;
            x52Pro = new X52ProManager("EliteMFD");
            x52Pro.AddPage(0, true);
        }

        /// <summary>
        /// Updates the display after the propertiesupdated event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateDisplay(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                string option;
                if (i == 0)
                {
                    option = SelectedLine1Option;
                }
                else if (i == 1)
                {
                    option = SelectedLine2Option;
                }
                else
                {
                    option = SelectedLine3Option;
                }

                if (option == "Commander name")
                    x52Pro.SetString(i, mfdInfo.CommanderName);
                else if (option == "Ship name")
                {
                    x52Pro.SetString(i, mfdInfo.ShipName);
                }
                else if (option == "Ship ID")
                {
                    x52Pro.SetString(i, mfdInfo.ShipId);
                }
                else if (option == "Current location")
                {
                    x52Pro.SetString(i, mfdInfo.SysName);
                }
                else if (option == "Distance from Sol")
                {
                    x52Pro.SetString(i, mfdInfo.Distance);
                }
                else if (option == "Fuel level")
                {
                    x52Pro.SetString(i, mfdInfo.Fuel);
                }
                else if (option == "Assigned landing pad")
                {
                    x52Pro.SetString(i, mfdInfo.LandingPad);
                }
                else if (option == "Last refined material")
                {
                    x52Pro.SetString(i, mfdInfo.LastRefined);
                }
                else if (option == "Shield state")
                {
                    x52Pro.SetString(i, mfdInfo.ShieldStatus);
                }
                else if (option == "Combat rank")
                {
                    x52Pro.SetString(i, mfdInfo.CombatRank);
                }
                else if (option == "Trade rank")
                {
                    x52Pro.SetString(i, mfdInfo.TradeRank);
                }
                else if (option == "Exploration rank")
                {
                    x52Pro.SetString(i, mfdInfo.ExplorationRank);
                }
                else if (option == "Federation rank")
                {
                    x52Pro.SetString(i, mfdInfo.FederationRank);
                }
                else if (option == "Empire rank")
                {
                    x52Pro.SetString(i, mfdInfo.EmpireRank);
                }
                else if (option == "CQC rank")
                {
                    x52Pro.SetString(i, mfdInfo.CQCRank);
                }
            }
        }
    }
}
