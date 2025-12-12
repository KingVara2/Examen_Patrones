using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.RECIBOS
{
   public abstract class ReciboDecorator : IRecibo
    {
        protected IRecibo _recibo;

        protected ReciboDecorator(IRecibo recibo)
        {
            _recibo = recibo;
        }

        public virtual void Generar(Pago pago, UsuarioCuenta usuario)
        {
            _recibo.Generar(pago, usuario);
        }
    }
}
