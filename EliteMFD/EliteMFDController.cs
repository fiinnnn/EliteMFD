using System;
using System.Collections.Generic;
using EliteMFD.X52Pro;

namespace EliteMFD
{
    public class EliteMFDController
    {
        public List<Page> Pages;

        private X52ProManager x52Pro;
        private EliteMFDInfo mfdInfo;

        public EliteMFDController()
        {
            Pages = new List<Page>();

            mfdInfo = new EliteMFDInfo(UpdateDisplay);
            //x52Pro = new X52ProManager("EliteMFD");
            //x52Pro.AddPage(0, true);
            //x52Pro.AddPage(1);
        }

        /// <summary>
        /// Updates the display after the propertiesupdated event
        /// </summary>
        private void UpdateDisplay()
        {
            return;
            /*for (var page = 0; page < 2; page++)
            {
                for (var index = 0; index < 3; index++)
                {
                    var option = "";
                    switch (page)
                    {
                        case 0:
                            option = Page1Options[index];
                            break;
                        case 1:
                            option = Page2Options[index];
                            break;
                    }

                    switch (option)
                    {
                        case "Commander name":
                            x52Pro.SetString(page, index, mfdInfo.CommanderName);
                            break;
                        case "Ship name":
                            x52Pro.SetString(page, index, mfdInfo.ShipName);
                            break;
                        case "Ship ID":
                            x52Pro.SetString(page, index, mfdInfo.ShipId);
                            break;
                        case "Current location":
                            x52Pro.SetString(page, index, mfdInfo.SysName);
                            break;
                        case "Distance from Sol":
                            x52Pro.SetString(page, index, mfdInfo.Distance);
                            break;
                        case "Fuel level":
                            x52Pro.SetString(page, index, mfdInfo.Fuel);
                            break;
                        case "Assigned landing pad":
                            x52Pro.SetString(page, index, mfdInfo.LandingPad);
                            break;
                        case "Last refined material":
                            x52Pro.SetString(page, index, mfdInfo.LastRefined);
                            break;
                        case "Shield state":
                            x52Pro.SetString(page, index, mfdInfo.ShieldStatus);
                            break;
                        case "Combat rank":
                            x52Pro.SetString(page, index, mfdInfo.CombatRank);
                            break;
                        case "Trade rank":
                            x52Pro.SetString(page, index, mfdInfo.TradeRank);
                            break;
                        case "Exploration rank":
                            x52Pro.SetString(page, index, mfdInfo.ExplorationRank);
                            break;
                        case "Federation rank":
                            x52Pro.SetString(page, index, mfdInfo.FederationRank);
                            break;
                        case "Empire rank":
                            x52Pro.SetString(page, index, mfdInfo.EmpireRank);
                            break;
                        case "CQC rank":
                            x52Pro.SetString(page, index, mfdInfo.CQCRank);
                            break;
                    }
                }
            }*/
        }
    }
}
