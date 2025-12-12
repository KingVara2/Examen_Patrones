using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.USUARIOS
{
    public class CuentaConcreto : CuentaBase
    {
        public CuentaConcreto(double monto) : base(monto)
        {
        }
    }
}