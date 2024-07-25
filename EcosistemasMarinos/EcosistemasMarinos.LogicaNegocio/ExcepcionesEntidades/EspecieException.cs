using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class EspecieException : Exception
    {
        public EspecieException() : base() { }

        public EspecieException(string msg) : base(msg) { }

        public EspecieException(string msg, Exception interna) : base(msg, interna) { }

    }
}