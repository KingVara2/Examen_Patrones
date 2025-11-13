using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos
{
    public class CuentaConcreto : CuentaBase
    {
        public CuentaConcreto(double subtotal) : base(subtotal) { }
    }

}
