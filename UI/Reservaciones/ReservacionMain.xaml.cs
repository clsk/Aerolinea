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

        private void btBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main_window = new MainWindow();
            main_window.Top = this.Top;
            main_window.Left = this.Left;
            this.Close();
            main_window.Show();
        }

        private void btBuscarVuelo_Click(object sender, RoutedEventArgs e)
        {
            BuscarVuelo buscar_vuelo = new BuscarVuelo();
            buscar_vuelo.Top = this.Top;
            buscar_vuelo.Left = this.Left;
            this.Close();
            buscar_vuelo.Show();
        }

        private void btNuevaReservacion_Click(object sender, RoutedEventArgs e)
        {
            NewReservacion new_reservacion = new NewReservacion();
            new_reservacion.Top = this.Top;
            new_reservacion.Left = this.Left;
            this.Close();
            new_reservacion.Show();
        }

        private void btEditarReservacion_Click(object sender, RoutedEventArgs e)
        {
            BuscarReservacion buscar_reservacion = new BuscarReservacion();
            buscar_reservacion.Top = this.Top;
            buscar_reservacion.Left = this.Left;
            this.Close();
            buscar_reservacion.Show();
        }
    }
}
