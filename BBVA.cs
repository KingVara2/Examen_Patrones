using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Pagos
{
    public class BBVA : Banco
    {
        private readonly Usuario usuarioAlmacenado;
        private const double COMISION_PCT = 0.03;

        public BBVA() : this(null) { }

        public BBVA(Usuario usuario)
        {
            usuarioAlmacenado = usuario ?? new Usuario(new DatosPrivados("Ulises", 7224));
        }

        public override string Nombre => "BBVA";

        public override bool ValidarUsuario(string nombre, int pin)
            => usuarioAlmacenado.GetNombre() == nombre && usuarioAlmacenado.ValidarPin(pin);

        public override void ProcesarPago(double monto)
        {
            Console.WriteLine($"Procesando pago de ${monto:0.00} en {Nombre}...");
            Console.WriteLine("Pago aceptado por BBVA.");
        }

        public override double CalcularComision(double monto) => monto * COMISION_PCT;
    }
}