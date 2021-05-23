using System;
using System.Collections.Generic;

#nullable disable

namespace PulposReina.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Contacto { get; set; }
        public float Rappel { get; set; }
        public int Clasificacion { get; set; }
        public int Userid { get; set; }

        public virtual Usuario User { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
