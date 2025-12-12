using Sistema_Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Factory
{
    public class Santander : Banco
    {
        public Santander() : base("Santander") { }

        public override bool ProcesarPago(double monto)
        {
            VISTA.Vistas.BancoPagoAprobado(this, monto, usaVerboPor: true);
            return true;
        }

        public override double CalcularComision(double monto)
        {
            return monto * 0.015;
        }
    }
}