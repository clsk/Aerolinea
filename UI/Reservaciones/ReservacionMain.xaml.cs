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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for VueloAdmin.xaml
    /// </summary>
    public partial class ReservacionMain : Window
    {
        public ReservacionMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main_window = new MainWindow();
            this.Close();
            main_window.Show();
        }

        private void btBuscarVuelo_Click(object sender, RoutedEventArgs e)
        {
            BuscarVuelo buscar_vuelo = new BuscarVuelo();
            this.Close();
            buscar_vuelo.Show();
        }
    }
}
