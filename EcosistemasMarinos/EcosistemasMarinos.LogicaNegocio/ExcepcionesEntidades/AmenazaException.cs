using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class AmenazaException : Exception
    {
        public AmenazaException() : base() { }

        public AmenazaException(string msg) : base(msg) { }

        public AmenazaException(string msg, Exception interna) : base(msg, interna) { }

    }
}