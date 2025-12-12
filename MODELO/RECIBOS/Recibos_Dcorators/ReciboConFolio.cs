using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.RECIBOS.Recibos_Dcorators
{
    public class ReciboConFolio : ReciboDecorator
    {
        private static int contador = 1000;

        public ReciboConFolio(IRecibo recibo) : base(recibo) { }

        public override void Generar(Pago pago, UsuarioCuenta usuario)
        {
            base.Generar(pago, usuario);
            Console.WriteLine($"| Folio de operación: #{contador++}");
        }
    }
}
