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
using Microsoft.Win32;

namespace UI.Administrativo.AdmAvion
{
    /// <summary>
    /// Interaction logic for AddPlano.xaml
    /// </summary>
    public partial class AddPlano : Window
    {
        int elPiso;
        int laCant;
        int idAvion;
        int idSerie;
        BitmapImage bitmap;
        public AddPlano(int Piso, int CantPiso, int idserie, int idavion)
        {
            idAvion = idavion;
            InitializeComponent();
            elPiso = Piso;
            laCant = CantPiso;
            idSerie = idserie;
            bitmap = new BitmapImage();
            tbContar.Text = "Piso " + Piso + "/" + CantPiso;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.InitialDirectory = "c:\\";
                dlg.Filter =
                "Image files (*.jpg)|*.jpg|*.bmp)|*.bmp|All Files (*.*)|*.*";
                dlg.RestoreDirectory = true;
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string selectedFileName = dlg.FileName;
                    FileNameLabel.Content = selectedFileName;
                    bitmap.BeginInit();
                    bitmap.UriSource =
                    new Uri(selectedFileName);
                    bitmap.EndInit();
                    ImageControl.Source = bitmap;
                    btnNewPlano.IsEnabled = true;
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("¡Favor seleccionar una imagen!");
                btnNewPlano.IsEnabled = false;
            }
        }

        private void btnNewPlano_Click(object sender, RoutedEventArgs e)
        {
                CrearAsientos nextWin = new CrearAsientos(idSerie, bitmap, elPiso, laCant, idAvion);
                nextWin.Top = this.Top;
                nextWin.Left = this.Left;
                nextWin.Show();
                this.Close();
        }
    }
}
