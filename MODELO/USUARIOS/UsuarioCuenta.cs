using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.USUARIOS
{
    public class UsuarioCuenta
    {
        public string Nombre { get; private set; }
        public double Saldo { get; private set; } 

        public UsuarioCuenta()
        {
            Nombre = "Usuario Predeterminado";
            Saldo = 5000;
        }

  
        public bool Descontar(double cantidad)
        {
            if (Saldo >= cantidad)
            {
                Saldo -= cantidad;
                return true;
            }
            return false;
        }

        public void Depositar(double cantidad)
        {
            Saldo += cantidad;
        }
    }
}
