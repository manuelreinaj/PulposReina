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
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
using PulposReina.Models;
using System.Linq;
using System.Diagnostics;


namespace PulposReina
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        public Clientes(MySqlConnection conn)
        {
            InitializeComponent();

            this.conn = conn;

            cargarDatos();

        }

        private void cargarDatos()
        {
            var db = new pulposreinaContext();
            DataClientes.ItemsSource = db.Clientes.ToList();
        }

        MySqlConnection conn;
    }
}
