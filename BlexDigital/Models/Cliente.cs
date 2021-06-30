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
        public string NombreCliente { get; set; }
        public string CorreoDeContacto { get; set; }
        public string CelularDeContacto { get; set; }

        public List<SolCotizacion> SolCotizacions { get; set; }

        public Cliente() { }
    }
}