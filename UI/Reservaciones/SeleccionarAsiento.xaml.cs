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
using BusinessLogic;
namespace UI.Reservaciones
{
    /// <summary>
    /// Interaction logic for SeleccionarAsiento.xaml
    /// </summary>
    public partial class SeleccionarAsiento : Window
    {
        TransVuelo elVuelo;
        TransAvion elAvion;
        List<unAsiento> losAsientos;
        
        int elPiso;
        Action<TransAsiento> callback;
        public SeleccionarAsiento(TransVuelo unVuelo, Action<TransAsiento> _callback)
        {
            callback = _callback;
            elVuelo = unVuelo;
            losAsientos = new List<unAsiento>();
            AvionFactory factory = new AvionFactory();
            factory.BuildProduct(unVuelo.Avion.ID);
            elAvion = (TransAvion)factory.GetProduct();
            InitializeComponent();
            for (int i = 0; i < elAvion.Plantas.Count; i++)
            {
                string piso = Convert.ToString(i+1);
                cbPisos.Items.Add(piso);
            }
            cbPisos.SelectedIndex = 0;
            elPiso = 0;
            LoadImage();
            LoadAsientos();
            InabAsientos();

        }

        public void LoadImage()
        {
            BitmapImage laImagen;
            laImagen = new BitmapImage();
            laImagen.BeginInit();
            laImagen.UriSource = new Uri(elAvion.Plantas[elPiso].URL);
            imgPlanta.Source = laImagen;
            laImagen.EndInit();
            cnvImg.Height = laImagen.Height;
            cnvImg.Width = laImagen.Width;
        }

        public void LoadAsientos()
        {
            List<Asiento> asientos = DALAsiento.GetAsientoFromPisoAvion(elAvion.ID, elPiso);
            foreach (Asiento unasiento in asientos)
            {
                Button btNew = new Button();
                btNew.Width = 15;
                btNew.Height = 15;
                btNew.IsEnabled = false;
                btNew.Click += new RoutedEventHandler(AsientoClick);
                unAsiento elasiento = new unAsiento(unasiento.idAsiento, btNew);
                losAsientos.Add(elasiento);

                cnvImg.Children.Add(btNew);

                Canvas.SetTop(btNew, unasiento.CordY);
                Canvas.SetLeft(btNew, unasiento.CordX);
            }

        }
        public void InabAsientos()
        {
            List<Asiento> asientos = DALAsiento.GetAsientosNoOcupados(elVuelo.ID);
            foreach (Asiento unasiento in asientos)
            {
                foreach (unAsiento asiento in losAsientos)
                {
                    if (unasiento.idAsiento == asiento.id)
                    {
                        asiento.UnBoton.IsEnabled = true;
                    }
                }
            }
        }

        private void PisoChanged()
        {
            elPiso = cbPisos.SelectedIndex;
            foreach (unAsiento asiento in losAsientos)
                cnvImg.Children.Remove(asiento.UnBoton);
            losAsientos.Clear();
            LoadImage();
            LoadAsientos();
            InabAsientos();
        }

        private void AsientoClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            MessageBoxResult result = MessageBox.Show(this, "¿Desea seleccionar este asiento?", "Seleccionar asiento", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
                foreach (unAsiento asiento in losAsientos)
                {
                    if (asiento.UnBoton == clicked)
                    {
                        callback(new TransAsiento(DALAsiento.GetAsientoFromID(asiento.id)));
                        this.Close();
                        break;
                    }
                }
            }
        }

        private void cbPisos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PisoChanged();
        }
    }

    public class unAsiento
    {
        public unAsiento(int id, Button elboton)
        {
            ID = id;
            unBoton = elboton;
        }
        int ID;

        public int id
        {
            get { return ID; }
            set { ID = value; }
        }

        Button unBoton;

        public Button UnBoton
        {
            get { return unBoton; }
            set { unBoton = value; }
        }
    }
}
