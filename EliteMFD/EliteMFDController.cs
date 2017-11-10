using System;
using System.ComponentModel;
using PropertyChanged;

namespace EliteMFD
{
    [AddINotifyPropertyChangedInterface]
    public class EliteMFDController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

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
            x52Pro.SetString(0, mfdInfo.Fuel);
            x52Pro.SetString(1, mfdInfo.Distance);
            x52Pro.SetString(2, mfdInfo.ExplorationRank);
        }
    }
}
