using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using EliteMFD.Annotations;
using EliteMFD.EDSM;

namespace EliteMFD
{
    public class Page : INotifyPropertyChanged
    {
        public int Index;

        public IEnumerable<string> Options => EliteMFDOptionsSource.Options;

        public string[] SelectedOptions => new[] {Line1Option, Line2Option, Line3Option};

        public string Line1Option { get; set; }
        public string Line2Option { get; set; }
        public string Line3Option { get; set; }

        public string DestinationSystem { get; set; }
        public Point3D DestinationCoordinates { get; set; }

        public string ConnectionStatus
        {
            get => _connectionStatus;
            set
            {
                _connectionStatus = $"EDSM Connection: {value}";
                OnPropertyChanged(nameof(ConnectionStatus));
            }
        }

        private readonly EDSMConnector _edsmConnector;
        private string _connectionStatus;

        public Page(int index)
        {
            Index = index;

            _edsmConnector = new EDSMConnector();

            ConnectionStatus = _edsmConnector.ConnectionStatus == EDSMConnector.Status.Success ? "Successful" : "Error";
        }

        public void GetCoordinates()
        {
            _edsmConnector.GetSysCoordinates(DestinationSystem, Callback);

            ConnectionStatus = _edsmConnector.ConnectionStatus == EDSMConnector.Status.Success ? "Successful" : "Error";
        }

        private void Callback(EDSMSystemInfo systemInfo)
        {
            ConnectionStatus = "Successful";

            if (systemInfo == null)
            {
                DestinationSystem = "Not found";
                OnPropertyChanged(nameof(DestinationSystem));
                return;
            }

            DestinationCoordinates = systemInfo.coords;

            DestinationSystem = systemInfo.coords.ToString();
            OnPropertyChanged(nameof(DestinationSystem));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
