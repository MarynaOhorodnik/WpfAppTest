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

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

            //List<User> users = db.Users.ToList();
            //string str = "";
            //foreach (User user in users)
            //    str += "Login " + user.Login + " | ";


            //exampleText.Text = str;
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass1 = passBox1.Password.Trim();
            string pass2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.Trim();

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Некоректне значення";
                textBoxLogin.Background = Brushes.MistyRose;
            }

            else if(pass1.Length < 5)
            {
                passBox1.ToolTip = "Некоректне значення";
                passBox1.Background = Brushes.MistyRose;
            }

            else if (pass2 != pass1)
            {
                passBox2.ToolTip = "Некоректне значення";
                passBox2.Background = Brushes.MistyRose;
            }

            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Некоректне значення";
                textBoxEmail.Background = Brushes.MistyRose;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox1.ToolTip = "";
                passBox1.Background = Brushes.Transparent;
                passBox2.ToolTip = "";
                passBox2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Успішно!");

                User user = new User(login, email, pass1);

                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }

        }

        private void Button_Auth_Window_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
