using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Sistema_Pagos
{
    public class Ticket
    {
        private readonly double subtotal;
        private readonly double descuento;
        private readonly double propina;
        private readonly double iva;
        private readonly double comision;
        private readonly double total;

        public Ticket(double subtotal, double descuento, double propina, double iva, double comision, double total)
        {
            this.subtotal = subtotal;
            this.descuento = descuento;
            this.propina = propina;
            this.iva = iva;
            this.comision = comision;
            this.total = total;
        }

        public void Generar()
        {
            Console.Clear();
            Console.WriteLine("\n|--------------------- TICKET ---------------------|");
            Console.WriteLine($"| Subtotal:         ${subtotal:0.00}                |");
            Console.WriteLine($"| Descuento:        ${descuento:0.00}              |");
            Console.WriteLine($"| Propina:          ${propina:0.00}                 |");
            Console.WriteLine($"| IVA:              ${iva:0.00}                     |");
            Console.WriteLine($"| Comisión:         ${comision:0.00}                |");
            Console.WriteLine($"| TOTAL PAGADO:     ${total:0.00}                   |");
            Console.WriteLine("|----------------------------------------------------|");
          
            Console.WriteLine("Gracias. Transacción completada.");
            
        }
    }
}