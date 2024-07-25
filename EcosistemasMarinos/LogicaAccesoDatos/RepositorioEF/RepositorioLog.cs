using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.RepositorioEF;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using EcosistemasMarinos.LogicaNegocio.Entidades;

namespace EcosistemasMarinos.LogicaAccesoDatos.RepositorioEF {
    public class RepositorioLog : IRepositorio<Log>
    {
        public EcosistemasMarinosContext Contexto { get; set; }

        public RepositorioLog(EcosistemasMarinosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Log obj)
        {
            try
            {
                obj.Validar(); 
                Contexto.Logs.Add(obj); 
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(Log obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Log obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Log> FindAll()
        {
            throw new NotImplementedException();
        }

        public Log FindById(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
