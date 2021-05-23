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
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String username = UserBox.Text;
            String password = PassBox.Text;
            //Encripto lo qu eme ha dado el usuario para compararlo
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
            result = Convert.ToBase64String(encryted);

            var db = new pulposreinaContext();
            var usuario = db.Usuarios.Where(user => user.Username == username && user.Pass == result);
            
            if (usuario.Any())
            {
                AbrirPrincipal();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void AbrirPrincipal()
        {
            mainGrid.Children.Clear();

            Principal prin = new Principal();

            mainGrid.Children.Add(prin);
        }
    }
}
