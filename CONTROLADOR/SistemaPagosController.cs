using System;
using System.Text;
using System.Threading;
using Sistema_Pagos.MODELO.RECIBOS;
using Sistema_Pagos.MODELO.USUARIOS;
using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.PAGOS.Pagos_States;
using Sistema_Pagos.MODELO.RECIBOS.Recibos_Dcorators;

namespace Sistema_Pago
{
    internal partial class SistemaPagosController
    {
        private static Timer _timerPagos;

        private static void GenerarPagosPeriodicos(HistorialPagos historial)
        {
            GeneradorPagos.GenerarPagos(historial, 1);
            var pago = historial.ObtenerUltimoPago();
        }

        static void Main(string[] args)
        {
            Sistema_Pagos.VISTA.Vistas.SetUtf8();
            Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();

            HistorialPagos historial = new HistorialPagos();
            UsuarioCuenta usuario = new UsuarioCuenta();

            _timerPagos = new Timer(
                 e => GenerarPagosPeriodicos(historial),
                 null,
                 TimeSpan.Zero,
                 TimeSpan.FromSeconds(10)
            );

            bool salir = false;
            while (!salir)
            {
                Sistema_Pagos.VISTA.Vistas.EncabezadoSistema();
                Sistema_Pagos.VISTA.Vistas.MostrarUsuarioYSaldo(usuario);

                Sistema_Pagos.VISTA.Vistas.MenuPrincipal();
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();
                        MostrarPagosPendientes(historial);
                        break;
                    case "2":
                        Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();
                        AprobarRechazarPago(historial, usuario);
                        break;
                    case "3":
                        Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();
                        historial.MostrarHistorial();
                        break;
                    case "4":
                        Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();
                        Sistema_Pagos.VISTA.Vistas.MostrarSaldoActual(usuario);
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Sistema_Pagos.VISTA.Vistas.OpcionNoValida();
                        Sistema_Pagos.VISTA.Vistas.Pausa();
                        Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();
                        break;
                }
            }

            Sistema_Pagos.VISTA.Vistas.SaludoFinal();
        }

        private static void MostrarPagosPendientes(HistorialPagos historial)
        {
            var pendientes = historial.ObtenerPagosPendientes();
            if (pendientes.Count == 0)
            {
                Sistema_Pagos.VISTA.Vistas.NoHayPagosPendientes();
                return;
            }
            Sistema_Pagos.VISTA.Vistas.ListaPagosPendientes(pendientes);
        }

        private static void AprobarRechazarPago(HistorialPagos historial, UsuarioCuenta usuario)
        {
            var pendientes = historial.ObtenerPagosPendientes();
            if (pendientes.Count == 0)
            {
                Sistema_Pagos.VISTA.Vistas.NoHayPagosPendientes();
                return;
            }

            Sistema_Pagos.VISTA.Vistas.ListaPagosPendientes(pendientes);
            Sistema_Pagos.VISTA.Vistas.SolicitarSeleccionPago();

            if (int.TryParse(Console.ReadLine(), out int seleccion) &&
                seleccion > 0 && seleccion <= pendientes.Count)
            {
                Pago pago = pendientes[seleccion - 1];

                Sistema_Pagos.VISTA.Vistas.SolicitarDecision(pago);
                string decision = Console.ReadLine().ToUpper();

                if (decision == "A")
                {
                    pago.CambiarEstado(new PagoProcesando());
                    pago.Procesar(usuario);

                    IRecibo recibo = new ReciboBase();
                    recibo = new ReciboConIVA(recibo);
                    recibo = new ReciboConAdvertencia(recibo);
                    recibo = new ReciboConFolio(recibo);

                    recibo.Generar(pago, usuario);

                    Sistema_Pagos.VISTA.Vistas.Pausa();
                    Sistema_Pagos.VISTA.Vistas.LimpiarPantalla();
                }
                else if (decision == "R")
                {
                    pago.CambiarEstado(new PagoRechazado());
                    pago.Procesar(usuario);
                }
                else
                {
                    Sistema_Pagos.VISTA.Vistas.DecisionInvalida();
                }
            }
            else
            {
                Sistema_Pagos.VISTA.Vistas.SeleccionInvalida();
            }
        }
    }
}