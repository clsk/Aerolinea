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
                aeropuertos = TransAeropuerto.GetAll().ConvertAll<AeropuertoView>(trans => new AeropuertoView(trans.PersistentObject));
                
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

            rbIdaVuelta.IsChecked = true;
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

            if (rbIdaVuelta.IsChecked.Value == true && dpRegreso.SelectedDate == null)
                return;

            if (cbDesde.SelectedValue == null || cbHacia.SelectedValue == null)
                return;

            // Vuelos De Ida
            List<TransVuelo> _vuelos_lista = TransVuelo.FromFechaAndPuerto(dpSalida.SelectedDate.Value, dpSalida.SelectedDate.Value, (TransAeropuerto)cbDesde.SelectedValue, (TransAeropuerto)cbHacia.SelectedValue);

            // Move objects to ObservableList
            vuelos_ida.Clear();
            foreach (TransVuelo vuelo in _vuelos_lista)
            {
                vuelos_ida.Add(vuelo);
            }


            if (rbIda.IsChecked.Value) // Do we need a return flight?
                return;

            // Vuelos de Regreso
            _vuelos_lista = TransVuelo.FromFechaAndPuerto(dpRegreso.SelectedDate.Value, dpRegreso.SelectedDate.Value, (TransAeropuerto)cbHacia.SelectedValue, (TransAeropuerto)cbDesde.SelectedValue);

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
