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
namespace UI.Administrativo.AdmAvion
{
    /// <summary>
    /// Interaction logic for CrearAsientos.xaml
    /// </summary>
    public partial class CrearAsientos : Window
    {
        int idSerie;
        int idAvion;
        int Piso;
        int cantPiso;
        bool FilaIsOk;
        Point TempPoint;
        List<TipoClase> lasClases;
        List<UIAsiento> Asientos;
        public CrearAsientos(int idserie, BitmapImage bitimage, int piso, int cantpiso)
        {
            idAvion = -1;
            idSerie = idserie;
            Piso = piso;
            cantPiso = cantpiso;
            InitializeComponent();
            Asientos = new List<UIAsiento>();
            FilaIsOk = false;
            rbtnInsertar.IsChecked = true;
            lasClases = DALAsiento.GetAllTipoClases();
            Binding binding = new Binding();
            binding.Source = lasClases;
            cbClase.SetBinding(ComboBox.ItemsSourceProperty, binding);
            imgPlanta.Source = bitimage;
        }
        public CrearAsientos(BitmapImage bitimage, int piso, int cantpiso, int idavion)
        {
            idAvion = idavion;
            Piso = piso;
            cantPiso = cantpiso;
            InitializeComponent();
            Asientos = new List<UIAsiento>();
            FilaIsOk = false;
            rbtnInsertar.IsChecked = true;
            lasClases = DALAsiento.GetAllTipoClases();
            Binding binding = new Binding();
            binding.Source = lasClases;
            cbClase.SetBinding(ComboBox.ItemsSourceProperty, binding);
            imgPlanta.Source = bitimage;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Asigna el tamaño del canvas para el tamaño de la imagen cargada.
            cvsImage.Height = imgPlanta.ActualHeight;
            cvsImage.Width = imgPlanta.ActualWidth;
        }

        //Obtiene el click adentro del canvas para empezar el proceso de crear asiento.
        private void cvsImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rbtnInsertar.IsChecked == true)
            {
                pupInfos.IsOpen = true;
                TempPoint = e.GetPosition(cvsImage);
                svImagen.IsEnabled = false;
            }
            else if(rbtnBorrar.IsChecked == true)
                MessageBox.Show(this, "Favor hacer click en el asiento que desea eliminar.", "Acción invalida", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Cancel);
            else
                MessageBox.Show(this, "Favor hacer click en el asiento que desea modificar.", "Acción invalida", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Cancel);
        }

        //Al abrir el popUp este tiene el boton de guardar desabilitado (campo de número estará vacio).
        private void pupInfos_Opened(object sender, EventArgs e)
        {
            btmGuardar.IsEnabled = false;
        }

        //Habilitar el canvas y cerrar el popUp
        private void btmCancelar_Click(object sender, RoutedEventArgs e)
        {
            svImagen.IsEnabled = true;
            LimpiarPopUp();
        }

        //Guarda el nuevo asiento en la lista y además agrega un boton al Canvas
        private void btmGuardar_Click(object sender, RoutedEventArgs e)
        {
            //Informaciones del asiento
            int Fila = Int32.Parse(tbFila.Text);
            int posx = Convert.ToInt32(TempPoint.X);
            int posy = Convert.ToInt32(TempPoint.Y);

            //Creando el boton que será agregado al canvas
            Button btNew = new Button();
            btNew.Width = 20;
            btNew.Height = 20;
            btNew.Click += new RoutedEventHandler(AsientoClick);

            //Obtener ID del TipoAsiento
            TipoClase unTipoAsiento = (TipoClase)cbClase.SelectedItem;

            //Agregando asiento a la lista
            UIAsiento asiento = new UIAsiento(posx, posy, Fila, tbNumero.Text, unTipoAsiento.idTipoClase, btNew);
            Asientos.Add(asiento);
            
            //Agregar boton al canvas
            cvsImage.Children.Add(btNew);

            //Setiar posición del boton en el canvas
            Canvas.SetTop(btNew, TempPoint.Y);
            Canvas.SetLeft(btNew, TempPoint.X);

            //Luego de agregar un boton ya se puede salvar
            btnSave.IsEnabled = true;

            LimpiarPopUp();
        }

        //Limpia el popUp, lo cierra y habilita el canvas
        private void LimpiarPopUp()
        {
            tbNumero.Clear();
            pupInfos.IsOpen = false;
            svImagen.IsEnabled = true;
        }

        //Validar cambio en el campo Fila
        private void tbFila_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            if (Int32.TryParse(tbFila.Text, out result))
            {
                FilaIsOk = true;
                if (tbNumero.Text != "")
                {
                    btmGuardar.IsEnabled = true;
                }
            }
            else
            {
                btmGuardar.IsEnabled = false;
                FilaIsOk = false;
            }
        }

        //Validar el cambio en el campo Numero
        private void tbNumero_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbNumero.Text != "" && FilaIsOk)
            {
                btmGuardar.IsEnabled = true;
            }
            else
                btmGuardar.IsEnabled = false;
        }

        private void svImagen_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

        }
        //Evento generico para todos los botones agregados
        private void AsientoClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;

            //Verifica si está seleccionado ELIMINAR
            if (rbtnBorrar.IsChecked == true)
            {
                //Preguntar si desea borrar
                MessageBoxResult result = MessageBox.Show(this, "¿Desea eliminar este asiento?", "Eliminar asiento", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    //Buscar boton en la lista y borrarlo
                    for (int i = 0; i < Asientos.Count; i++)
                    {
                        if (Asientos[i].UnBoton == clicked)
                        {
                            cvsImage.Children.Remove(Asientos[i].UnBoton);
                            Asientos.RemoveAt(i);
                            break;
                        }
                    }
                    if (Asientos.Count < 1)
                        btnSave.IsEnabled = false;
                }
            }
            //Verificar si está seleccionado MODIFICAR
            else if (rbtnModificar.IsChecked == true)
            {
                //Buscar boton en la lista
                for (int i = 0; i < Asientos.Count; i++)
                {
                    //Poner informaciones en los campos del popup
                    if (Asientos[i].UnBoton == clicked)
                    {
                        tbFila.Text = Asientos[i].Fila.ToString();
                        tbNumero.Text = Asientos[i].Numero;
                        for(int j=0;;j++)
                        {
                            cbClase.SelectedIndex = j;
                            TipoClase tempClase = (TipoClase)cbClase.SelectedItem;
                            if (Asientos[i].IdTipoClase == tempClase.idTipoClase)
                                break;
                        }
                        break;
                    }
                }
                //Abrir popup
                pupInfos.IsOpen = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //No se ha construido el avion
            if (idAvion == -1)
            {
                //Si ya se construyeron todos los pisos, volver al meno.
                if (Piso == cantPiso)
                    OpenNewAvion();
                else
                    OpenAddPlano();
            }
            else
            {
                //Si ya se construyeron todos los pisos, volver al menu
                if (Piso == cantPiso)
                    OpenNewAvion();
                else
                    OpenAddPlano();
            }
        }
        private void OpenNewAvion()
        {
            NewAvion prevWin = new NewAvion();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void OpenAddPlano()
        {
            AddPlano prevWin = new AddPlano(idAvion, Piso++, cantPiso, false);
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }
        private void cbClase_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int result;
            if (Int32.TryParse(tbFila.Text, out result))
            {
                FilaIsOk = true;
                if (tbNumero.Text != "")
                {
                    btmGuardar.IsEnabled = true;
                }
            }
            else
            {
                btmGuardar.IsEnabled = false;
                FilaIsOk = false;
            }
        }
    }
}
