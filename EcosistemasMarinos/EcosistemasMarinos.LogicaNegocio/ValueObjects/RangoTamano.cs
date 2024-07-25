using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.ValueObjects
{
    /*ESTO ES UN VALUE OBJECT ¿Para qué me sirve? Los value object se validan a sí mismos. Encapsulo la validación a cada atributo */
    public class RangoTamano : IValidable<RangoTamano>
    {
     
        [Column(TypeName = "decimal(18, 2)")] // Especifica el tipo de columna y la precisión/escala
        public decimal PesoMinimo { get; set; }

        [Column(TypeName = "decimal(18, 2)")] // Especifica el tipo de columna y la precisión/escala
        public decimal PesoMaximo { get; set; }

        [Column(TypeName = "decimal(18, 2)")] // Especifica el tipo de columna y la precisión/escala
        public decimal LongitudMinima { get; set; }

        [Column(TypeName = "decimal(18, 2)")] // Especifica el tipo de columna y la precisión/escala
        public decimal LongitudMaxima { get; set; }


        public RangoTamano(decimal pesoMin, decimal pesoMax, decimal longitudMin, decimal longitudMax)
        {
            PesoMinimo = pesoMin;
            PesoMaximo = pesoMax;
            LongitudMinima = longitudMin;
            LongitudMaxima = longitudMax;
            Validar(); //Si hay un inconveniente, el objeto no se crea. Si existe un objeto de la clase NombreEcosistema, te aseguras de que es válido.
        }

        public RangoTamano()
        {

        }

        public void Validar()
        {
            if(PesoMinimo < 0)
            {
                throw new RangoTamanoException("No se ha ingresado un peso mínimo");
            }
            if(PesoMaximo < 0)
            {
                throw new RangoTamanoException("No se ha ingresado un peso máximo");
            }
            if(LongitudMinima < 0)
            {
                throw new RangoTamanoException("No se ha ingresado una longitud mínima");
            }
            if(LongitudMaxima < 0)
            {
                throw new RangoTamanoException("No se ha ingresado una longitud máxima");
            }
        }
    }
}
