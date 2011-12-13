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

namespace UI.Administrativo.AdmVuelo
{
    /// <summary>
    /// Interaction logic for NewDestino.xaml
    /// </summary>
    public partial class NewDestino : Window
    {
        public NewDestino()
        {
            InitializeComponent();
        }
        public bool VerifInfosPais()
        {
            if (tbNombrePais.Text != "")
                return true;
            return false;
        }

        public bool VerifInfosCiudad()
        {
            if (tbNombreCiudad.Text != "")
                return true;
            return false;
        }

        public bool VerifInfosAeropuerto()
        {
            if (tbNombreAero.Text != "")
                if (tbSiglas.Text.Length == 3)
                    return true;
            return false;
        }
        private void tabPais_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnNewDestino.IsEnabled = VerifInfosAeropuerto();
        }

        private void tbcDestino_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabAeropuerto.IsSelected)
            {
                btnNewDestino.IsEnabled = VerifInfosAeropuerto();
            }

            if (tabCiudad.IsSelected)
            {
                btnNewDestino.IsEnabled = VerifInfosCiudad();
            }

            if (tabPais.IsSelected)
            {
                btnNewDestino.IsEnabled = VerifInfosPais();
            }

        }

        private void tbNombrePais_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewDestino.IsEnabled = VerifInfosPais();
        }

        private void tbNombreCiudad_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewDestino.IsEnabled = VerifInfosCiudad();
        }

        private void tbNombreAero_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewDestino.IsEnabled = VerifInfosAeropuerto();
        }

        private void tbSiglas_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewDestino.IsEnabled = VerifInfosAeropuerto();
        }

    }
}
