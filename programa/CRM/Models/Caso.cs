using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Caso
    {
        public Caso()
        {
            IdActividads = new HashSet<Actividad>();
            IdTareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public int? ProyectoAsociado { get; set; }
        public string? PropietarioCaso { get; set; }
        public string? Asunto { get; set; }
        public string? Dirrecion { get; set; }
        public string? NombreCuenta { get; set; }
        public string? NombreContacto { get; set; }
        public string? OrigenCaso { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }
        public string? TipoCaso { get; set; }

        public virtual Usuario? PropietarioCasoNavigation { get; set; }
        public virtual Ejecucion? ProyectoAsociadoNavigation { get; set; }

        public virtual ICollection<Actividad> IdActividads { get; set; }
        public virtual ICollection<Tarea> IdTareas { get; set; }
    }
}
