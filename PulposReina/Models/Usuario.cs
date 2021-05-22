using System;
using System.Collections.Generic;

#nullable disable

namespace PulposReina.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
