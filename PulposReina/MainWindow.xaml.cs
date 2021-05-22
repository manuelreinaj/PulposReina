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
            AbrirPrincipal();
            MuestraClientes();
        }

        public void MuestraClientes()
        {
        
        }

        public void AbrirPrincipal()
        {
            mainGrid.Children.Clear();

            Principal prin = new Principal();

            mainGrid.Children.Add(prin);
        }

        public Grid gridPrin;
    }
}
