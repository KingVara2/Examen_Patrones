using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos
{
    public class Santander : Banco
    {
        private readonly Usuario usuarioAlmacenado;
        private const double COMISION_PCT = 0.02;


        public Santander() : this(null) { }

        public Santander(Usuario usuario)
        {
            usuarioAlmacenado = usuario ?? new Usuario(new DatosPrivados("Ulises", 7224));
        }

        public override string Nombre => "Santander";

        public override bool ValidarUsuario(string nombre, int pin)
            => usuarioAlmacenado.GetNombre() == nombre && usuarioAlmacenado.ValidarPin(pin);

        public override void ProcesarPago(double monto)
        {
            Console.WriteLine($"Procesando pago de ${monto:0.00} en {Nombre}...");
            Console.WriteLine("Pago aceptado por Santander.");
        }

        public override double CalcularComision(double monto) => monto * COMISION_PCT;
    }
}