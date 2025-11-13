using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos
{
    public class Usuario
    {
        private readonly DatosPrivados datos;

        public Usuario(DatosPrivados datos)
        {
            this.datos = datos;
        }

        public string GetNombre() => datos.GetNombre();

        public bool ValidarPin(int pin) => datos.ValidarPin(pin);
    }
}
