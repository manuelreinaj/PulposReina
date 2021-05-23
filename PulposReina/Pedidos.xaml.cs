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
using System.Runtime.InteropServices;

namespace PulposReina
{
    /// <summary>
    /// Lógica de interacción para Pedidos.xaml
    /// </summary>
    public partial class Pedidos : UserControl
    {
        public Pedidos()
        {
            InitializeComponent();
            TiempoCombo.SelectedIndex = 4;
        }

        private void CargarPedidos(DateTime fecha, int inloop, int ofertas)
        {
 
            var db = new pulposreinaContext();
            var listadoPedidos = db.Pedidos.ToList();
            
            if (inloop != 0)
            {
                listadoPedidos = db.Pedidos
                            .Include(x => x.Articulo)
                            .Include(x => x.Cliente)
                            .Include(x => x.Cliente.User)
                            .Where(x => x.Oferta == ofertas)
                            .OrderByDescending(x => x.Fecha)
                            .ToList();

            for (int i = listadoPedidos.Count - 1; i >= 0; i--)
            {
                if (fecha.Date.CompareTo(listadoPedidos[i].Fecha) > 0)
                    listadoPedidos.RemoveAt(i);
            }

            }
            else
            {
                 listadoPedidos= db.Pedidos
                        .Include(x => x.Articulo)
                        .Include(x => x.Cliente)
                        .Include(x => x.Cliente.User)
                        .Where(x => x.Oferta == ofertas)
                        .OrderByDescending(x => x.Fecha)
                        .ToList();
            }

            if (ofertas == 1)
                TituloLabel.Content = "OFERTAS";
            else
                TituloLabel.Content = "PEDIDOS";

            DataPedidos.ItemsSource = listadoPedidos;
            
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            Principal prin = new Principal();

            mainGrid.Children.Add(prin);
        }

        private void OfertasButton_Click(object sender, RoutedEventArgs e)
        {

            var timeChange = DateTime.Now;
            var comp = 1;
            ofertas = 1;

            if (TiempoCombo.SelectedIndex == 0)
            {
                timeChange = DateTime.Now.AddDays(-15);
            }
            if (TiempoCombo.SelectedIndex == 1)
            {
                timeChange = DateTime.Now.AddDays(-30);
            }
            if (TiempoCombo.SelectedIndex == 2)
            {
                timeChange = DateTime.Now.AddDays(-60);
            }
            if (TiempoCombo.SelectedIndex == 3)
            {
                timeChange = DateTime.Now.AddDays(-90);
            }
            if (TiempoCombo.SelectedIndex == 4)
            {
                comp = 0;
            }
            CargarPedidos(timeChange, comp, ofertas);
        }

        private void PedidosButton_Click(object sender, RoutedEventArgs e)
        {
            var timeChange = DateTime.Now;
            var comp = 1;
            ofertas = 0;

            if (TiempoCombo.SelectedIndex == 0)
            {
                timeChange = DateTime.Now.AddDays(-15);
            }
            if (TiempoCombo.SelectedIndex == 1)
            {
                timeChange = DateTime.Now.AddDays(-30);
            }
            if (TiempoCombo.SelectedIndex == 2)
            {
                timeChange = DateTime.Now.AddDays(-60);
            }
            if (TiempoCombo.SelectedIndex == 3)
            {
                timeChange = DateTime.Now.AddDays(-90);
            }
            if (TiempoCombo.SelectedIndex == 4)
            {
                comp = 0;
            }

            CargarPedidos(timeChange, comp, ofertas);
        }

        private void TiempoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var timeChange = DateTime.Now;
            var comp = 1;

            if (TiempoCombo.SelectedIndex == 0)
            {
                timeChange = DateTime.Now.AddDays(-15);
            }
            if (TiempoCombo.SelectedIndex == 1)
            {
                timeChange = DateTime.Now.AddDays(-30);
            }
            if (TiempoCombo.SelectedIndex == 2)
            {
                timeChange = DateTime.Now.AddDays(-60);
            }
            if (TiempoCombo.SelectedIndex == 3)
            {
                timeChange = DateTime.Now.AddDays(-90);
            }
            if (TiempoCombo.SelectedIndex == 4)
            {
                comp = 0;
            }

            CargarPedidos(timeChange, comp, ofertas);
        }

        public int ofertas = 0;

        private void correo_enviar_Click(object sender, RoutedEventArgs e)
        {
            Pedido ped = ((FrameworkElement)sender).DataContext as Pedido;

            MessageBox.Show(ped.Cliente.Correo);

        }

        private void NuevoPedido_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            CreatePedido ped = new CreatePedido();

            mainGrid.Children.Add(ped);
        }
    }
}
