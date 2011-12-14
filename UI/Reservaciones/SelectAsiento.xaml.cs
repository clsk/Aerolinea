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
using System.Collections.ObjectModel;
using DataLayer;
using BusinessLogic;
using System.IO;

namespace UI.Reservaciones
{
    /// <summary>
    /// Interaction logic for SelectAsiento.xaml
    /// </summary>
    public partial class SelectAsiento : Window
    {
        TransVuelo elVuelo;
        TransAvion elAvion;
        Dictionary<int, Button> losBotones;

        public SelectAsiento(TransVuelo elvuelo)
        {
            losBotones = new Dictionary<int, Button>();
            elVuelo = elvuelo;
            AvionFactory factory = new AvionFactory();
            factory.BuildProduct(elvuelo.Avion.ID);
            elAvion = (TransAvion) factory.GetProduct();
            InitializeComponent();

            for (int i = 0; i < elAvion.Plantas.Count; i++)
            {
                cbPiso.Items.Add(i+1);
            }
            cbPiso.SelectedItem = 0;
            SetImageSource();
            CreateAllBoton();
            InactiveOcupados();
        }
        private void CreateAllBoton()
        {
            List<Asiento> asientos = DALAsiento.GetAsientoFromPisoAvion(elAvion.ID, (int)cbPiso.SelectedItem);
            foreach(Asiento asiento in asientos)
            {
                Button btNew = new Button();
                btNew.Width = 15;
                btNew.Height = 15;
                btNew.Click += new RoutedEventHandler(AsientoClick);
                losBotones.Add(asiento.idAsiento, btNew);
                int posy = asiento.CordX;
                int posx = asiento.CordY;
                //Agregar boton al canvas
                cvsImage.Children.Add(btNew);

                //Setiar posición del boton en el canvas
                Canvas.SetTop(btNew, posy);
                Canvas.SetLeft(btNew, posx);
            }
        }
        private void SetImageSource()
        {
            int elpiso = (int)cbPiso.SelectedItem;
            imgPlanta.Source = ConverToBitMap(elAvion.Plantas[elpiso - 1].Imagen);
            cvsImage.Height = imgPlanta.ActualHeight;
            cvsImage.Width = imgPlanta.ActualWidth;
        }
        private void InactiveOcupados()
        {
            List<Asiento> noOcupados = DALAsiento.GetAsientosNoOcupados(elVuelo.ID);
            foreach (Asiento unAsiento in noOcupados)
            {
                try
                {
                    losBotones[unAsiento.idAsiento].IsEnabled =false;
                }
                catch
                {
                    continue;
                }

            }
        }
        private BitmapImage ConverToBitMap(byte[] bytes)
        {
            MemoryStream byteStream = new MemoryStream(bytes);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = byteStream;
            image.EndInit();
            return image;
        }

        private void ChangePiso()
        {
            cvsImage.Children.Clear();
            losBotones.Clear();
            SetImageSource();
            CreateAllBoton();
            InactiveOcupados();
        }

        private void AsientoClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            MessageBoxResult result = MessageBox.Show(this, "¿Desea seleccionar este asiento?", "Seleccionar asiento", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (result == MessageBoxResult.Yes)
            {
            }
        }

        private void cbPiso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangePiso();
        }
    }
}
