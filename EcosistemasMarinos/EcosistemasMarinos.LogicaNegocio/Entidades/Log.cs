using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcosistemasMarinos.LogicaNegocio.Entidades;
using EcosistemasMarinos.LogicaNegocio.Enums;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;

namespace EcosistemasMarinos.LogicaNegocio.Entidades
{
    public class Log : IValidable<Log> {
        #region Properties
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string ObjetoModificado { get; set; }
        public int? EntidadId { get; set; }
        public string Operacion { get; set; }
        #endregion

        #region Constructores
        public Log() { }
        public Log(string usuario, Objetos objetoModificado, int? entidadId, Operaciones operacion)
        {
            Usuario = usuario;
            Fecha = DateTime.Now;
            ObjetoModificado = objetoModificado.ToString();
            EntidadId = entidadId;
            Operacion = operacion.ToString();
        }
        #endregion

        #region Validaciones
        public void Validar() {
            if (Usuario == null) throw new LogException("Error al crear Log: Usuario no puede estar vacío.");
            if (EntidadId < 0) throw new LogException("Error al crear Log: Se espera un Id válido ( > 0) para la Entidad modificada.");
            //los enums no necesitan null checks porque no se les declaró null o vacío declarado como valor válido, ni son nullables
        }
        #endregion
    }
}
