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
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public Client ContClient;
        public EditPage(Client selClient)
        {
            InitializeComponent();
            ContClient = selClient;
            this.DataContext = ContClient;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ContClient.ID == 0)
            {
                MainWindow.db.Client.Add(ContClient);
            }
            MainWindow.db.SaveChanges();
            NavigationService.Navigate(new ClientPage());
        }
    }
}
