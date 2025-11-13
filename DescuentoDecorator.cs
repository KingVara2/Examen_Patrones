using System;


namespace Sistema_Pagos
{

    public class DescuentoDecorator : CuentaBase
    {
        private readonly CuentaBase cuenta;
        private readonly double descuentoPct; 

        public DescuentoDecorator(CuentaBase cuenta, double descuentoPct) : base(cuenta.CalcularTotal())
            => (this.cuenta, this.descuentoPct) = (cuenta, descuentoPct);

        public CuentaBase Inner => cuenta;

        public override double CalcularTotal()
        {
            double monto = cuenta.CalcularTotal();
            double pct = Math.Max(0, Math.Min(1, descuentoPct));
            return monto - (monto * pct);
        }

        public double ObtenerDescuentoAplicado()
        {
            double original = cuenta.CalcularTotal();
            return original - CalcularTotal();
        }

        public override string Descripcion => $"{cuenta.Descripcion} (+Descuento {descuentoPct * 100:0}%)";
    }
}