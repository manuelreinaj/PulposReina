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
            conn = Connection.Conn();
            MuestraClientes();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
            
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {

        }

        public void MuestraClientes()
        {
            using (var resul = new MySqlCommand("SELECT * FROM clientes", conn))
            {
                using (var reader = resul.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            textprueba.Text += reader.GetString(1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                }
            }
        }

        MySqlConnection conn;
    }
}
