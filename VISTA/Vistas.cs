using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using Sistema_Pagos.MODELO.BANCOS.Bancos_Factory;
using System;
using System.Collections.Generic;

namespace Sistema_Pagos.VISTA
{
    internal static class Vistas
    {
      
        public static void LimpiarPantalla()
        {
            Console.Clear();
        }

        public static void Pausa()
        {
            Console.ReadLine();
        }

        public static void SetUtf8()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public static void EncabezadoSistema()
        {
            Console.Clear();
            Console.WriteLine("+-------------------------------------------------------------+");
            Console.WriteLine("|                  SISTEMA DE PAGOS SIMULADO                  |");
            Console.WriteLine("+-------------------------------------------------------------+");
        }

        public static void MostrarUsuarioYSaldo(UsuarioCuenta usuario)
        {
            Console.WriteLine($"\nUsuario: {usuario.Nombre}");
            Console.WriteLine($"Saldo inicial: ${usuario.Saldo:0.00}");
        }

        public static void MenuPrincipal()
        {
            Console.WriteLine("\n+---------------------------------------------------------------+");
            Console.WriteLine("| Menú Principal                                                |");
            Console.WriteLine("+---------------------------------------------------------------+");
            Console.WriteLine("| 1) Mostrar pagos pendientes                                   |");
            Console.WriteLine("| 2) Aprobar/Rechazar un pago                                   |");
            Console.WriteLine("| 3) Mostrar historial de pagos                                 |");
            Console.WriteLine("| 4) Mostrar saldo actual                                       |");
            Console.WriteLine("| 5) Salir                                                      |");
            Console.WriteLine("+---------------------------------------------------------------+");
            Console.Write("Seleccione opción (1-6): ");
        }

        public static void SaludoFinal()
        {
            Console.WriteLine("\nGracias por usar el sistema de pagos simulado. Hasta luego!");
        }

        public static void OpcionNoValida()
        {
            Console.WriteLine("Opción no válida.");
        }

        public static void MostrarSaldoActual(UsuarioCuenta usuario)
        {
            Console.Clear();
            Console.WriteLine($"\nSaldo actual: ${usuario.Saldo:0.00}");
            Console.ReadLine();
        }

        public static void BancoPagoAprobado(Banco banco, double monto, bool usaVerboPor = true)
        {
            Console.WriteLine($"\n+----------------------------+");
            var verbo = usaVerboPor ? "aprobado por" : "aprobado para";
            Console.WriteLine($"| Pago de ${monto:0.00} {verbo} {banco.Nombre} |");
            Console.WriteLine("+----------------------------+");
        }

        public static void NoHayPagosPendientes()
        {
            Console.WriteLine("\nNo hay pagos pendientes.");
        }

        public static void ListaPagosPendientes(List<Pago> pendientes)
        {
            LimpiarPantalla();
            Console.WriteLine("\n+-------------------- PAGOS PENDIENTES --------------------+");
            for (int i = 0; i < pendientes.Count; i++)
            {
                var pago = pendientes[i];
                Console.WriteLine($"| {i + 1}) {pago.Servicio} - ${pago.Monto:0.00} | Banco: {pago.Banco.Nombre} | Estado: {pago.ObtenerEstado()} |");
            }
            Console.WriteLine("+-----------------------------------------------------------+\n\n");
        }

        public static void SolicitarSeleccionPago()
        {
            Console.Write("\nSeleccione el número del pago a procesar: ");
        }

        public static void SeleccionInvalida()
        {
            Console.WriteLine("Selección inválida.");
        }

        public static void SolicitarDecision(Pago pago)
        {
            Console.Write($"¿Desea aprobar (A) o rechazar (R) el pago de {pago.Servicio}?: ");
        }

        public static void DecisionInvalida()
        {
            Console.WriteLine("Opción inválida, no se procesó el pago.");
        }
        public static void ProcesandoPago(Pago pago)
        {
            Console.WriteLine($"\nProcesando pago de {pago.Servicio}...");
        }

        public static void PagoAprobado(Pago pago)
        {
            Console.WriteLine($"\n+----------------------------+");
            Console.WriteLine($"| Pago de ${pago.Monto:0.00} a {pago.Servicio} aprobado |");
            Console.WriteLine("+----------------------------+");
        }

        public static void PagoRechazado(Pago pago)
        {
            Console.WriteLine($"\n+----------------------------+");
            Console.WriteLine($"| Pago de ${pago.Monto:0.00} a {pago.Servicio} fue rechazado |");
            Console.WriteLine("+----------------------------+");
        }

        public static void SaldoTrasAprobacion(UsuarioCuenta usuario)
        {
            Console.WriteLine($"Pago aprobado Nuevo saldo: ${usuario.Saldo:0.00}");
        }

        public static void SaldoInsuficiente(UsuarioCuenta usuario)
        {
            Console.WriteLine($"Pago rechazado Saldo insuficiente.\nSaldo actual: ${usuario.Saldo:0.00}");
        }

        // Historial
        public static void MostrarHistorial(List<Pago> pagos)
        {
            LimpiarPantalla();
            Console.WriteLine("\n+------------------ HISTORIAL DE PAGOS ------------------+");
            foreach (var pago in pagos)
            {
                Console.WriteLine($"| {pago.Fecha:G} | {pago.Servicio} | ${pago.Monto:0.00} | Estado: {pago.ObtenerEstado()} |");
            }
            Console.WriteLine("+-------------------------------------------------------+");
        }
        public static void EncabezadoRecibo()
        {
            Console.WriteLine("\n+-------------------- RECIBO DE PAGO --------------------+");
        }

        public static void ReciboLinea(string texto)
        {
            Console.WriteLine(texto);
        }

        public static void PieRecibo()
        {
            Console.WriteLine("+--------------------------------------------------------+\n");
        }
    }
}