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

namespace UI
{
    /// <summary>
    /// Interaction logic for BuscarVuelo.xaml
    /// </summary>
    public partial class BuscarVuelo : Window
    {
        List<TransAeropuerto> aeropuertos;
        public BuscarVuelo()
        {
            InitializeComponent();

            try
            {
                aeropuertos = DataLayer.DALDestino.GetAllAeropuerto().ConvertAll<TransAeropuerto>(pers => new TransAeropuerto(pers));
                
                Binding binding = new Binding("");
                binding.Source = aeropuertos;
                cbDesde.SetBinding(ComboBox.ItemsSourceProperty, binding);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            ReservacionMain reservacion_main = new ReservacionMain();
            this.Close();
            reservacion_main.Show();
        }

        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            foreach (TransAeropuerto aeropuerto in aeropuertos)
            {
                if (aeropuerto.Nombre[25] == 'd' && aeropuerto.Nombre[26] == 'e')
                {
                    if (aeropuerto.Nombre[27] == 'l' && aeropuerto.Nombre[28] == ' ')
                    {
                        MessageBox.Show(aeropuerto.Nombre.Substring(29));
                        aeropuerto.Nombre = aeropuerto.Nombre.Substring(29);
                    }
                    else
                    {
                        MessageBox.Show(aeropuerto.Nombre.Substring(28));
                        aeropuerto.Nombre = aeropuerto.Nombre.Substring(28);
                    }
                }

                else
                {
                    MessageBox.Show(aeropuerto.Nombre.Substring(25));
                    aeropuerto.Nombre = aeropuerto.Nombre.Substring(25);
                }

                aeropuerto.Flush();
            }
        }
    }
}
