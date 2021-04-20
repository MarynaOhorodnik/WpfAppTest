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
using System.Windows.Shapes;

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();


            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Некоректне значення";
                textBoxLogin.Background = Brushes.MistyRose;
            }

            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Некоректне значення";
                passBox.Background = Brushes.MistyRose;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;


                User authUser = null;
                using(ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(user => user.Login == login && user.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {
                    MessageBox.Show("Успішно!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }

                else
                    MessageBox.Show("Логін або пароль некоректні!");
            }
        }

        private void Button_Reg_Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
