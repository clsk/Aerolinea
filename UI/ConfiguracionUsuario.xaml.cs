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
using System.Windows.Shapes;
using BusinessLogic;

namespace UI
{
    /// <summary>
    /// Interaction logic for ConfiguracionUsuario.xaml
    /// </summary>
    public partial class ConfiguracionUsuario : Window
    {
        public ConfiguracionUsuario()
        {
            InitializeComponent();
            btSave.IsEnabled = false;
        }

        private void ValidarSave()
        {
            if (tbPassActual.Password.Length > 0 && tbPassNew.Password.Length > 0 && tbPassConfirm.Password.Length > 0
                && tbPassNew.Password == tbPassConfirm.Password)
            {
                btSave.IsEnabled = true;
            }
            else
            {
                btSave.IsEnabled = false;
            }
        }


        private void tbPassActual_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidarSave();
        }

        private void tbPassNew_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidarSave();
        }

        private void tbPassConfirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidarSave();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (tbPassActual.Password != LUser.GetInstance().Password)
            {
                MessageBox.Show(tbPassActual.Password + " != " + LUser.GetInstance().Password);
                MessageBox.Show("Error: El password actual es invalido");
                return;
            }

            LUser.GetInstance().Password = tbPassNew.Password;
            LUser.GetInstance().Update();
            MessageBox.Show("Password fue cambiado exitosamente");
            btBack_Click(null, null);
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main_window = new MainWindow();
            main_window.Left = this.Left;
            main_window.Top = this.Top;
            this.Close();
            main_window.Show();
        }


    }
}
