using System;
using System.Collections.Generic;

#nullable disable

namespace PulposReina.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mascara { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
