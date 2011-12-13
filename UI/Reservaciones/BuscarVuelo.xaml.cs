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
using BusinessLogic;

namespace UI
{
    /// <summary>
    /// Interaction logic for BuscarVuelo.xaml
    /// </summary>
    public partial class BuscarVuelo : Window
    {
        List<AeropuertoView> aeropuertos;
        ObservableCollection<TransVuelo> vuelos_ida;
        ObservableCollection<TransVuelo> vuelos_vuelta;
        
        public BuscarVuelo()
        {
            InitializeComponent();

            try
            {
                aeropuertos = DataLayer.DALDestino.GetAllAeropuerto().ConvertAll<AeropuertoView>(pers => new AeropuertoView(pers));
                
                // Bind ComboBoxes
                Binding binding = new Binding();
                binding.Source = aeropuertos;
                cbDesde.SetBinding(ComboBox.ItemsSourceProperty, binding);
                cbHacia.SetBinding(ComboBox.ItemsSourceProperty, binding);
                
                // Bind ListBoxes
                vuelos_ida = new ObservableCollection<TransVuelo>();
                binding = new Binding();
                binding.Source = vuelos_ida;
                lbVuelosIda.SetBinding(ListBox.ItemsSourceProperty, binding);

                vuelos_vuelta = new ObservableCollection<TransVuelo>();
                binding = new Binding();
                binding.Source = vuelos_vuelta;
                lbVuelosVuelta.SetBinding(ListBox.ItemsSourceProperty, binding);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            ReservacionMain reservacion_main = new ReservacionMain();
            reservacion_main.Top = this.Top;
            reservacion_main.Left = this.Left;
            this.Close();
            reservacion_main.Show();
        }

        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (dpSalida.SelectedDate == null)
                return;

            if (cbDesde.SelectedValue == null || cbHacia.SelectedValue == null)
                return;

            // Vuelos De Ida
            List<TransVuelo> _vuelos_lista = DALVuelo.GetVueloFromFechaAndPuerto(dpSalida.SelectedDate.Value, dpSalida.SelectedDate.Value, 
                ((AeropuertoView)cbDesde.SelectedValue).PersistentObject, ((AeropuertoView)cbHacia.SelectedValue).PersistentObject).ConvertAll<TransVuelo>(pers => new TransVuelo(pers));
            // Move objects to ObservableList
            vuelos_ida.Clear();
            foreach (TransVuelo vuelo in _vuelos_lista)
            {
                vuelos_ida.Add(vuelo);
            }


            if (rbIda.IsChecked.Value) // Do we need a return flight?
                return;

            // Vuelos de Regreso
            _vuelos_lista = DALVuelo.GetVueloFromFechaAndPuerto(dpRegreso.SelectedDate.Value, dpRegreso.SelectedDate.Value,
                ((AeropuertoView)cbHacia.SelectedValue).PersistentObject, ((AeropuertoView)cbDesde.SelectedValue).PersistentObject).ConvertAll<TransVuelo>(pers => new TransVuelo(pers));
            // Move objects to ObservableList
            vuelos_vuelta.Clear();
            foreach (TransVuelo vuelo in _vuelos_lista)
            {
                vuelos_vuelta.Add(vuelo);
            }
        }

        private void rbIda_Checked(object sender, RoutedEventArgs e)
        {
            dpRegreso.IsEnabled = false;
            lbVuelosVuelta.IsEnabled = false;
        }

        private void rbIdaVuelta_Checked(object sender, RoutedEventArgs e)
        {
            if (cbHacia != null)
            {
                dpRegreso.IsEnabled = true;
                lbVuelosVuelta.IsEnabled = true;
            }

        }
    }
}
