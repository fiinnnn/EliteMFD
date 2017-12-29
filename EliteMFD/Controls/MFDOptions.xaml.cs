using System.Windows.Controls;

namespace EliteMFD
{
    public partial class MFDOptions : UserControl
    {
        public MFDOptions(Page page)
        {
            InitializeComponent();

            DataContext = page;
        }
    }
}
