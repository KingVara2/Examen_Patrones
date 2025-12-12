using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;

namespace Sistema_Pagos.MODELO.PAGOS.Pagos_States
{
    internal class PagoProcesando : IPagoEstado
    {
        public string Nombre => "Procesando";

        public bool ProcesarPago(Pago pago, UsuarioCuenta usuario)
        {
            VISTA.Vistas.ProcesandoPago(pago);

           
            var comision = pago.Banco.CalcularComision(pago.Monto);
            var total = pago.Monto + comision;

            if (usuario.Saldo >= total)
            {
                if (usuario.Descontar(total))
                    pago.CambiarEstado(new PagoAprobado());

                VISTA.Vistas.SaldoTrasAprobacion(usuario);
                VISTA.Vistas.Pausa();
                VISTA.Vistas.LimpiarPantalla();
                return true;
            }
            else
            {
                pago.CambiarEstado(new PagoRechazado());
                VISTA.Vistas.SaldoInsuficiente(usuario);
                return false;
            }
        }
    }
}