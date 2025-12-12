using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Factory
{
    internal class Scotiabank : Banco
    {
        public Scotiabank() : base("Scotiabank") { }

        public override bool ProcesarPago(double monto)
        {
            VISTA.Vistas.BancoPagoAprobado(this, monto, usaVerboPor: true);
            return true;
        }

        public override double CalcularComision(double monto)
        {
            return monto * 0.012;
        }
    }
}
