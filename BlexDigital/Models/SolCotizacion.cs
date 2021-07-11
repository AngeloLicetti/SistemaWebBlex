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

        [Display(Name = "Nombre de la empresa")]
        public string NombreEmpresa { get; set; }

        [Display(Name = "Descripción del negocio")]
        [DataType(DataType.MultilineText)]
        public string DescripcionDelNegocio { get; set; }
        [Display(Name = "Misión")]
        [DataType(DataType.MultilineText)]
        public string Mision { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Visión")]
        public string Vision { get; set; }
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Correo de la empresa")]
        public string CorreoDeEmpresa { get; set; }
        [Display(Name = "Teléfono de la empresa")]
        public string TelefonoDeEmpresa { get; set; }
        [Display(Name = "Número de páginas para su sitio web")]
        public int NumeroPaginas { get; set; }
        [Display(Name = "Desea página con catálogo de sus productos")]
        public bool PaginaConCatalogo { get; set; }
        [Display(Name = "Desea carrito de compras")]
        public bool CarritoDeCompras { get; set; }
        public string Estado { get; set; }
        [Display(Name = "Fecha de la solicitud")]
        public DateTime FechaSolicitud { get; set; }

        public virtual ApplicationUser Cliente { get; set; }

        public SolCotizacion() { }
    }
}