using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PulposReina
{
    public class Connection
    {
        public static MySqlConnection Conn()
        {
            MySqlConnection conexion = new MySqlConnection();
            conexion.ConnectionString = "Server=localhost;Database=pulposreina; Uid=root;Pwd=;";
            conexion.Open();

            return conexion;
        }
    }
}
