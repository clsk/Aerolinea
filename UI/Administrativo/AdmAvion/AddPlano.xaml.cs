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
using BusinessLogic;
using System.IO;

namespace UI.Administrativo.AdmAvion
{
    /// <summary>
    /// Interaction logic for AddPlano.xaml
    /// </summary>
    public partial class AddPlano : Window
    {
        int elPiso;
        BitmapImage bitmap;
        LAvion elAvion;
        public AddPlano(LAvion elavion, int piso)
        {
            bitmap = new BitmapImage();
            elAvion = elavion;
            elPiso = piso;
            InitializeComponent();
            tbContar.Text = "Piso " + piso + "/" + elavion.Cantidad;
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
                dlg.RestoreDirectory =
                true;
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    string selectedFileName = dlg.FileName;
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
        private byte[] getJPG_Byte(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();              
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }

        private void btnNewPlano_Click(object sender, RoutedEventArgs e)
        {
            byte[] imagen = getJPG_Byte(bitmap);
            elAvion.addPlanta(imagen);
            CrearAsientos nextWin = new CrearAsientos(elAvion, bitmap, elPiso);
            nextWin.Top = this.Top;
            nextWin.Left = this.Left;
            nextWin.Show();
            this.Close();
        }
    }
}
