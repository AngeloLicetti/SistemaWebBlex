using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class Cotizacion
    {
        public int CotizacionId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Mensaje { get; set; }
        public int Dias { get; set; }
        [Display(Name = "Precio total")]
        public double PrecioTotal { get; set; }
        [Display(Name = "Fecha de cotización")]
        public DateTime FechaCotizacion { get; set; }
        [Display(Name = "Comprobante de pago")]
        public string File { get; set; }
        public virtual List<DetalleCotizacion> DetalleCotiacions { get; set; }

        public virtual SolCotizacion SolCotizacion { get; set; }

        public Cotizacion() { }
    }
}