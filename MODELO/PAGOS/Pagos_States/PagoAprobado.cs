using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.PAGOS.Pagos_States
{
   internal class PagoAprobado : IPagoEstado
   {
     public string Nombre => "Aprobado";

      public bool ProcesarPago(Pago pago, UsuarioCuenta usuario)
      {
           VISTA.Vistas.PagoAprobado(pago);
           VISTA.Vistas.Pausa();
           VISTA.Vistas.LimpiarPantalla();
           return true;
      }
   }
    
}
