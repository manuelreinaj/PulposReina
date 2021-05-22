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
using Microsoft.EntityFrameworkCore;


namespace PulposReina
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : UserControl
    {
        public Clientes()
        {
            InitializeComponent();
            CargarDatos();
            RellenarCombo();
        }

        private void CargarDatos()
        {
            var db = new pulposreinaContext();
            var listadoClientes = db.Clientes
                            .Include(x => x.User)
                            .OrderBy(x => x.Clasificacion)
                            .ToList();

            DataClientes.ItemsSource = listadoClientes;
        }

        private void Button_Back(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Clear();

            Principal prin = new Principal();

            mainGrid.Children.Add(prin);
        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            Store();
        }



        private void RellenarCombo()
        {
            var listCombos = new List<ComboBoxItem>();
            var db = new pulposreinaContext();

            var listadoUser = db.Usuarios.ToList();

            foreach (var user in listadoUser)
            {
                var item = new ComboBoxItem { Content = user.Nombre ,Tag = user.Id };
                listCombos.Add(item);
            }

            DataComerciales.ItemsSource = listCombos;
        }


        private void Store()
        {
            var nombre = NombreBox.Text;
            var email = EmailBox.Text;
            var telefono = TelefonoBox.Text;
            var contacto = ContactoBox.Text;
            var rappel = RappelBox.Text;
            var user = ((ComboBoxItem)DataComerciales.SelectedItem).Tag.ToString();

            if (updater < 0)
            {
                var db = new pulposreinaContext();
                var NuevoCliente = new Models.Cliente { Nombre = nombre, Correo = email, Telefono = int.Parse(telefono), Contacto = contacto, Rappel = float.Parse(rappel), Userid = int.Parse(user) };
                db.Clientes.Add(NuevoCliente);
                db.SaveChanges();

                MessageBox.Show("Nuevo cliente creado con éxito.", "Verificación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                var db = new pulposreinaContext();
                var cliente = db.Clientes.Find(updater);

                cliente.Nombre = nombre;
                cliente.Contacto = contacto;
                db.SaveChanges();
                actualizando = 1;
            }
            VaciarForm();
            CargarDatos();
        }

        private void VaciarForm()
        {
            NombreBox.Text = "";
            EmailBox.Text = "";
            TelefonoBox.Text = "";
            RappelBox.Text = "";
            ContactoBox.Text = "";
        }

        private void RellenarForm(String nombre, String correo, int telefono, float rappel, string contacto, Usuario user)
        {
            NombreBox.Text = nombre;
            EmailBox.Text = correo;
            TelefonoBox.Text = telefono.ToString();
            RappelBox.Text = rappel.ToString();
            ContactoBox.Text = contacto;
            DataComerciales.SelectedIndex = user.Id-1; //El indice recoge el valor de index como si fuera un array por tanto al estar en orden el usuario 1 corresponde al indice 0 
        }

        private void DataClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (actualizando == 0)
            {
                var Current = DataClientes.SelectedItem as Cliente;
                RellenarForm(Current.Nombre, Current.Correo, Current.Telefono, Current.Rappel, Current.Contacto, Current.User);
                GuardarButton.Content = "Actualizar";
                updater = Current.Id;
            }
            actualizando = 0;
        }

        private void NuevoCliente(object sender, RoutedEventArgs e)
        {
            VaciarForm();
            GuardarButton.Content = "Crear";
            updater = -1;
        }

        public int updater;
        public int actualizando;
    }
}
