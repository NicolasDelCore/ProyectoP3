using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.InterfacesEntidades
{
	public interface IValidable<T> where T : class
	{
		void Validar();
	}
}

