using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Cotizacion
    {
        public Cotizacion()
        {
            CotizacionActividads = new HashSet<CotizacionActividad>();
            Facturas = new HashSet<Factura>();
            ProductoCotizacions = new HashSet<ProductoCotizacion>();
            IdTareas = new HashSet<Tarea>();
        }

        public int NumeroCotizacion { get; set; }
        public int IdFactura { get; set; }
        public int IdContacto { get; set; }
        public string? Zona { get; set; }
        public string? Tipo { get; set; }
        public string? MonedaOportunidad { get; set; }
        public string? Etapa { get; set; }
        public string? Asesor { get; set; }
        public string? NombreOportunidad { get; set; }
        public string? FechaCotizacion { get; set; }
        public string? NombreCuenta { get; set; }
        public DateTime? FechaProyeccionCierre { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string? Probabilidades { get; set; }
        public string? OrdenCompra { get; set; }
        public string? Descripcion { get; set; }

        public virtual Contacto IdContactoNavigation { get; set; } = null!;
        public virtual Factura IdFacturaNavigation { get; set; } = null!;
        public virtual Denegacion? Denegacion { get; set; }
        public virtual Inflacion? Inflacion { get; set; }
        public virtual ICollection<CotizacionActividad> CotizacionActividads { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<ProductoCotizacion> ProductoCotizacions { get; set; }

        public virtual ICollection<Tarea> IdTareas { get; set; }
    }
}
