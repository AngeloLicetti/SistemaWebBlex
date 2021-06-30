using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class DetalleCotizacion
    {
        public int DetalleCotizacionId { get; set; }
        public string NombreDetalle { get; set; }
        public double PrecioDetalle { get; set; }

        public DetalleCotizacion() { }
    }
}