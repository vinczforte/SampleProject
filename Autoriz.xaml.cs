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
    public class UserInfo
    {
        public static int InfoRole
        {
            get;
            set;
        }
    }
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Page
    {
        public User AuthUser;
        public Autoriz()
        {
            InitializeComponent();
        }

        private void Bautoriz_Click(object sender, RoutedEventArgs e)
        {
            var user = MainWindow.db.User.Where(x => x.Login == TBoxLogin.Text && x.Password == TBoxPass.Text).FirstOrDefault();
            if (user != null)
            {
                if(user.Role == 1)
                {
                    MessageBox.Show("Главный");
                    UserInfo.InfoRole = 1;
                    this.NavigationService.Navigate(new MenuPage());
                }
                else
                {
                    if(user.Role == 2)
                    {
                        MessageBox.Show("Не главный");
                        UserInfo.InfoRole = 2;
                        this.NavigationService.Navigate(new MenuPage());
                    }    
                }
            }    
        }
    }
}
