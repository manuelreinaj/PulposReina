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
    /// Lógica de interacción para CreatePedido.xaml
    /// </summary>
    public partial class CreatePedido : UserControl
    {
        public CreatePedido()
        {
            InitializeComponent();
            CargarClientes();
            CargarArticulos();
        }

        private void CargarClientes()
        {
            var listCombos = new List<ComboBoxItem>();
            var db = new pulposreinaContext();

            var listadoClientes = db.Clientes.ToList();

            foreach (var cli in listadoClientes)
            {
                var item = new ComboBoxItem { Content = cli.Nombre, Tag = cli.Id };
                listCombos.Add(item);
            }

            ComboCliente.ItemsSource = listCombos;
        }

        private void CargarArticulos()
        {
            var listCombos = new List<ComboBoxItem>();
            var db = new pulposreinaContext();

            var listadoArticulos = db.Articulos.ToList();

            foreach (var art in listadoArticulos)
            {
                var item = new ComboBoxItem { Content = art.Nombre, Tag = art.Id };
                listCombos.Add(item);
            }

            ComboArticulo.ItemsSource = listCombos;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            AbrirPedidos();
        }

        private void AbrirPedidos()
        {
            mainGrid.Children.Clear();

            Pedidos ped = new Pedidos();

            mainGrid.Children.Add(ped);
        }

        private void VaciarForm()
        {
            ComboArticulo.SelectedIndex = 0;
            ComboCliente.SelectedIndex = 0;
            UnidadesBox.Text = "";
            PrecioBox.Text = "";
        }

        private void Store()
        {
            var clienteId = ((ComboBoxItem)ComboCliente.SelectedItem).Tag.ToString();
            var articuloId = ((ComboBoxItem)ComboArticulo.SelectedItem).Tag.ToString();
            var unidades = UnidadesBox.Text;
            var precio = PrecioBox.Text;
            var fecha = DatePedido.SelectedDate.Value.Date;
            var oferta = 0;

            if (OfertaCheckBox.IsChecked == true)
                oferta = 1;

            //Aqui deberian ir las comprobaciones

            var db = new pulposreinaContext();
            var pedido = new Models.Pedido { Clienteid = int.Parse(clienteId), Articuloid = int.Parse(articuloId), Unidades = int.Parse(unidades), Precio = int.Parse(precio), Oferta = oferta, Fecha = fecha };
            db.Pedidos.Add(pedido);
            db.SaveChanges();

            MessageBox.Show("Nuevo pedido creado con éxito.", "Verificación", MessageBoxButton.OK, MessageBoxImage.Information);

            VaciarForm();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            Store();
        }
    }
}
