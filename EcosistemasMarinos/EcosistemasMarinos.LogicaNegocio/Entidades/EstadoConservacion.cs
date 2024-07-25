using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using EcosistemasMarinos.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.Entidades
{
	public class EstadoConservacion : IValidable<EstadoConservacion>
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public int EstadoPorcentual { get; set; }

		public EstadoConservacion()
		{

		}

		public void Validar()
		{
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new EstadoConservacionException("No se ha proporcionado un nombre");
            }
            if (EstadoPorcentual < 0)
            {
                throw new EstadoConservacionException("No se ha proporcionado un estado porcentual");
            }
        }

	}
}
