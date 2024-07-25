using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.ValueObjects
{
    public class Descripcion : IValidable<Descripcion> {
        #region Properties
        [MinLength(50)]
        [MaxLength(500)]
        public string Value { get; private set; }
        #endregion
        #region Constructores
        public Descripcion(string value)
        {
            Value = value.Trim();
            Validar();
        }

        private Descripcion() { }
        #endregion
        #region Validacion
        public void Validar()
        {
            if (Value.Count() < 50 || Value.Count() > 500) throw new ObjectValueException("Error en Descripción: Debe tener entre 50 y 500 carácteres.");
        }
        #endregion
    }
}