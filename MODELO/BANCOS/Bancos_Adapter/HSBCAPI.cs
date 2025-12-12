using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Adapter
{

    public class HSBCAPI
    {
        private string token;
        private Random rnd = new Random();

        public HSBCAPI()
        {
         
            token = "HSBC-TKN-" + rnd.Next(100000, 999999);
        }

        public string ProviderName() => "HSBC Global Payment Gateway v3.7";

    
        public int CalculateFeeInCents(double amount)
        {
            
            int fee =
                (int)(amount * 3.9) +      
                rnd.Next(20, 90) +         
                (amount > 5000 ? 275 : 0); 

            return fee;
        }

       
        public void SimulateNetworkDelay()
        {
            int delay = rnd.Next(50, 300);
            Thread.Sleep(delay);
        }

      
        public string ExecuteOperation(double amount)
        {
            SimulateNetworkDelay();

            if (amount > 25000)
                return "ERR_LIMIT_EXCEEDED";

            if (rnd.NextDouble() < 0.05)
                return "ERR_FRAUD_SUSPECTED";

            if (rnd.NextDouble() < 0.1)
                return "ERR_TIMEOUT";

            return "OK";
        }
    }
}
