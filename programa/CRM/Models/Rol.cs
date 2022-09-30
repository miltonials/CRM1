using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Rol
    {
        public Rol()
        {
            CedulaUsuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Usuario> CedulaUsuarios { get; set; }
    }
}
