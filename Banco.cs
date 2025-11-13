using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos
{
    public abstract class Banco
    {
        public abstract string Nombre { get; }
        public abstract bool ValidarUsuario(string nombre, int pin);
        public abstract void ProcesarPago(double monto);
        public abstract double CalcularComision(double monto);
    }
}