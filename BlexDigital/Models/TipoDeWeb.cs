using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlexDigital.Models
{
    public enum TipoDeWeb
    {
        [Display(Name = "Ecommerce")]
        Ecommerce = 0,
        [Display(Name = "Web informativa de una sola página (single page)")]
        SinglePage = 1,
        [Display(Name = "Web informativa con múltiples páginas")]
        MultiPage = 2
    }
}