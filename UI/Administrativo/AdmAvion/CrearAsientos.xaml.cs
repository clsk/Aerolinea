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

namespace UI.Administrativo.Adm_Avion
{
    /// <summary>
    /// Interaction logic for CrearAsientos.xaml
    /// </summary>
    public partial class CrearAsientos : Window
    {
        bool FilaIsOk;
        Point TempPoint;
        private List<UIAsiento> Asientos;
        public CrearAsientos()
        {
            InitializeComponent();
            Asientos = new List<UIAsiento>();
            FilaIsOk = false;
            rbtnInsertar.IsChecked = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cvsImage.Height = imgPlanta.ActualHeight;
            cvsImage.Width = imgPlanta.ActualWidth;
        }

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

        private void pupInfos_Opened(object sender, EventArgs e)
        {
            btmGuardar.IsEnabled = false;
        }

        private void btmCancelar_Click(object sender, RoutedEventArgs e)
        {
            svImagen.IsEnabled = true;
            LimpiarPopUp();
        }

        private void btmGuardar_Click(object sender, RoutedEventArgs e)
        {
            int Fila = Int32.Parse(tbFila.Text);
            int posx = Convert.ToInt32(TempPoint.X);
            int posy = Convert.ToInt32(TempPoint.Y);
            Button btNew = new Button();
            btNew.Width = 20;
            btNew.Height = 20;
            btNew.Click += new RoutedEventHandler(AsientoClick);
            UIAsiento asiento = new UIAsiento(posx, posy, Fila, tbNumero.Text, cbClase.SelectedIndex, btNew);
            Asientos.Add(asiento);
            cvsImage.Children.Add(btNew);
            Canvas.SetTop(btNew, TempPoint.Y);
            Canvas.SetLeft(btNew, TempPoint.X);
            btnSave.IsEnabled = true;
            LimpiarPopUp();
        }

        private void LimpiarPopUp()
        {
            tbNumero.Clear();
            pupInfos.IsOpen = false;
            svImagen.IsEnabled = true;
        }

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
        private void AsientoClick(object sender, EventArgs e)
        {
            Button clicked = (Button)sender;
            if (rbtnBorrar.IsChecked == true)
            {
                MessageBoxResult result = MessageBox.Show(this, "¿Desea eliminar este asiento?", "Eliminar asiento", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
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
            else if (rbtnModificar.IsChecked == true)
            {
                for (int i = 0; i < Asientos.Count; i++)
                {
                    if (Asientos[i].UnBoton == clicked)
                    {
                        tbFila.Text = Asientos[i].Fila.ToString();
                        tbNumero.Text = Asientos[i].Numero;
                        cbClase.SelectedIndex = Asientos[i].IdTipoClase;
                        break;
                    }
                }
                pupInfos.IsOpen = true;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
