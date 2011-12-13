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
using BusinessLogic;

namespace UI
{
    /// <summary>
    /// Interaction logic for VueloAdmin.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title += " " + LUser.GetInstance().Nombre + " (" + LUser.GetInstance().NombreNivel + ")";

            // Restrict View based on level;
            if (Permission.CheckSupervisor() == false)
                btAdministracion.IsEnabled = false;
        }

        private void btReservaciones_Click(object sender, RoutedEventArgs e)
        {
            ReservacionMain reservacion_main = new ReservacionMain();
            reservacion_main.Top = this.Top;
            reservacion_main.Left = this.Left;
            reservacion_main.Show();
            this.Close();
        }

        private void btAdministracion_Click(object sender, RoutedEventArgs e)
        {
            Administrativo.MainAdm admin_main = new Administrativo.MainAdm();
            admin_main.Top = this.Top;
            admin_main.Left = this.Left;
            admin_main.Show();
            this.Close();
        }
    }
}
