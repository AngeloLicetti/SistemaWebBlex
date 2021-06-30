using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_gestion_comercial_Blex_Digital.Models
{
    public class Trabajador
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public double Sueldo { get; set; }
        public string Puesto { get; set; }
    }
}