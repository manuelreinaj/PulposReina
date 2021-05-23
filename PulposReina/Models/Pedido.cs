using System;
using System.Collections.Generic;

#nullable disable

namespace PulposReina.Models
{
    public partial class Pedido
    {
        public int Id { get; set; }
        public int Clienteid { get; set; }
        public int Articuloid { get; set; }
        public DateTime Fecha { get; set; }
        public int Unidades { get; set; }
        public float Precio { get; set; }
        public int Oferta { get; set; }

        public virtual Articulo Articulo { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
