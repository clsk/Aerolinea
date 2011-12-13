﻿using System;
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
        ObservableCollection<NivelUsuario> niveles;
        public NewUser()
        {
            InitializeComponent();

            // niveles = DataLayer.DALDestino.GetAllAeropuerto().ConvertAll<AeropuertoView>(pers => new AeropuertoView(pers));

            // Bind ComboBoxes
            // Binding binding = new Binding();
            // binding.Source = aeropuertos;
            // cbDesde.SetBinding(ComboBox.ItemsSourceProperty, binding);
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

        }

        private bool VerifDatos()
        {
            if (tbNombre.Text != "")
                if (tbLogin.Text != "")
                    if (tbPass.Password.ToString().Length >= 6)
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
    }
}
