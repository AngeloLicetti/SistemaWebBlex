using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlexDigital.Models
{
    public class AsignarDiseñadorViewModel
    {
        public virtual List<ApplicationUser> Trabajadores { get; set; }
        public virtual Proyecto Proyecto { get; set; }
    }
}