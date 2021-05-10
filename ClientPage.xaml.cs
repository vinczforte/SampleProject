using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditPage(new Client()));
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var selClient = DgridView.SelectedItem as Client;
            if (selClient != null)
            {
                MainWindow.db.Client.Remove(selClient);
                MainWindow.db.SaveChanges();
            }
            else MessageBox.Show("Ничего не выбрано");
            DgridView.ItemsSource = MainWindow.db.Client.ToList();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var SelClient = DgridView.SelectedItem as Client;
            if (SelClient == null)
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            else
                NavigationService.Navigate(new EditPage(SelClient));
        }

        private void DgridView_Loaded(object sender, RoutedEventArgs e)
        {
            DgridView.ItemsSource = MainWindow.db.Client.ToList();
        }
    }
}
