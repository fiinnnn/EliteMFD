using System.Windows;
using System.Windows.Controls;

namespace EliteMFD
{
    public partial class MFDOptions : UserControl
    {
        private readonly Page _page;

        public MFDOptions(Page page)
        {
            InitializeComponent();

            _page = page;

            DataContext = page;
        }

        private void ButtonGetCoordinates_OnClick(object sender, RoutedEventArgs e)
        {
            _page.GetCoordinates();
        }
    }
}
