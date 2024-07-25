using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio
{
	public interface IRepositorio<T> where T : class
	{
        void Add(T obj);
        void Update(T obj);
		//void Update(int id, T obj);
		void Delete(T obj);
		//void Delete(int? id);
		IEnumerable<T> FindAll();
		T FindById(int? id);
	}
}
