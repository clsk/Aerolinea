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

namespace UI.Administrativo.AdmVuelo
{
    /// <summary>
    /// Interaction logic for AdmVuelo.xaml
    /// </summary>
    public partial class AdmVuelo : Window
    {
        public AdmVuelo()
        {
            InitializeComponent();
        }

        private void btmAtras_Click(object sender, RoutedEventArgs e)
        {
            MainAdm prevWin = new MainAdm();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void btnAddAvion_Click(object sender, RoutedEventArgs e)
        {
            AdmAvion.NewAvion nextWin = new AdmAvion.NewAvion();
            nextWin.Top = this.Top;
            nextWin.Left = this.Left;
            nextWin.Show();
            this.Close();
        }
    }
}
