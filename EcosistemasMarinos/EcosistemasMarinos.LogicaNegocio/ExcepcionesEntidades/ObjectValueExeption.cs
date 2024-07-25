using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades
{
    public class ObjectValueException : Exception
    {
        public ObjectValueException() : base() { }

        public ObjectValueException(string msg) : base(msg) { }

        public ObjectValueException(string msg, Exception interna) : base(msg, interna) { }

    }
}