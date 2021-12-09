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
        [Display(Name = "Id del proyecto")]
        public int ProyectoId { get; set; }
        [Display(Name = "Nombre del proyecto")]
        public string NombreProyecto { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }

        [Display(Name = "Propuesta de diseño 1")]
        public string Diseno1 { get; set; }

        [Display(Name = "Propuesta de diseño 2")]
        public string Diseno2 { get; set; }

        [Display(Name = "Propuesta de diseño 3")]
        public string Diseno3 { get; set; }

        [Display(Name = "Propuesta de diseño elegida")]
        public int DisenoElegido { get; set; }

        public string UrlProyecto { get; set; }
        public virtual Cotizacion Cotizacion { get; set; }
        public virtual ApplicationUser Cliente { get; set; }

        public virtual ApplicationUser Trabajador { get; set; }
    }
}