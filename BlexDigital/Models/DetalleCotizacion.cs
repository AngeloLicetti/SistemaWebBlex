using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class DetalleCotizacion
    {
        public int DetalleCotizacionId { get; set; }
        [Display(Name = "Item")]
        public string NombreDetalle { get; set; }
        [Display(Name = "Precio")]
        public double PrecioDetalle { get; set; }

        public DetalleCotizacion() { }
    }
}