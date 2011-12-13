using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLogic;

namespace UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LUser.GetInstance().Login(tbUsername.Text, tbPassword.Password) == false)
            {
                MessageBox.Show("Error: El usuario/clave no son correcto");
                return;
            }

            if (LUser.GetInstance().IsActive == false)
            {
                MessageBox.Show("Su usuario ha sido deshabilitado.\nPara mas informacion contacte su administrador");
                return;
            }

            MainWindow main_window = new MainWindow();
            main_window.Top = this.Top;
            main_window.Left = this.Left;
            main_window.Show();
            this.Close();
        }
    }
}
