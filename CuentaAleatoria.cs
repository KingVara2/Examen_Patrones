using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_Pagos
{
    public class CuentaAleatoria
    {
        private List<(string Nombre, double Precio)> platillos = new();
        private static Random random = new();

        public CuentaAleatoria()
        {
            GenerarMenuAleatorio();
            MostrarCuenta();
        }

        private void GenerarMenuAleatorio()
        {
            string[] opciones = {
                "Tacos al Pastor", "Enchiladas Verdes", "Hamburguesa Doble",
                "Pizza de Pepperoni", "Sopa Azteca", "Chilaquiles Rojos",
                "Burrito de Pollo", "Hot Dog", "Milanesa con Papas",
                "Quesadilla de Queso", "Pozole", "Tostadas de Pollo",
                "Ensalada César", "Club Sándwich", "Sushi Roll Clásico"
            };

            int cantidad = random.Next(3, 6);
            for (int i = 0; i < cantidad; i++)
            {
                string nombre = opciones[random.Next(opciones.Length)];
                double precio = random.Next(90, 500) + random.NextDouble();
                platillos.Add((nombre, Math.Round(precio, 2)));
            }
        }

        public double CalcularCosto()
        {
            double total = 0;
            foreach (var p in platillos)
                total += p.Precio;
            return total;
        }

        public void MostrarCuenta()
        {
            Console.WriteLine("===============================================================");
            Console.WriteLine("                     RESUMEN DEL PEDIDO                        ");
            Console.WriteLine("===============================================================\n");

            int index = 1;
            foreach (var p in platillos)
            {
                Console.WriteLine($"{index}. {p.Nombre}");
                Console.WriteLine($"   Costo: ${p.Precio:F2}\n");
                index++;
            }

            Console.WriteLine($"Subtotal: ${CalcularCosto():F2}");
            Console.WriteLine($"Artículos totales: {platillos.Count}");

            Console.WriteLine("===============================================================\n");
        }
    }

   
    partial class Program
    {
        public static List<CuentaAleatoria> GenerarCuentasAleatorias(int cantidad)
        {
            var lista = new List<CuentaAleatoria>();
            for (int i = 0; i < cantidad; i++)
            {
                lista.Add(new CuentaAleatoria());
            }
            return lista;
        }
    }
}