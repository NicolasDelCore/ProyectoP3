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
	public class Ubicacion : IValidable<Ubicacion>
	{

        [Column(TypeName = "decimal(18, 2)")] // Especifica el tipo de columna y la precisión/escala
        public decimal Latitud { get; set; }

        [Column(TypeName = "decimal(18, 2)")] // Especifica el tipo de columna y la precisión/escala
        public decimal Longitud { get; set; }

		public Ubicacion(decimal latitud, decimal longitud)
		{
			Latitud = latitud;
			Longitud = longitud;
			Validar(); //Si hay un inconveniente, el objeto no se crea. Si existe un objeto de la clase NombreEcosistema, te aseguras de que es válido.
		}

		public Ubicacion()
		{

		}

		public void Validar()
		{
			if (Longitud < -180 || Longitud > 180) throw new UbicacionException("Error en Ecosistema: Longitud debe estar entre -180 y 180.");
            if (Latitud < -90 || Latitud > 90) throw new UbicacionException("Error en Ecosistema: Latitud debe estar entre -90 y 90.");
        }
    }
}
