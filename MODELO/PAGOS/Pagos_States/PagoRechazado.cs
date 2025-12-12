using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.PAGOS.Pagos_States
{
    internal class PagoRechazado : IPagoEstado
    {
        public string Nombre => "Rechazado";

        public bool ProcesarPago(Pago pago, UsuarioCuenta usuario)
        {
            VISTA.Vistas.PagoRechazado(pago);
            VISTA.Vistas.Pausa();
            VISTA.Vistas.LimpiarPantalla();
            return false;
        }
    }
}
