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
using System.Collections;

namespace PulposReina
{
    /// <summary>
    /// Lógica de interacción para Principal.xaml
    /// </summary>
    public partial class Principal : UserControl
    {
        public Principal()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void Pedidos_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            Pedidos ped = new Pedidos();

            mainGrid.Children.Add(ped);
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            Clientes cli = new Clientes();

            mainGrid.Children.Add(cli);
        }

        private void Articulos_Click(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            Articulos cli = new Articulos();

            mainGrid.Children.Add(cli);
        }

        private void CargarDatos()
        {
            List<ItemRanking> listado = new List<ItemRanking>();

            var db = new pulposreinaContext();
            var listadoUsuarios = db.Usuarios.ToList();

            foreach (var user in listadoUsuarios)
            {
                float ventas = 0;
                float bestVenta = 0;
                var sumaPedidos = 0;
                var sumaOfertas = 0;
                Cliente bestCliente;
                DateTime ultimaFecha = DateTime.Now.AddDays(-5000);
                DateTime ultimaFechaOf = DateTime.Now.AddDays(-5000);
                var listadoClientes = db.Clientes.Where(x => x.Userid == user.Id).ToList();

                foreach (var cli in listadoClientes)
                {
                    var sumaPrecios = db.Pedidos.Where(x => x.Clienteid == cli.Id && x.Oferta == 0).GroupBy(c => c.Clienteid)
                                                .Select(cl => new Pedido
                                                {
                                                    Precio = cl.Sum(c => c.Precio)
                                                }).ToList();

                    sumaPedidos += db.Pedidos.Where(x => x.Clienteid == cli.Id && x.Oferta == 0).Count();
                    sumaOfertas += db.Pedidos.Where(x => x.Clienteid == cli.Id && x.Oferta == 1).Count();

                    var fechas = db.Pedidos.Where(x => x.Clienteid == cli.Id && x.Oferta == 0).GroupBy(c => c.Clienteid)
                                                .Select(cl => new Pedido
                                                {
                                                    Fecha = cl.Max(c => c.Fecha)
                                                }).ToList();
                    
                    foreach (var fechaPed in fechas)
                    {
                        if (ultimaFecha.CompareTo(fechaPed.Fecha) < 0)
                            ultimaFecha = fechaPed.Fecha;
                    }

                    var fechasOferta = db.Pedidos.Where(x => x.Clienteid == cli.Id && x.Oferta == 0).GroupBy(c => c.Clienteid)
                                                .Select(cl => new Pedido
                                                {
                                                    Fecha = cl.Max(c => c.Fecha)
                                                }).ToList();

                    foreach (var fechaOf in fechasOferta)
                    {
                        if (ultimaFechaOf.CompareTo(fechaOf.Fecha) < 0)
                            ultimaFechaOf = fechaOf.Fecha;
                    }

                    foreach (var ped in sumaPrecios)
                    {
                        ventas += ped.Precio;

                        if (bestVenta < ped.Precio)
                        {
                            bestCliente = cli;
                            bestVenta = ped.Precio;
                        }
                    }
                }

                listado.Add(new ItemRanking{ Nombre = user.Nombre, Total = ventas.ToString(), Pedidos = sumaPedidos, Ofertas = sumaOfertas,
                                            UPedido = ultimaFecha.ToString(format: "dd-MM-yyyy"), UOferta = ultimaFechaOf.ToString(format: "dd-MM-yyyy")
                });
            }
            DataArticulos.ItemsSource = listado.OrderBy(o => o.Total).ToList();
        }

        public class ItemRanking
        {

            public String Nombre { get; set; }
            public String Total { get; set; }    
            public int Pedidos { get; set; }
            public int Ofertas { get; set; }
            public String UPedido { get; set; }
            public String UOferta { get; set; }

        }
    }
}
