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
        ObservableCollection<TransVuelo> vuelos;
        Action<TransVuelo> callback;
        
        public BuscarVuelo(Action<TransVuelo> vuelo_callback = null)
        {
            InitializeComponent();
            callback = vuelo_callback;
            try
            {
                aeropuertos = TransAeropuerto.GetAll().ConvertAll<AeropuertoView>(trans => new AeropuertoView(trans.PersistentObject));
                
                // Bind ComboBoxes
                Binding binding = new Binding();
                binding.Source = aeropuertos;
                cbDesde.SetBinding(ComboBox.ItemsSourceProperty, binding);
                cbHacia.SetBinding(ComboBox.ItemsSourceProperty, binding);
                
                // Bind ListBoxes
                vuelos = new ObservableCollection<TransVuelo>();
                binding = new Binding();
                binding.Source = vuelos;
                lbVuelos.SetBinding(ListBox.ItemsSourceProperty, binding);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            if (callback != null)
            {
                // This window should've been opened as a Dialog
                this.Close();
                return;
            }

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
            List<TransVuelo> _vuelos_lista = TransVuelo.FromFechaAndPuerto(dpSalida.SelectedDate.Value, dpSalida.SelectedDate.Value, (TransAeropuerto)cbDesde.SelectedValue, (TransAeropuerto)cbHacia.SelectedValue);

            // Move objects to ObservableList
            vuelos.Clear();
            foreach (TransVuelo vuelo in _vuelos_lista)
            {
                vuelos.Add(vuelo);
            }

        }

        private void lbVuelos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TransVuelo vuelo = (TransVuelo)lbVuelos.SelectedItem;
            if (callback != null)
            {
                callback(vuelo);
                this.Close();
            }
        }
    }
}
