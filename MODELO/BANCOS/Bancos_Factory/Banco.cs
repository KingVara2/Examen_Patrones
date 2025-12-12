using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Sistema_Pagos.MODELO.BANCOS.Bancos_Factory
{
    public abstract class Banco
    {
        public string Nombre { get; protected set; }

        public Banco(string nombre)
        {
            Nombre = nombre;
        }

        public abstract bool ProcesarPago(double monto);

        public abstract double CalcularComision(double monto);
    }
}
