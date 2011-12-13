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
using System.Collections.ObjectModel;

namespace UI.Administrativo.AdmAvion
{
    /// <summary>
    /// Interaction logic for NewAvion.xaml
    /// </summary>
    public partial class NewAvion : Window
    {
        List<MarcaAvion> lasMarcas;
        ObservableCollection<SerieAvion> seriesAvion;

        public NewAvion()
        {
            InitializeComponent();

            try
            {
                lasMarcas = new List<MarcaAvion>();
                seriesAvion = new ObservableCollection<SerieAvion>();
                Binding bind = new Binding();
                lasMarcas = DALAvion.GetAllMarcaAvion();
                bind.Source = lasMarcas;
                cbMarca_Serie.SetBinding(ComboBox.ItemsSourceProperty, bind);
                cbMarca_Avion.SetBinding(ComboBox.ItemsSourceProperty, bind);
                Binding bind2 = new Binding();
                bind2.Source = seriesAvion;
                cbSerieAvion.SetBinding(ComboBox.ItemsSourceProperty, bind2);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        bool VerifAvion()
        {
            int result;
            if(Int32.TryParse(tbCantidad.Text, out result))
                if((SerieAvion)cbSerieAvion.SelectedItem != null)
                    return true;
            return false;
        }

        bool VerifSerie()
        {
            if(tbNombreSerie.Text!="")
                if((MarcaAvion)cbMarca_Avion.SelectedItem!= null)
                    return true;
            return false;
        }

        bool VerifMarca()
        {
            if(tbNombreMarca.Text != "")
                return true;
            return false;
        }

        private void tbcDestino_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabAvion.IsSelected)
            {
                btnNewAvion.IsEnabled = VerifAvion();
            }

            if (tabSerie.IsSelected)
            {
                btnNewAvion.IsEnabled = VerifSerie();
            }

            if (tabMarca.IsSelected)
            {
                btnNewAvion.IsEnabled = VerifMarca();
            }
        }

        private void tbNombreMarca_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewAvion.IsEnabled = VerifMarca();
        }

        private void tbNombreSerie_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewAvion.IsEnabled = VerifSerie();
        }

        private void tbCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnNewAvion.IsEnabled = VerifAvion();
        }

        private void btmAtras_Click(object sender, RoutedEventArgs e)
        {
            AdmVuelo.AdmVuelo prevWin = new AdmVuelo.AdmVuelo();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Hide();
        }

        private void btnNewAvion_Click(object sender, RoutedEventArgs e)
        {
            if (tabAvion.IsSelected)
            {
                int pisos = Int32.Parse(tbCantidad.Text);
                SerieAvion unaSerie = (SerieAvion)cbSerieAvion.SelectedItem;
                AddPlano nextWin = new AddPlano(1, pisos, unaSerie.idSerie);
                nextWin.Top = this.Top;
                nextWin.Left = this.Left;
                nextWin.Show();
                this.Close();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ChangeSeriesFromMarca();
        }

        void ChangeSeriesFromMarca()
        {
            seriesAvion.Clear();
            MarcaAvion unaMarca = (MarcaAvion)cbMarca_Avion.SelectedItem;
            List<SerieAvion> lasSeries = DALAvion.GetSerieAvionFromMarcaAvion(unaMarca.idMarca);
            foreach (SerieAvion unAvion in lasSeries)
                seriesAvion.Add(unAvion);
        }

        private void cbMarca_Avion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeSeriesFromMarca();
        }
    }
}
