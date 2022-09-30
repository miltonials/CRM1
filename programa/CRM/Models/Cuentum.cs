using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public partial class Cuentum
    {
        public string? CedulaCliente { get; set; }
        public string? NombreCuenta { get; set; }
        public string? ModedaCuenta { get; set; }

        public virtual Cliente? CedulaClienteNavigation { get; set; }
    }
}
