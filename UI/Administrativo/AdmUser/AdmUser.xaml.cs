﻿using System;
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

namespace UI.Administrativo.AdmUser
{
    /// <summary>
    /// Interaction logic for AdmUser.xaml
    /// </summary>
    public partial class AdmUser : Window
    {
        public AdmUser()
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

        private void btmNewUser_Click(object sender, RoutedEventArgs e)
        {
            NewUser nextWin = new NewUser();
            nextWin.Top = this.Top;
            nextWin.Left = this.Left;
            nextWin.Show();
            this.Close();
        }

        private void btmEditUser_Click(object sender, RoutedEventArgs e)
        {
            BuscarUser nextWin = new BuscarUser();
            nextWin.Top = this.Top;
            nextWin.Left = this.Left;
            nextWin.Show();
            this.Close();
        }
    }
}
