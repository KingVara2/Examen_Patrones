using Sistema_Pagos.MODELO.BANCOS.Bancos_Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Factory
{
    internal class BancoFactory
    {
        public static Banco CrearBanco(string nombre)
        {
            return nombre switch
            {
                "BBVA" => new BBVA(),
                "Santander" => new Santander(),
                "Scotiabank" => new Scotiabank(),
                "CFE" => new CFE(),
                "CESPT" => new CESPT(),
                "Amazon" => new Amazon(),
                
                "HSBC" => new BancoHSBCAdapter(),
                _ => throw new Exception("Banco o servicio no soportado")
            };
        }
    }
}
