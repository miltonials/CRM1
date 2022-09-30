using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Contacto
    {
        public Contacto()
        {
            Clientes = new HashSet<Cliente>();
            Cotizacions = new HashSet<Cotizacion>();
            IdActividads = new HashSet<Actividad>();
            IdTareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public string? CedulaCliente { get; set; }
        public string? CedulaUsuario { get; set; }
        public string? Medio { get; set; }
        public string? Motivo { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Estado { get; set; }
        public string? Dirreccion { get; set; }
        public string? Sector { get; set; }
        public string? Zona { get; set; }
        public string? Descripcion { get; set; }

        public virtual Cliente? CedulaClienteNavigation { get; set; }
        public virtual Usuario? CedulaUsuarioNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }

        public virtual ICollection<Actividad> IdActividads { get; set; }
        public virtual ICollection<Tarea> IdTareas { get; set; }
    }
}
