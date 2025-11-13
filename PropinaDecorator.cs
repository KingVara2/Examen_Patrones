using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos
{
    public class PropinaDecorator : CuentaBase
    {
        private readonly CuentaBase cuenta;
        private readonly double propinaPct;
        private readonly bool aplicada;

        public PropinaDecorator(CuentaBase cuenta, bool aplicada, double propinaPct = 0) : base(cuenta.CalcularTotal())
            => (this.cuenta, this.aplicada, this.propinaPct) = (cuenta, aplicada, propinaPct);

        public CuentaBase Inner => cuenta;

        public override double CalcularTotal()
        {
            double monto = cuenta.CalcularTotal();
            if (!aplicada || propinaPct <= 0) return monto;
            return monto + (monto * propinaPct);
        }

        public double ObtenerMontoPropina()
        {
            if (!aplicada || propinaPct <= 0) return 0;
            return cuenta.CalcularTotal() * propinaPct;
        }

        public override string Descripcion => aplicada
            ? $"{cuenta.Descripcion} (Propina {propinaPct * 100:0}%)"
            : $"{cuenta.Descripcion} (Sin propina)";
    }
}