using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Producto
    {
        public Producto()
        {
            ProductoCotizacions = new HashSet<ProductoCotizacion>();
        }

        public int Codigo { get; set; }
        public int CodigoFamilia { get; set; }
        public string? Nombre { get; set; }
        public int? PrecioEstandar { get; set; }
        public string? Estado { get; set; }
        public string? Descripcion { get; set; }

        public virtual Familium CodigoFamiliaNavigation { get; set; } = null!;
        public virtual ICollection<ProductoCotizacion> ProductoCotizacions { get; set; }
    }
}
