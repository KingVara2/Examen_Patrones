using System;

namespace Sistema_Pagos.MODELO.USUARIOS
{
    public abstract class CuentaBase
    {
        private readonly double _monto;

        protected CuentaBase(double monto)
        {
            _monto = monto;
        }
        public double Monto => _monto;
        public virtual double CalcularTotal()
        {
            return Monto;
        }

        public virtual string Descripcion => $"Monto a pagar: ${Monto:0.00}";
    }
}
