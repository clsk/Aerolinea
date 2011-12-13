using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
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
    /// Interaction logic for BuscarUser.xaml
    /// </summary>
    public partial class BuscarUser : Window
    {
        ObservableCollection<Usuario> usuarios;
        public BuscarUser()
        {
            InitializeComponent();

            try
            {
                usuarios = new ObservableCollection<Usuario>();
                Binding binding = new Binding();
                binding.Source = usuarios;
                lbUsuarios.SetBinding(ListBox.ItemsSourceProperty, binding);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        } 

        private void tbxBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxBusqueda.Text != "")
                btnBuscar.IsEnabled = true;
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            AdmUser prevWin = new AdmUser();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            usuarios.Clear();
            if (cbxBusqueda.SelectedIndex != 0)
            {
                Usuario user = DALUsuario.GetUsuarioFromLogin(tbxBusqueda.Text);
                usuarios.Add(user);
            }
            else
            {
                List<Usuario> users = DALUsuario.GetUsuarioFromNombre(tbxBusqueda.Text);
                foreach (Usuario user in users)
                {
                    usuarios.Add(user);
                }
            }
        }
    }
}