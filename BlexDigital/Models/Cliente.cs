using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class Cliente
    {
        //public int ClienteId { get; set; }
        [Key, Required]
        public string Dni { get; set; }
        [Display(Name = "Nombre del cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Correo de contacto")]
        public string CorreoDeContacto { get; set; }
        [Display(Name = "Celular de contacto")]
        public string CelularDeContacto { get; set; }

        public List<SolCotizacion> SolCotizacions { get; set; }

        public Cliente() { }
    }
}