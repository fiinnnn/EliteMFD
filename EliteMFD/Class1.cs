using PropertyChanged;
using System.ComponentModel;
using EliteMFD.EliteDangerous;

namespace EliteMFD
{
    [AddINotifyPropertyChangedInterface]
    public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public string Test { get; set; }
    }
}
