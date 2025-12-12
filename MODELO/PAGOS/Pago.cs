using Sistema_Pagos.MODELO.BANCOS.Bancos_Factory;
using Sistema_Pagos.MODELO.PAGOS.Pagos_States;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.PAGOS
{
   public class Pago
    {
        public double Monto { get; }
        public Banco Banco { get; }
        public string Servicio { get; } 
        public IPagoEstado Estado { get; private set; } 
        public DateTime Fecha { get; }

        public Pago(double monto, Banco banco, string servicio)
        {
            Monto = monto;
            Banco = banco;
            Servicio = servicio;
            Fecha = DateTime.Now;
            Estado = new PagoPendiente();
        }

        
        public void CambiarEstado(IPagoEstado nuevoEstado)
        {
            Estado = nuevoEstado;
        }

        public bool Procesar(UsuarioCuenta usuario)
        {
            return Estado.ProcesarPago(this, usuario);
        }

        public string ObtenerEstado()
        {
            return Estado.Nombre;
        }
    }
}
