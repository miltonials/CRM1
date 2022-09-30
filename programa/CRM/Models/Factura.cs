using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Factura
    {
        public Factura()
        {
            Cotizacions = new HashSet<Cotizacion>();
        }

        public int Consecutivo { get; set; }
        public int IdCotizacion { get; set; }
        public short? Monto { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Cotizacion IdCotizacionNavigation { get; set; } = null!;
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
    }
}
