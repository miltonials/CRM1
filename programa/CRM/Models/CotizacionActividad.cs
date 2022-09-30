using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class CotizacionActividad
    {
        public int IdCotizacion { get; set; }
        public int IdActividad { get; set; }

        public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;
    }
}
