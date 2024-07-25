using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
	public class RepositorioEstadoConservacion : IRepositorioEstadoConservacion
	{
		public EcosistemasMarinosContext Contexto { get; set; }

		public RepositorioEstadoConservacion(EcosistemasMarinosContext ctx)
		{
			Contexto = ctx;
		}
		public void Add(EstadoConservacion obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(EstadoConservacion obj)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<EstadoConservacion> FindAll()
		{
            return Contexto.EstadosConservacion.ToList();
        }

		public EstadoConservacion FindById(int? id)
		{
            //CON LINQ SERÍA ASÍ:
            //var resultado = Contexto.Clientes
            //                        .Where(cli => cli.Id == id)
            //                        .SingleOrDefault();

            //ES MÁS PRÁCTICO USAR EL Find del DbSet:
            return Contexto.EstadosConservacion.Find(id);
        }

		public void Update(EstadoConservacion obj)
		{
			throw new NotImplementedException();
		}
	}
}
