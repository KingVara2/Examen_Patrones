using Sistema_Pagos.MODELO.PAGOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.USUARIOS
{
    internal class HistorialPagos
    {
        private readonly List<Pago> _pagos;
        public HistorialPagos()
        {
            _pagos = new List<Pago>();
        }
        public void AgregarPago(Pago pago)
        {
            _pagos.Add(pago);
        }
        public void MostrarHistorial()
        {
            VISTA.Vistas.MostrarHistorial(_pagos);
            VISTA.Vistas.Pausa();
            VISTA.Vistas.LimpiarPantalla();
        }

        public Pago ObtenerUltimoPago()
        {
            if (_pagos.Count == 0) return null;
            return _pagos[_pagos.Count - 1];
        }
        public List<Pago> ObtenerPagosPendientes()
        {
            return _pagos.FindAll(p => p.ObtenerEstado() == "Pendiente");
        }
    }
}
