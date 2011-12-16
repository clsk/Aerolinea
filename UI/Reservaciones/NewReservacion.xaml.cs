using System;
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
            if (venta.VueloVuelta != null)
            {
                SetVueloVuelta(venta.VueloVuelta);
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
            tiVueloIda.Background = Brushes.Green;
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
            tiVueloRegreso.Background = Brushes.Green;
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
            SelectAsiento select_asiento = new SelectAsiento(venta.VueloIda);
            select_asiento.Left = this.Left;
            select_asiento.Top = this.Top;
            select_asiento.ShowDialog();
        }

        private void btAsignarAsientoIdaVuelta_Click(object sender, RoutedEventArgs e)
        {


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

        private void btGuardar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
