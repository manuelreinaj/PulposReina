﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace PulposReina
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AbrirLogin();
            MuestraResumen();
        }

        public void MuestraResumen()
        {
        
        }

        public void AbrirLogin()
        {
            mainGrid.Children.Clear();

            Login prin = new Login();

            mainGrid.Children.Add(prin);
        }


        public Grid gridPrin;
    }
}
