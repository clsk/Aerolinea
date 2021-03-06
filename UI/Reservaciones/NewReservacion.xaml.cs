﻿using System;
using System.Collections.ObjectModel;
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
using BusinessLogic;
using UI.Reservaciones;

namespace UI
{
    /// <summary>
    /// Interaction logic for NewReservacion.xaml
    /// </summary>
    public partial class NewReservacion : Window
    {
        public NewReservacion()
        {
            InitializeComponent();
            btBuscarUsuario.IsEnabled = false;
            btCancelarSeleccion.IsEnabled = false;
            btNuevoUsuario.IsEnabled = false;
            venta = new Venta();

            personas = new ObservableCollection<Persona>();
            Binding binding = new Binding();
            binding.Source = personas;
            lbPersonas.SetBinding(ListBox.ItemsSourceProperty, binding);
        }

        public NewReservacion(Venta _venta)
        {
            InitializeComponent();
            btNuevoUsuario.IsEnabled = false;
            venta = _venta;
            btGuardar.Content = "Modificar Reservacion";
            FillPersona();
            SetVueloIda(venta.VueloIda);
            tbAsientoIda.Text = venta.AsientoIda.Fila.ToString() + venta.AsientoIda.Numero;
            tbIDIda.Text = "ID Reservacion: " + venta.ReservacionIda.ID;
            tiPersona.Background = Brushes.Green;
            tiVueloIda.Background = Brushes.Green;
            tiVueloRegreso.Background = Brushes.Yellow;
            if (venta.VueloVuelta != null)
            {
                SetVueloVuelta(venta.VueloVuelta);
                tbAsientoVuelta.Text = venta.AsientoVuelta.Fila.ToString() + venta.AsientoVuelta.Numero;
                tbIDVuelta.Text = "ID Reservacion: " + venta.ReservacionVuelta.ID;
                tiVueloRegreso.Background = Brushes.Green;
            }
        }

        Venta venta;
        ObservableCollection<Persona> personas;
        

        public void SetVueloIda(TransVuelo vuelo)
        {
            venta.VueloIda = vuelo;

            tbHoraSalidaIda.Text = vuelo.HoraSalida.ToString();
            tbDiaSalidaIda.Text = vuelo.FechaSalida.ToString("d");
            tbHoraLlegadaIda.Text = vuelo.HoraLlegada.ToString();
            tbDiaLlegadaIda.Text = vuelo.FechaLlegada.ToString("d");

            tbPuertoSalidaIda.Text = vuelo.PuertoSalida.Ciudad.NombreCiudad + " (" + vuelo.PuertoSalida.Siglas + ")";
            tbPuertoLlegadaIda.Text = vuelo.PuertoLlegada.Ciudad.NombreCiudad + " (" + vuelo.PuertoLlegada.Siglas + ")";

            tbComentariosIda.Text = vuelo.Comentario;
            tbAvionIda.Text = vuelo.Avion.Serie.MarcaAvion.NombreMarca + " " + vuelo.Avion.Serie.NombreSerie;
            btAsignarAsientoIda.IsEnabled = true;
        }

        public void SetVueloVuelta(TransVuelo vuelo)
        {
            venta.VueloVuelta = vuelo;

            tbHoraSalidaVuelta.Text = vuelo.HoraSalida.ToString();
            tbDiaSalidaVuelta.Text = vuelo.FechaSalida.ToString("d");
            tbHoraLlegadaVuelta.Text = vuelo.HoraLlegada.ToString();
            tbDiaLlegadaVuelta.Text = vuelo.FechaLlegada.ToString("d");

            tbPuertoSalidaVuelta.Text = vuelo.PuertoSalida.Ciudad.NombreCiudad + " (" + vuelo.PuertoSalida.Siglas + ")";
            tbPuertoLlegadaVuelta.Text = vuelo.PuertoLlegada.Ciudad.NombreCiudad + " (" + vuelo.PuertoLlegada.Siglas + ")";

            tbComentariosVuelta.Text = vuelo.Comentario;
            tbAvionVuelta.Text = vuelo.Avion.Serie.MarcaAvion.NombreMarca + " " + vuelo.Avion.Serie.NombreSerie;
            btAsignarAsientoVuelta.IsEnabled = true;
            tiVueloRegreso.Background = Brushes.Red;
        }

        private void btBuscarVuelo_Click(object sender, RoutedEventArgs e)
        {
            BuscarVuelo buscar_vuelo = new BuscarVuelo(SetVueloIda);
            buscar_vuelo.Left = this.Left;
            buscar_vuelo.Top = this.Top;
            buscar_vuelo.ShowDialog();
        }

        private void btBuscarVueloVuelta_Click(object sender, RoutedEventArgs e)
        {
            BuscarVuelo buscar_vuelo = new BuscarVuelo(SetVueloVuelta);
            buscar_vuelo.Left = this.Left;
            buscar_vuelo.Top = this.Top;
            buscar_vuelo.ShowDialog();
        }

        private void btAsignarAsientoIda_Click(object sender, RoutedEventArgs e)
        {
            Reservaciones.SeleccionarAsiento select_asiento = new SeleccionarAsiento(venta.VueloIda, SetAsientoIda);
            select_asiento.Left = this.Left;
            select_asiento.Top = this.Top;
            select_asiento.ShowDialog();
        }

        public void SetAsientoIda(TransAsiento asiento)
        {
            venta.AsientoIda = asiento;
            tbAsientoIda.Text = venta.AsientoIda.Fila.ToString() + venta.AsientoIda.Numero;
            tiVueloIda.Background = Brushes.Green;
        }

        public void SetAsientoVuelta(TransAsiento asiento)
        {
            venta.AsientoVuelta = asiento;
            tbAsientoVuelta.Text = venta.AsientoVuelta.Fila.ToString() + venta.AsientoVuelta.Numero;
            tiVueloRegreso.Background = Brushes.Green;
        }

        private void btAsignarAsientoIdaVuelta_Click(object sender, RoutedEventArgs e)
        {
            Reservaciones.SeleccionarAsiento select_asiento = new SeleccionarAsiento(venta.VueloVuelta, SetAsientoVuelta);
            select_asiento.Left = this.Left;
            select_asiento.Top = this.Top;
            select_asiento.ShowDialog();
        }

        void ValidarBuscarUsuario()
        {
            if (tbPasaporte.Text.Length > 0 || (tbNombre.Text.Length > 0 && tbApellido.Text.Length > 0))
            {
                btBuscarUsuario.IsEnabled = true;
            }
            else
            {
                btBuscarUsuario.IsEnabled = false;
            }
        }

        void ValidarNuevoUsuario()
        {
            if (tbPasaporte.Text.Length > 0 && tbNombre.Text.Length > 0 && tbApellido.Text.Length > 0 && venta.Persona == null)
            {
                btNuevoUsuario.IsEnabled = true;
            }
            else
            {
                btNuevoUsuario.IsEnabled = false;
            }
        }

        private void tbNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarBuscarUsuario();
            ValidarNuevoUsuario();
        }

        private void tbPasaporte_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarBuscarUsuario();
            ValidarNuevoUsuario();
        }

        private void tbApellido_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidarBuscarUsuario();
            ValidarNuevoUsuario();
        }

        private void FillPersona()
        {
            tbNombre.Text = venta.Persona.NombrePersona;
            tbApellido.Text = venta.Persona.ApellidosPersona;
            tbPasaporte.Text = venta.Persona.Pasaporte;
        }

        private void ClearPersona()
        {
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbPasaporte.Text = "";
        }

        private void btBuscarUsuario_Click(object sender, RoutedEventArgs e)
        {
            personas.Clear();
            // Buscar por pasaporte
            if (tbPasaporte.Text.Length > 0)
            {
                Persona persona = venta.FindPersona(tbPasaporte.Text);
                if (persona != null)
                {
                    personas.Add(persona);
                }
            }
            
            if (tbNombre.Text.Length > 0 && tbApellido.Text.Length > 0)
            {
                
                List<Persona> persona_list = venta.FindPersona(tbNombre.Text, tbApellido.Text);
                foreach (Persona persona in persona_list)
                {
                    personas.Add(persona);
                }
            }
        }

        private void lbPersonas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            venta.Persona = (Persona)lbPersonas.SelectedItem;
            if (venta.Persona != null)
            {
                FillPersona();
                btCancelarSeleccion.IsEnabled = true;
                tiPersona.Background = Brushes.Green;
            }
        }

        private void btCancelarSeleccion_Click(object sender, RoutedEventArgs e)
        {
            venta.Persona = null;
            btCancelarSeleccion.IsEnabled = false;
            ClearPersona();
            tiPersona.Background = Brushes.Red;
        }

        private void btNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            if (venta.CreatePersona(tbPasaporte.Text, tbNombre.Text, tbApellido.Text) == null)
            {
                MessageBox.Show("Error: Ya existe un cliente con ese pasaporte en el sistema. Utilice la opcion de buscar y seleccione el cliente");
                return;
            }

            btNuevoUsuario.IsEnabled = false;
            tiPersona.Background = Brushes.Green;
        }

        bool ValidarVueloIda()
        {
            if (venta.VueloIda != null && venta.AsientoIda != null)
            {
                tiVueloIda.Background = Brushes.Green;
                return true;
            }

            return false;
        }

        bool ValidarVueloVuelta()
        {
            if (venta.VueloVuelta != null)
            {
                if (venta.AsientoVuelta == null)
                {
                    tiVueloRegreso.Background = Brushes.Red;
                    return false;
                }
                else
                {
                    tiVueloRegreso.Background = Brushes.Green;
                    return true;
                }
            }
            else
            {
                tiVueloRegreso.Background = Brushes.Yellow;
                return true;
            }
        }

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarVueloIda() == false)
            {
                MessageBox.Show("Error: Debe seleccionar un vuelo y asiento de Ida");
                return;
            }

            if (ValidarVueloVuelta() == false)
            {
                MessageBox.Show("Error: Si selecciono un vuelo de vuelta, debe seleccionar un asiento para ese vuelo");
                return;
            }

            if (venta.Persona == null)
            {
                MessageBox.Show("Debe crear o seleccionar un cliente para esta reservacion");
                return;
            }

            try
            {
                bool modificando = false;
                if (venta.ReservacionIda != null)
                {
                    modificando = true;
                    // La reservacion ya existe, esto es una modificacion
                }

                venta.CreateReservacion(modificando);
                tbIDIda.Text = "ID Reservacion: " + venta.ReservacionIda.ID;
                if (venta.ReservacionVuelta != null)
                    tbIDVuelta.Text = "ID Reservacion: " + venta.ReservacionVuelta.ID;

                if (modificando)
                    MessageBox.Show("La reservacion fue modificada satisfactoriamente.");
                else
                    MessageBox.Show("La reservacion fue realizada satisfactoriamente.\nRevise la pestaña correspondiente a cada vuelo para obtener el numero de reservacion");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            UI.ReservacionMain main = new ReservacionMain();
            main.Left = this.Left;
            main.Top = this.Top;
            main.Show();
            this.Close();
        }
    }
}
