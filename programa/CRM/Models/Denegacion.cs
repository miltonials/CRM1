using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Denegacion
    {
        public int IdCotizacion { get; set; }
        public string? Motivo { get; set; }
        public string? Competidor { get; set; }

        public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;
    }
}
