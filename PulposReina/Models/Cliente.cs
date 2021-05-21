using System;
using System.Collections.Generic;

#nullable disable

namespace PulposReina.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Contacto { get; set; }
        public float Rappel { get; set; }
        public int Clasificacion { get; set; }
    }
}
