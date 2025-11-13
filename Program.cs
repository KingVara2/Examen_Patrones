using System;
using System.IO;
using System.Text;
using System;


namespace Sistema_Pagos
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();

            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                        RESTAURANTE VARA                     |");
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine();

            var cuentas = GenerarCuentasAleatorias(1);

            var random = new Random();
            int indiceElegido = random.Next(cuentas.Count);
            var cuentaSeleccionada = cuentas[indiceElegido];


            double subtotal = cuentaSeleccionada.CalcularCosto();


            CuentaBase cuenta = new CuentaConcreto(subtotal);


            Console.Write("\n¿Tiene algún cupón o descuento? (s/n): ");
            if (Console.ReadLine().ToLower() == "s")
            {
                Console.Write("Indique porcentaje de descuento (ej. 10 para 10%): ");
                if (double.TryParse(Console.ReadLine(), out double pct))
                {
                    double descuentoPct = Math.Max(0, Math.Min(100, pct)) / 100.0;
                    cuenta = new DescuentoDecorator(cuenta, descuentoPct);
                }
            }


            Console.Write("\n¿Desea dejar propina? (s/n): ");
            string quierePropina = Console.ReadLine().ToLower();
            if (quierePropina == "s")
            {
                Console.WriteLine("Opciones de propina: 10, 20, 30, 40");
                Console.Write("Seleccione porcentaje (ej. 10): ");
                if (int.TryParse(Console.ReadLine(), out int opc) && (opc == 10 || opc == 20 || opc == 30 || opc == 40))
                {
                    double propPct = opc / 100.0;
                    cuenta = new PropinaDecorator(cuenta, aplicada: true, propinaPct: propPct);
                }
                else
                {
                    Console.WriteLine("Opción inválida. No se aplicará propina.");
                    cuenta = new PropinaDecorator(cuenta, aplicada: false);
                }
            }
            else
            {
                cuenta = new PropinaDecorator(cuenta, aplicada: false);
            }
            Console.Clear();


            bool pagoExitoso = false;
            while (!pagoExitoso)
            {
                Console.Clear();
                Console.WriteLine("\n+-------------------------------------------------------------+");
                Console.WriteLine($"| Cuenta actual:\n\t {cuenta.Descripcion}|");
                Console.WriteLine($"| Subtotal (con descuentos/propina):\n\t ${cuenta.CalcularTotal():0.00}|");
                Console.WriteLine("+-------------------------------------------------------------+");
                Console.WriteLine("| ¿Qué método de pago desea usar?                             |");
                Console.WriteLine("| 1) Efectivo                                                 |");
                Console.WriteLine("| 2) Tarjeta                                                  |");
                Console.Write("| Seleccione (1-2): ");
                string metodo = Console.ReadLine();
                MetodoPago pago = null;
                if (metodo == "1")
                {
                    pago = new PagoEfectivo(cuenta);
                }
                else if (metodo == "2")
                {
                   
                    pago = new PagoTarjetaAdapter(cuenta);
                }
                else
                {
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    continue;
                }

                pagoExitoso = pago.ProcesarPago();
                if (!pagoExitoso)
                {
                    Console.Write("No se completó el pago. ¿Desea intentar otro método? (s/n): ");
                    if (Console.ReadLine().ToLower() != "s")
                    {
                        Console.WriteLine("Saliendo sin pagar. Hasta luego.");
                        return;
                    }
                }
            }

            Console.WriteLine("\nPresione ENTER para finalizar.");
            Console.ReadLine();
        }
    }
}