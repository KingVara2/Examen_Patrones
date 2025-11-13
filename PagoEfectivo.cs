using Sistema_Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System;

using System;

namespace Sistema_Pagos
{
    public class PagoEfectivo : MetodoPago
    {
        private readonly CuentaBase cuentaDecorada;
        private const double IVA = 0.16; // Ajustable

        public PagoEfectivo(CuentaBase cuentaDecorada)
        {
            this.cuentaDecorada = cuentaDecorada;
        }

        public bool ProcesarPago()
        {
            // Totales
            double baseSinIva = cuentaDecorada.CalcularTotal();
            double montoIva = baseSinIva * IVA;
            double total = baseSinIva + montoIva;

            // Desglose correcto recorriendo la cadena
            double descuentoMonto = ObtenerDescuentoTotal(cuentaDecorada);
            double propinaMonto = ObtenerPropinaTotal(cuentaDecorada);
            double subtotalOriginal = ObtenerSubtotalOriginal(cuentaDecorada);

            Console.Clear();
            Console.WriteLine("|----------------- PAGO EN EFECTIVO -----------------|");
            Console.WriteLine($"| Subtotal (con descuentos/propina): ${baseSinIva:0.00}");
            Console.WriteLine($"| IVA ({IVA * 100:0}%): ${montoIva:0.00}");
            Console.WriteLine($"| TOTAL A PAGAR: ${total:0.00}");
            Console.WriteLine("|----------------------------------------------------|");
            Console.Write("¿Desea continuar con el pago en efectivo? (s/n): ");
            string resp = Console.ReadLine().ToLower();
            if (resp == "s")
            {
                var ticket = new Ticket(
                    subtotal: subtotalOriginal,
                    descuento: descuentoMonto,
                    propina: propinaMonto,
                    iva: montoIva,
                    comision: 0,
                    total: total
                );
                ticket.Generar();
                return true;
            }
            else
            {
                Console.WriteLine("Pago cancelado. Volviendo a métodos de pago...");
                return false;
            }
        }

        // Recorre decoradores para hallar el descuento aplicado
        private static double ObtenerDescuentoTotal(CuentaBase nodo)
        {
            if (nodo is DescuentoDecorator d) return d.ObtenerDescuentoAplicado();
            if (nodo is PropinaDecorator p) return ObtenerDescuentoTotal(p.Inner);
            return 0;
        }

        // Recorre decoradores para hallar la propina aplicada
        private static double ObtenerPropinaTotal(CuentaBase nodo)
        {
            if (nodo is PropinaDecorator p) return p.ObtenerMontoPropina();
            if (nodo is DescuentoDecorator d) return ObtenerPropinaTotal(d.Inner);
            return 0;
        }

        // Obtiene el subtotal original (antes de descuento y propina)
        private static double ObtenerSubtotalOriginal(CuentaBase nodo)
        {
            if (nodo is PropinaDecorator p) return ObtenerSubtotalOriginal(p.Inner);
            if (nodo is DescuentoDecorator d) return ObtenerSubtotalOriginal(d.Inner);
            return nodo.Subtotal; // CuentaConcreto
        }
    }
}