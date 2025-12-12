using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.PAGOS.Pagos_States
{
    internal class PagoPendiente : IPagoEstado
    {
        public string Nombre => "Pendiente";

        public bool ProcesarPago(Pago pago, UsuarioCuenta usuario)
        {
            
            return false;
        }
    }
}
