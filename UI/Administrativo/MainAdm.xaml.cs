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

namespace UI.Administrativo
{
    /// <summary>
    /// Interaction logic for MainAdm.xaml
    /// </summary>
    public partial class MainAdm : Window
    {
        public MainAdm()
        {
            InitializeComponent();
        }

        private void btmAtras_Click(object sender, RoutedEventArgs e)
        {
            MainWindow prevWin = new MainWindow();
            prevWin.Top = this.Top;
            prevWin.Left = this.Left;
            prevWin.Show();
            this.Close();
        }

        private void btnAdmVuelo_Click(object sender, RoutedEventArgs e)
        {
            AdmVuelo.AdmVuelo nextWin = new AdmVuelo.AdmVuelo();
            nextWin.Top = this.Top;
            nextWin.Left = this.Left;
            nextWin.Show();
            this.Close();
        }

        private void btnAdmUser_Click(object sender, RoutedEventArgs e)
        {
            AdmUser.AdmUser nextWin = new AdmUser.AdmUser();
            nextWin.Top = this.Top;
            nextWin.Left = this.Left;
            nextWin.Show();
            this.Close();

        }
    }
}
