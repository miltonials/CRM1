using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Inflacion
    {
        public int Anno { get; set; }
        public int? Porcentaje { get; set; }
        public int NumeroCotizacion { get; set; }

        public virtual Cotizacion NumeroCotizacionNavigation { get; set; } = null!;
    }
}
