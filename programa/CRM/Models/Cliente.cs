using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Contactos = new HashSet<Contacto>();
            CedulaUsuarios = new HashSet<Usuario>();
        }

        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Celular { get; set; } = null!;
        public int ContactoPrincipal { get; set; }
        public string SitioWeb { get; set; } = null!;
        public string InformacionAdicional { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public string? Sector { get; set; }
        public string? Zona { get; set; }

        public virtual Contacto ContactoPrincipalNavigation { get; set; } = null!;
        public virtual ICollection<Contacto> Contactos { get; set; }

        public virtual ICollection<Usuario> CedulaUsuarios { get; set; }
    }
}
