using System;

namespace Sistema_Pagos
{
    // Adapter que maneja pagos con tarjeta y se conecta a distintos bancos
    public class PagoTarjetaAdapter : MetodoPago
    {
        private readonly CuentaBase cuentaDecorada;
        private Banco bancoSeleccionado;
        private const double IVA = 0.16; // IVA aplicado antes de comisión de banco

        public PagoTarjetaAdapter(CuentaBase cuentaDecorada)
        {
            this.cuentaDecorada = cuentaDecorada;
        }

        public bool ProcesarPago()
        {
            // Seleccionar banco
            Console.Clear();
            Console.WriteLine("|----------------- PAGO CON TARJETA ------------------|");
            Console.WriteLine("| 1) BBVA (Comisión 3%)                                |");
            Console.WriteLine("| 2) Santander (Comisión 2%)                           |");
            Console.Write("| Seleccione (1-2): ");
            string op = Console.ReadLine();
            if (op == "1") ConectarBanco("BBVA");
            else if (op == "2") ConectarBanco("Santander");
            else
            {
                Console.WriteLine("Banco no válido. Volviendo a método de pago.");
                return false;
            }

            // Datos usuario
            Console.Write("Ingrese su nombre de usuario: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese su PIN (numérico): ");
            if (!int.TryParse(Console.ReadLine(), out int pin))
            {
                Console.WriteLine("PIN inválido. Cancelando.");
                return false;
            }

            Console.WriteLine("Validando credenciales...");
            bool valido = bancoSeleccionado.ValidarUsuario(nombre, pin);
            if (!valido)
            {
                Console.WriteLine("Validación falló. PIN o usuario incorrecto.");
                return false;
            }

            // Totales
            double baseSinIva = cuentaDecorada.CalcularTotal();
            double montoIva = baseSinIva * IVA;
            double subtotalConIva = baseSinIva + montoIva;
            double comision = bancoSeleccionado.CalcularComision(subtotalConIva);
            double total = subtotalConIva + comision;

            // Desglose correcto recorriendo la cadena
            double descuentoMonto = ObtenerDescuentoTotal(cuentaDecorada);
            double propinaMonto = ObtenerPropinaTotal(cuentaDecorada);
            double subtotalOriginal = ObtenerSubtotalOriginal(cuentaDecorada);

            // Mostrar desglose y confirmar
            Console.WriteLine("|----------------------------------------------------|");
            Console.WriteLine($"| Subtotal (con descuentos/propina): ${baseSinIva:0.00}");
            Console.WriteLine($"| IVA ({IVA * 100:0}%): ${montoIva:0.00}");
            Console.WriteLine($"| Comisión banco ({bancoSeleccionado.Nombre}): ${comision:0.00}");
            Console.WriteLine($"| TOTAL A PAGAR: ${total:0.00}");
            Console.WriteLine("|----------------------------------------------------|");
            Console.Write("¿Desea confirmar la transacción? (s/n): ");
            string confirmar = Console.ReadLine().ToLower();
            if (confirmar != "s")
            {
                Console.WriteLine("Transacción cancelada por el usuario.");
                return false;
            }

            // Procesar mediante el banco
            bancoSeleccionado.ProcesarPago(total);

            var ticket = new Ticket(
                subtotal: subtotalOriginal,
                descuento: descuentoMonto,
                propina: propinaMonto,
                iva: montoIva,
                comision: comision,
                total: total
            );
            ticket.Generar();

            return true;
        }

        public void ConectarBanco(string nombreBanco)
        {
            if (nombreBanco.Equals("BBVA", StringComparison.OrdinalIgnoreCase))
                bancoSeleccionado = new BBVA();
            else if (nombreBanco.Equals("Santander", StringComparison.OrdinalIgnoreCase))
                bancoSeleccionado = new Santander();
            else
                bancoSeleccionado = null;
        }

        private static double ObtenerDescuentoTotal(CuentaBase nodo)
        {
            if (nodo is DescuentoDecorator d) return d.ObtenerDescuentoAplicado();
            if (nodo is PropinaDecorator p) return ObtenerDescuentoTotal(p.Inner);
            return 0;
        }

        private static double ObtenerPropinaTotal(CuentaBase nodo)
        {
            if (nodo is PropinaDecorator p) return p.ObtenerMontoPropina();
            if (nodo is DescuentoDecorator d) return ObtenerPropinaTotal(d.Inner);
            return 0;
        }

        private static double ObtenerSubtotalOriginal(CuentaBase nodo)
        {
            if (nodo is PropinaDecorator p) return ObtenerSubtotalOriginal(p.Inner);
            if (nodo is DescuentoDecorator d) return ObtenerSubtotalOriginal(d.Inner);
            return nodo.Subtotal; // CuentaConcreto
        }
    }
}