using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using EcosistemasMarinos.LogicaNegocio.Parametros;
using LogicaAccesoDatos.RepositorioEF;

namespace EcosistemasMarinos.LogicaAccesoDatos.RepositorioEF
{
    public class RepositorioParametro : IRepositorioParametro
    {
        public EcosistemasMarinosContext Contexto { get; set; }

        public RepositorioParametro(EcosistemasMarinosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public string BuscarValorPorNombre(string nombre)
        {
            var res = Contexto.Parametros
                      .Where(par => par.Nombre == nombre)
                      .Select(par => par.Valor)
                      .SingleOrDefault();
            return res;
        }

        public void Delete(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parametro> FindAll()
        {
            return Contexto.Parametros.ToList();
        }

        public Parametro FindById(int? id)
        {
            //CON LINQ SERÍA ASÍ:
            //var resultado = Contexto.Clientes
            //                        .Where(cli => cli.Id == id)
            //                        .SingleOrDefault();

            //ES MÁS PRÁCTICO USAR EL Find del DbSet:
            return Contexto.Parametros.Find(id);
        }

        public void Update(Parametro parametro)
        {
            Contexto.Parametros.Update(parametro);
            Contexto.SaveChanges();
        }

        public Parametro BuscarParametroPorNombre(string nombre)
        {
            return Contexto.Parametros
                   .Where(par => par.Nombre == nombre)
                   .SingleOrDefault();
        }

       
    }



}