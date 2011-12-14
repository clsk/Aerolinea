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

namespace UI.Administrativo.AdmVuelo
{
    /// <summary>
    /// Interaction logic for NewVuelo.xaml
    /// </summary>
    public partial class NewVuelo : Window
    {
        List<MarcaAvion> marcas;
        ObservableCollection<SerieAvion> series;
        ObservableCollection<Avion> aviones;
        ObservableCollection<unPrecio> precios;
        public NewVuelo()
        {
            InitializeComponent();

            marcas = new List<MarcaAvion>();
            marcas = DALAvion.GetAllMarcaAvion();
            Binding binding = new Binding();
            binding.Source = marcas;
            cbMarca.SetBinding(ComboBox.ItemsSourceProperty, binding);

            series = new ObservableCollection<SerieAvion>();
            Binding bind = new Binding();
            bind.Source = series;
            cbSerie.SetBinding(ComboBox.ItemsSourceProperty, bind);

            aviones = new ObservableCollection<Avion>();
            Binding bind1 = new Binding();
            bind1.Source = aviones;
            cbAvion.SetBinding(ComboBox.ItemsSourceProperty, bind1);

            precios = new ObservableCollection<unPrecio>();
            Binding bind2 = new Binding();
            bind2.Source = precios;
            cbPrecios.SetBinding(ComboBox.ItemsSourceProperty, bind2);
            InitializeComponent();
        }
        private bool verifFecha()
        {
            if (dpLlegada.SelectedDate != null)
                if (dpSalida.SelectedDate != null)
                    if (dpLlegada.SelectedDate >= dpSalida.SelectedDate)
                        if(tpLlegada.SelectedTime> tpSalida.SelectedTime)
                            return true;
            return false;
        }
        private void EstadoDestino(bool estado)
        {
            cbMarca.IsEnabled = estado;
            cbAvion.IsEnabled = estado;
            cbSerie.IsEnabled = estado;
        }
        private void dpSalida_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EstadoDestino(verifFecha());
        }

        private void dpLlegada_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EstadoDestino(verifFecha());
        }

        private void tpSalida_SelectedTimeChanged(object sender, AC.AvalonControlsLibrary.Controls.TimeSelectedChangedRoutedEventArgs e)
        {
            EstadoDestino(verifFecha());
        }

        private void tpLlegada_SelectedTimeChanged(object sender, AC.AvalonControlsLibrary.Controls.TimeSelectedChangedRoutedEventArgs e)
        {
            EstadoDestino(verifFecha());
        }

        private void cbMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            series.Clear();
            MarcaAvion marca = (MarcaAvion)cbMarca.SelectedItem;
            foreach(SerieAvion serie in DALAvion.GetSerieAvionFromMarcaAvion(marca.idMarca))
                series.Add(serie);
        }

        private void cbSerie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            aviones.Clear();
            SerieAvion serie = (SerieAvion)cbSerie.SelectedItem;
            DateTime Fsalida = (DateTime)dpSalida.SelectedDate;
            DateTime Flllegada = (DateTime)dpLlegada.SelectedDate;
            TimeSpan Tsalida = (TimeSpan) tpSalida.SelectedTime;
            TimeSpan Tllegada = (TimeSpan) tpLlegada.SelectedTime;
            foreach (Avion avion in DALAvion.GetAvionesDisponibles(Fsalida, Flllegada, Tsalida, Tllegada, serie.idSerie))
                aviones.Add(avion);
        }

        private void cbAvion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbPrecios.IsEnabled = true;
            tbPrecios.IsEnabled = true;
            btnAplicar.IsEnabled = true;
            Avion avion =  (Avion)cbAvion.SelectedItem;
            foreach (TipoClase clase in DALAsiento.GetAllTipoClasesFromAvion(avion.idAvion))
            {
                unPrecio price = new unPrecio(clase, -1);
                precios.Add(price);
            }
        }
    }
    public class unPrecio
    {
        public unPrecio(TipoClase clase, double price)
        {
            unaclase = clase;
            precio = price;
        }
        TipoClase unaclase;

        public TipoClase Unaclase
        {
            get { return unaclase; }
            set { unaclase = value; }
        }

        double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
    }
}
