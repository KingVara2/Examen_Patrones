using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Pagos.MODELO.RECIBOS
{
    public class ReciboBase : IRecibo
    {
        public void Generar(Pago pago, UsuarioCuenta usuario)
        {
            VISTA.Vistas.EncabezadoRecibo();

            VISTA.Vistas.ReciboLinea($"| Usuario: {usuario.Nombre}");
            VISTA.Vistas.ReciboLinea($"| Servicio: {pago.Servicio}");
            VISTA.Vistas.ReciboLinea($"| Banco/Proveedor: {pago.Banco.Nombre}");
            VISTA.Vistas.ReciboLinea($"| Monto: ${pago.Monto:0.00}");

            var comision = pago.Banco.CalcularComision(pago.Monto);
            VISTA.Vistas.ReciboLinea($"| Comisión banco: ${comision:0.00}");
            VISTA.Vistas.ReciboLinea($"| Total descontado del saldo: ${(pago.Monto + comision):0.00}");

            VISTA.Vistas.ReciboLinea($"| Fecha: {pago.Fecha:G}");
            VISTA.Vistas.ReciboLinea($"| Estado: {pago.ObtenerEstado()}");

            VISTA.Vistas.PieRecibo();
        }
    }
}