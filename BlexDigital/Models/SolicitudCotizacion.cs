using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class SolicitudCotizacion
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int NumeroPaginas { get; set; }
        public bool CarritoDeCompras { get; set; }
    }
}