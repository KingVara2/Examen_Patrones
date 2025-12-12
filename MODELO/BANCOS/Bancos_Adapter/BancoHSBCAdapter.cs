using Sistema_Pagos.MODELO.BANCOS.Bancos_Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Adapter
{
    public class BancoHSBCAdapter : Banco
    {
        private readonly HSBCAPI apiExterna;
            
        public BancoHSBCAdapter() : base("HSBC (Adaptado)")
        {
            apiExterna = new HSBCAPI();
        }

        public override double CalcularComision(double monto)
        {
            int feeCents = apiExterna.CalculateFeeInCents(monto);
            return feeCents / 100.0;
        }

        public override bool ProcesarPago(double monto)
        {
            string result = apiExterna.ExecuteOperation(monto);

            return result switch
            {
                "OK" => true,
                _ => false
            };
        }
    }
}
