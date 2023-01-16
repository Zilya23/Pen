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
using Pen.Pages;
using Pen.DataBase;

namespace Pen.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizPage.xaml
    /// </summary>
    public partial class AuthorizPage : Page
    {
        public static User user { get; set; }
        public AuthorizPage()
        {
            InitializeComponent();
        }

        private void btnAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPass.Password.Trim();
            user = bdconnection.connection.User.Where(x=> x.Login == login && x.Password == password).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Hehe");
            }
            else
            {
                MessageBox.Show("Ne Hehe");
            }
        }

        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistPage());
        }
    }
}
