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
        BitmapImage bitmap;

        public SelectAsiento(TransVuelo elvuelo)
        {
            bitmap = new BitmapImage();
            losBotones = new Dictionary<int, Button>();
            elVuelo = elvuelo;
            AvionFactory factory = new AvionFactory();
            factory.BuildProduct(elvuelo.Avion.ID);
            elAvion = (TransAvion) factory.GetProduct();
            InitializeComponent();

           /* for (int i = 0; i < elAvion.Plantas.Count; i++)
            {
                string j;
                j = Convert.ToString(i+1);
                cbPiso.Items.Add(j);
            }*/
            cbPiso.SelectedItem = 0;
            SetImageSource();
            CreateAllBoton();
            InactiveOcupados();
        }

        /// <summary>
        /// Crea todos lo botones de los asientos en el Canvas.
        /// </summary>
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

        /// <summary>
        /// Pone la imagen correspondiente en el canvas.
        /// </summary>
        private void SetImageSource()
        {
            int elpiso = cbPiso.SelectedIndex;
            bitmap.BeginInit();
            bitmap.UriSource =
            new Uri(elAvion.Plantas[elpiso].URL);
            bitmap.EndInit();
            imgPlanta.Source = bitmap;
            cvsImage.Height = imgPlanta.ActualHeight;
            cvsImage.Width = imgPlanta.ActualWidth;
        }

        /// <summary>
        /// Inactiva los asientos que están ocupados.
        /// </summary>
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

        /// <summary>
        /// Hace el cambio de piso, cargando los nuevos datos.
        /// </summary>
        private void ChangePiso()
        {
            cvsImage.Children.Clear();
            losBotones.Clear();
            SetImageSource();
            CreateAllBoton();
            InactiveOcupados();
        }

        /// <summary>
        /// Confirma si el usuario desea seleccionar ese asiento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
