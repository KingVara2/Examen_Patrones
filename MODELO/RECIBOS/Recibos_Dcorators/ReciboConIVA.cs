using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.RECIBOS.Recibos_Dcorators
{
    public class ReciboConIVA : ReciboDecorator
    {
        public ReciboConIVA(IRecibo recibo) : base(recibo) { }

        public override void Generar(Pago pago, UsuarioCuenta usuario)
        {
            base.Generar(pago, usuario);
            decimal iva = (decimal)pago.Monto * 0.16m;
            Console.WriteLine($"| IVA (16%): ${iva:0.00}");
        }
    }
}
