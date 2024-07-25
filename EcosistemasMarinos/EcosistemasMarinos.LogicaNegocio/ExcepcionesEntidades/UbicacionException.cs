using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class UbicacionException : Exception
    {
        public UbicacionException() : base() { }

        public UbicacionException(string msg) : base(msg) { }

        public UbicacionException(string msg, Exception interna) : base(msg, interna) { }

    }
}
