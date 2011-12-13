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
using DataLayer;

namespace UI.Administrativo.AdmUser
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        TransUsuario unUsuario;
        public EditUser(string Nombre, string Login, string password, NivelUsuario Nivel, bool Activo)
        {
            unUsuario = new TransUsuario(Nombre,Login, password, ,Activo);

            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            tbNombre.IsEnabled = true;
            tbLogin.IsEnabled = true;
            tbPass.IsEnabled = true;
            cbxEstado.IsEnabled = true;
            cbxNivel.IsEnabled = true;
            btnEdit.IsEnabled= false;
            btmSave.IsEnabled = true;
        }
        private bool VerifDatos()
        {
            if (tbNombre.Text != "")
                if (tbLogin.Text != "")
                    if (tbPass.Password.ToString().Length >= 6)
                        return true;
            return false;
        }
        
        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            btmSave.IsEnabled = VerifDatos();
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            btmSave.IsEnabled = VerifDatos();
        }

        private void tbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btmSave.IsEnabled = VerifDatos();
        }

        private void btmAtras_Click(object sender, RoutedEventArgs e)
        {
            AdmUser prevWin = new AdmUser();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
