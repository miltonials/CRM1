using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Familium
    {
        public Familium()
        {
            Productos = new HashSet<Producto>();
        }

        public int CodigoFamilia { get; set; }
        public string? NombreFamilia { get; set; }
        public string? Estado { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
