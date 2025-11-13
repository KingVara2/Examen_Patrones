using System;

namespace Sistema_Pagos
{
    public abstract class CuentaBase
    {
        private readonly double _originalSubtotal;

        protected CuentaBase(double subtotal)
        {
            _originalSubtotal = subtotal;
        }

        public double Subtotal => _originalSubtotal;

        public virtual double CalcularTotal()
        {
            return Subtotal;
        }

        public virtual string Descripcion => $"Subtotal: ${Subtotal:0.00}";
    }
}