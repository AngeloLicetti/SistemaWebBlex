using BlexDigital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class SolCotizacion
    {
        public int SolCotizacionId { get; set; }
        
        public string NombreEmpresa { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string DescripcionDelNegocio { get; set; }
        [DataType(DataType.MultilineText)]
        public string Mision { get; set; }
        [DataType(DataType.MultilineText)]
        public string Vision { get; set; }
        public string Direccion { get; set; }
        public string CorreoDeEmpresa { get; set; }
        public string TelefonoDeEmpresa { get; set; }

        public int NumeroPaginas { get; set; }
        public bool PaginaConCatalogo { get; set; }
        public bool CarritoDeCompras { get; set; }
        public string Estado { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public virtual ApplicationUser Cliente { get; set; }

        public SolCotizacion() { }
    }
}