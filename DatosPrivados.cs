using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos
{
    public class DatosPrivados
    {
        private readonly string nombre;
        private readonly int pin;

        public DatosPrivados(string nombre, int pin)
        {
            this.nombre = nombre;
            this.pin = pin;
        }

        public string GetNombre() => nombre;

        public bool ValidarPin(int pin) => this.pin == pin;
    }
}