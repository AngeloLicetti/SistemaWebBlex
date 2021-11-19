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
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"([1-9]{1}[0-9]{8})", ErrorMessage = "El DNI debe ser un número de ocho dígitos")]
        public string Dni { get; set; }
        [Display(Name = "Nombre del cliente")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreCliente { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Correo de contacto")]
        public string CorreoDeContacto { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Celular de contacto")]
        [RegularExpression(@"([1-9]{1}[0-9]{7})", ErrorMessage = "El Celular debe ser un número de ocho dígitos")]
        public string CelularDeContacto { get; set; }

        public List<SolCotizacion> SolCotizacions { get; set; }

        public Cliente() { }
    }
}