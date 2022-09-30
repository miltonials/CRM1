using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Ejecucion
    {
        public Ejecucion()
        {
            Casos = new HashSet<Caso>();
            IdActividads = new HashSet<Actividad>();
            IdTareas = new HashSet<Tarea>();
        }

        public int Id { get; set; }
        public short? NumeroCotizacion { get; set; }
        public string? Asesor { get; set; }
        public DateTime? FechaEjecucion { get; set; }
        public string? NombreCuenta { get; set; }
        public string? NombreEjecucion { get; set; }
        public string? PropietarioEjecucion { get; set; }
        public int? AñoProyectadoCierre { get; set; }
        public int? MesProyectadoCierre { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string? Departamento { get; set; }

        public virtual ICollection<Caso> Casos { get; set; }

        public virtual ICollection<Actividad> IdActividads { get; set; }
        public virtual ICollection<Tarea> IdTareas { get; set; }
    }
}
