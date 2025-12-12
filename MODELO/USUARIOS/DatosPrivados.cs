using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.USUARIOS
{
    public class DatosPrivados
    {
        private readonly string _nombre;
        private readonly int _pin;

        public DatosPrivados(string nombre, int pin)
        {
            _nombre = nombre;
            _pin = pin;
        }

        public string GetNombre()
        {
            return _nombre;
        }

        public bool ValidarPin(int pin)
        {
            return _pin == pin;
        }
    }
}
