using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.ValueObjects
{
    public class Nombre : IValidable<Nombre> {
        #region Properties
        [MinLength(2)]
        [MaxLength(50)]
        public string Value { get; private set; }
        #endregion
        #region Constructores
        public Nombre (string value) {
            Value = value.Trim();
            Validar();
        }

        private Nombre () {}
        #endregion
        #region Validacion
        public void Validar()
        {
            if ( Value.Count() < 2 || Value.Count() > 50 ) throw new ObjectValueException("Error en Nombre: Debe tener entre 2 y 50 carácteres.");
        }
        #endregion
    }
}
