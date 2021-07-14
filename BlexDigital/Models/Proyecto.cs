using Sistema_de_gestion_comercial_Blex_Digital.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlexDigital.Models
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }
        [Display(Name = "Nombre del proyecto")]
        public string NombreProyecto { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }
        public virtual Cotizacion Cotizacion { get; set; }
    }
}