using Sistema_Pagos.MODELO.PAGOS;
using Sistema_Pagos.MODELO.USUARIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Pagos.MODELO.RECIBOS
{
    public interface IRecibo
    {
        void Generar(Pago pago, UsuarioCuenta usuario);
    }
}
