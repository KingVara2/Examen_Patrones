using Sistema_Pagos.MODELO.BANCOS.Bancos_Factory;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.PAGOS
{
    internal class GeneradorPagos
    {
        private static readonly Random _random = new Random();

        private static readonly string[] Servicios = { "CFE", "CESPT", "Luz", "Agua", "Amazon" };
        private static readonly string[] Bancos = { "BBVA", "Santander", "Scotiabank" };

        public static Pago CrearPagoAleatorio()
        {
            string servicio = Servicios[_random.Next(Servicios.Length)];
            string banco = Bancos[_random.Next(Bancos.Length)];
            double monto = _random.Next(50, 5000); 

            Banco bancoObj = BancoFactory.CrearBanco(banco);

            return new Pago(monto, bancoObj, servicio);
        }

        public static void GenerarPagos(HistorialPagos historial, int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                var pago = CrearPagoAleatorio();
                historial.AgregarPago(pago);
            }
        }
    }
}
