using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
	public class RepositorioPais : IRepositorioPais
	{
		public EcosistemasMarinosContext Contexto { get; set; }

		public RepositorioPais(EcosistemasMarinosContext ctx)
		{
			Contexto = ctx;
		}
		public void Add(Pais obj)
		{
			throw new NotImplementedException();
		}

		public void Delete(Pais obj)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Pais> FindAll()
		{
			return Contexto.Paises.ToList();
		}

		public Pais FindById(int? id)
		{
            //CON LINQ SERÍA ASÍ:
            //var resultado = Contexto.Clientes
            //                        .Where(cli => cli.Id == id)
            //                        .SingleOrDefault();

            //ES MÁS PRÁCTICO USAR EL Find del DbSet:
            return Contexto.Paises.Find(id);
        }

		public void Update(Pais obj)
		{
			throw new NotImplementedException();
		}
	}
}
