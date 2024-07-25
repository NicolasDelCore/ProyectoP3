using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.RepositorioEF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public EcosistemasMarinosContext Contexto { get; set; }

        public RepositorioUsuario(EcosistemasMarinosContext ctx)
        {
            Contexto = ctx;
        }

        public void Add(Usuario obj)
        {
            bool usuarioExiste = Contexto.Usuarios.Any(u => u.Alias == obj.Alias); // Verificar si el alias ya existe en la base de datos

            if (obj == null) throw new InvalidOperationException("Error creando usuario: Objeto inválido o inexistente.");
            if (usuarioExiste) throw new InvalidOperationException("Error creando usuario: Alias no disponible.");
            obj.Validar();
            Contexto.Usuarios.Add(obj);
            Contexto.SaveChanges();
        }

        public void Delete(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int? id)
        {
            Usuario? encontrado = Contexto.Usuarios.Find(id);
            if (encontrado == null) throw new InvalidOperationException("No se encontró usuario con ese ID.");
            return encontrado;
        }

        public Usuario? FindByAlias(string alias)
        {
            if (alias.IsNullOrEmpty()) throw new InvalidOperationException("Nombre de usuario requerido.");

            var resultado = Contexto.Usuarios
                                    .Where(usuario => usuario.Alias == alias)
                                    .SingleOrDefault();
            return resultado;
        }
    }
}