using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Factory
{
    internal class CESPT : Banco
    {
        public CESPT() : base("CESPT") { }

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
