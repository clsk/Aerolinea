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
        List<NivelUsuario> losNiveles;
        public EditUser(TransUsuario unUser)
        {
            InitializeComponent();
            losNiveles = new List<NivelUsuario>();
            Binding binding = new Binding();
            losNiveles = DALUsuario.GetAllNivelUsuario();
            binding.Source = losNiveles;
            cbNivel.SetBinding(ListBox.ItemsSourceProperty, binding);
            unUsuario = unUser;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            tbNombre.IsEnabled = true;
            tbLogin.IsEnabled = true;
            tbPass.IsEnabled = true;
            cbEstado.IsEnabled = true;
            cbNivel.IsEnabled = true;
            btnEdit.IsEnabled= false;
        }
        private bool VerifDatos()
        {
            if (tbNombre.Text != "")
                if (tbLogin.Text != "")
                    if (tbPass.Password.ToString().Length >= 6)
                        if(cbNivel.SelectedItem != null)
                            if(cbEstado.SelectedIndex==0 || cbEstado.SelectedIndex==1)
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

        private void btmSave_Click_1(object sender, RoutedEventArgs e)
        {
            if (cbNivel.SelectedIndex == 0)
                unUsuario.IsActive = false;
            else
                unUsuario.IsActive = true;
            unUsuario.Nombre = tbNombre.Text;
            unUsuario.Login = tbLogin.Text;
            unUsuario.Password = tbPass.Password;
            unUsuario.Nivel = (NivelUsuario)cbNivel.SelectedItem;
            unUsuario.Flush();
            MessageBox.Show("Se ha modificado el usuario exitosamente.");
            AdmUser prevWin = new AdmUser();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            tbLogin.Text = unUsuario.Login;
            tbNombre.Text = unUsuario.Nombre;
            tbPass.Password = unUsuario.Password;
            cbNivel.SelectedItem = unUsuario.Nivel;
            if (unUsuario.IsActive)
                cbEstado.SelectedIndex = 1;
            else
                cbEstado.SelectedIndex = 0;
            btmSave.IsEnabled = false;
        }

        private void cbEstado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btmSave.IsEnabled = VerifDatos();
        }

        private void cbNivel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btmSave.IsEnabled = VerifDatos();
        }
    }
}
