using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Factory
{
    internal class CFE : Banco
    {
        public CFE() : base("CFE") { }

        public override bool ProcesarPago(double monto)
        {
            VISTA.Vistas.BancoPagoAprobado(this, monto, usaVerboPor: false);
            return true;
        }

        public override double CalcularComision(double monto)
        {
            return 0;
        }
    }
}
