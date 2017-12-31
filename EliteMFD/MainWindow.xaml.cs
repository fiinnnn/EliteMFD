using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EliteMFD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly EliteMFDController _eliteMFDController;

        private readonly List<TabItem> _tabItems;
        private readonly TabItem _tabAdd;

        public MainWindow()
        {
            InitializeComponent();

            _eliteMFDController = new EliteMFDController();

            _tabItems = new List<TabItem>();

            _tabAdd = new TabItem {Header = "+"};

            _tabItems.Add(_tabAdd);

            AddTabItem();

            TabControl.DataContext = _tabItems;

            TabControl.SelectedIndex = 0;
        }

        private TabItem AddTabItem()
        {
            TabItem tab = new TabItem
            {
                Header = $"Page {_tabItems.Count}",
                Name = $"page{_tabItems.Count}",
                HeaderTemplate = TabControl.FindResource("TabHeader") as DataTemplate
            };

            Page page = new Page
            {
                Index = _tabItems.Count - 1
            };

            _eliteMFDController.Pages.Add(page);

            tab.Content = new MFDOptions(page);

            _tabItems.Insert(_tabItems.Count - 1, tab);

            return tab;
        }

        private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tab = TabControl.SelectedItem as TabItem;

            if (tab?.Header == null) return;

            if (!tab.Equals(_tabAdd)) return;

            TabControl.DataContext = null;

            var newTab = AddTabItem();

            TabControl.DataContext = _tabItems;

            TabControl.SelectedItem = newTab;
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var tabName = ((Button) sender).CommandParameter.ToString();
            var tab = TabControl.Items.Cast<TabItem>().SingleOrDefault(i => i.Name.Equals(tabName));

            if (tab == null) return;

            if (_tabItems.Count < 3)
            {
                MessageBox.Show("Can't remove last tab");
            }
            else
            {
                var selectedTab = TabControl.SelectedItem as TabItem;

                TabControl.DataContext = null;

                _tabItems.Remove(tab);

                _eliteMFDController.Pages.Remove((Page) ((MFDOptions) tab.Content).DataContext);

                UpdateTabNames();

                TabControl.DataContext = _tabItems;

                if (selectedTab == null || selectedTab.Equals(tab))
                {
                    selectedTab = _tabItems[0];
                }

                TabControl.SelectedItem = selectedTab;
            }
        }

        private void UpdateTabNames()
        {
            for (var i = 0; i < _tabItems.Count - 1; i++)
            {
                _tabItems[i].Header = $"Page {i + 1}";
                _tabItems[i].Name = $"page{i + 1}";
            }
        }
    }
}
