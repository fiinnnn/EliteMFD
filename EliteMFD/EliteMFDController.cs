using System.Collections.Generic;
using EliteMFD.X52Pro;

namespace EliteMFD
{
    public class EliteMFDController
    {
        public readonly List<Page> Pages;

        private readonly X52ProManager _x52Pro;
        private readonly EliteMFDInfo _mfdInfo;

        public EliteMFDController()
        {
            Pages = new List<Page>();

            _mfdInfo = new EliteMFDInfo(UpdateDisplay);
            _x52Pro = new X52ProManager("EliteMFD");
            _x52Pro.AddPage(0, true);
            _x52Pro.AddPage(1);
        }

        /// <summary>
        /// Updates the display after the propertiesupdated event
        /// </summary>
        private void UpdateDisplay()
        {
            foreach (var page in Pages)
            {
                for (var i = 0; i < 3; i++)
                {
                    var option = page.SelectedOptions[i];

                    switch (option)
                    {
                        default:
                            _x52Pro.SetString(page.Index, i, "");
                            break;
                        case "Commander name":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.CommanderName);
                            break;
                        case "Ship name":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.ShipName);
                            break;
                        case "Ship ID":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.ShipId);
                            break;
                        case "Current location":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.SysName);
                            break;
                        case "Distance from Sol":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.Distance);
                            break;
                        case "Fuel level":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.Fuel);
                            break;
                        case "Assigned landing pad":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.LandingPad);
                            break;
                        case "Last refined material":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.LastRefined);
                            break;
                        case "Shield state":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.ShieldStatus);
                            break;
                        case "Combat rank":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.CombatRank);
                            break;
                        case "Trade rank":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.TradeRank);
                            break;
                        case "Exploration rank":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.ExplorationRank);
                            break;
                        case "Federation rank":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.FederationRank);
                            break;
                        case "Empire rank":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.EmpireRank);
                            break;
                        case "CQC rank":
                            _x52Pro.SetString(page.Index, i, _mfdInfo.CqcRank);
                            break;
                    }
                }
            }
        }
    }
}
