using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        List<NivelUsuario> niveles;
        public NewUser()
        {
            InitializeComponent();

            niveles = DataLayer.DALUsuario.GetAllNivelUsuario();

            // Bind ComboBoxes
            Binding binding = new Binding();
            binding.Source = niveles;
            cbxNivel.SetBinding(ComboBox.ItemsSourceProperty, binding);
        }

        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            btmNewUser.IsEnabled = VerifDatos();
        }

        private void tbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            btmNewUser.IsEnabled = VerifDatos();
        }

        private void tbPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btmNewUser.IsEnabled = VerifDatos();
        }

        private void btmNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NivelUsuario nivel = (NivelUsuario)cbxNivel.SelectedValue;
                TransUsuario usuario = new TransUsuario(tbNombre.Text, tbLogin.Text, tbPass.Password, nivel, cbxEstado.SelectedItem == activo);
                usuario.Create();
                MessageBox.Show("El usuario " + usuario.Nombre + " (" + usuario.Login + ") fue creado exitosamente");
                btmAtras_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Data);
            }
        }

        private bool VerifDatos()
        {
            if (tbNombre.Text != "")
                if (cbxNivel.SelectedIndex == 0 || cbxNivel.SelectedIndex == 1)
                    if (tbLogin.Text != "")
                        if (tbPass.Password.ToString().Length >= 6)
                            if(cbxEstado.SelectedItem != null)
                                return true;

            return false;
        }

        private void btmAtras_Click(object sender, RoutedEventArgs e)
        {
            AdmUser prevWin = new AdmUser();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void cbxNivel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btmNewUser.IsEnabled = VerifDatos();
        }
    }
}
