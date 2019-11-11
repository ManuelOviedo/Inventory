using BCrypt.Net;
using Migration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Inventario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        protected CoreContext ctx = new CoreContext();
        public string strArr { get; set; }

        public Login()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var user = ctx.Users.Where(c => c.NickName == "Erick").First();
            var pass = txtPassword.Password;
            //strArr = BCrypt.Net.BCrypt.Verify(pass, user.Password);
        }
    }
}
