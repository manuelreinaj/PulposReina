using System;
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
using PulposReina.Models;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PulposReina
{
    /// <summary>
    /// Lógica de interacción para Articulos.xaml
    /// </summary>
    public partial class Articulos : UserControl
    {
        public Articulos()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            Principal prin = new Principal();

            mainGrid.Children.Add(prin);
        }

        private void CargarDatos()
        {
            var db = new pulposreinaContext();
            var listadoArticulos = db.Articulos.ToList();

            DataArticulos.ItemsSource = listadoArticulos;
        }
    }
}
