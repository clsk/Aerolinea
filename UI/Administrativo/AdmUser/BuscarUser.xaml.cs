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
    /// Interaction logic for BuscarUser.xaml
    /// </summary>
    public partial class BuscarUser : Window
    {
        List<Usuario> usuarios;
        public BuscarUser()
        {
            InitializeComponent();
            usuarios = new List<Usuario>();
            Binding binding = new Binding("");
            binding.Source = usuarios;
            dgvBusqueda.SetBinding(dgvBusqueda.Columns, binding);
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
            Usuario unUsuario;
            unUsuario = DataLayer.DALUsuario.GetUsuarioFromLogin(tbxBusqueda.Text);
            usuarios.Add(unUsuario);
        }
    }
}