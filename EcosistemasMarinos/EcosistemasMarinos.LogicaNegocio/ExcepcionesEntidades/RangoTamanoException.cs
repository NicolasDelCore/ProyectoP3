using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class RangoTamanoException : Exception
    {
        public RangoTamanoException() : base() { }

        public RangoTamanoException(string msg) : base(msg) { }

        public RangoTamanoException(string msg, Exception interna) : base(msg, interna) { }

    }
}
