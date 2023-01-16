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
using Pen.DataBase;

namespace Pen.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistPage.xaml
    /// </summary>
    public partial class RegistPage : Page
    {
        public RegistPage()
        {
            InitializeComponent();
        }

        private void btnRegist_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            string name = tbName.Text.Trim();
            string log = tbLog.Text.Trim();
            string pas = tbPas.Text.Trim();
            user = bdconnection.connection.User.Where(x => x.Login == log).FirstOrDefault();
            if(user == null)
            {
                User newUser = new User();
                newUser.Name = name;
                newUser.Login = log;
                newUser.Password = pas;
                bdconnection.connection.User.Add(newUser);
                bdconnection.connection.SaveChanges();
                NavigationService.Navigate(new AuthorizPage());
            }
            else
            {
                MessageBox.Show("Придумайте другой логин");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistPage());
        }
    }
}
