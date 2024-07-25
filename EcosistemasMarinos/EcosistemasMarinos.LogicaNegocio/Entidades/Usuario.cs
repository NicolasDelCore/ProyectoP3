//using ExcepcionesPropias;
//using LogicaNegocio.Enums;
//using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Buffers.Text;
using EcosistemasMarinos.LogicaNegocio.Tools;
using EcosistemasMarinos.LogicaNegocio.ExcepcionesEntidades;
using EcosistemasMarinos.LogicaNegocio.InterfacesEntidades;
using EcosistemasMarinos.LogicaNegocio.Enums;
using System.Data;

namespace EcosistemasMarinos.LogicaNegocio.Entidades {

    public class Usuario : IValidable<Usuario>
    {
        #region Properties
        public int Id { get; set; }
        [MaxLength(50)]
        public string Alias { get; set; }
        //Política de password: // (mínimo 8 caracteres, debe tener mínimo 1 mayúscula, 1 minúscula, 1 número y 1 carácter especial de los siguientes: . , # ; : ! además un máximo de 50 caracteres estará bien, actualmente se recomienda entre 14 y 16 o más)
        //Para dar espacio de sobra, el password encriptado tendrá un maxlength de 150 caracteres y el IV 256.
        [MaxLength(150)]
        public string PasswordEncriptado { get; set; } //el password es encriptado con AES-256 y luego guardado con base64 para consistencia y compatibilidad con la base de datos / otros sistemas
        [MaxLength(256)]
        public byte[] PasswordIV { get; set; }
        [MaxLength(50)]
        public string PasswordPlano { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Roles? Rol { get; set; }
        #endregion

        #region Constructores
        public Usuario() { }

        public Usuario(string alias, string password, Roles? rol)
        {
            Alias = alias;
            PasswordPlano = password;
            FechaRegistro = DateTime.Now;
            Rol = rol;

            //Encriptar password con AES-256, docu de Microsoft citada abajo en la firma del método
            using (Aes myAes = Aes.Create())
            {
                // Encrypt the string to an array of bytes.
                byte[] encrypted = Encriptador.EncriptamientoAES(PasswordPlano, myAes.IV);
                PasswordEncriptado = Convert.ToBase64String(encrypted);
                PasswordIV = myAes.IV;
            }
        }
        #endregion

        #region Validaciones
        public void Validar() {
            if (Alias.Count() < 6 || Alias.Count() > 50) throw new UsuarioException("Error validando Usuario: Alias debe estar entre 6 y 50 caracteres.");
            if (Rol == null) throw new UsuarioException("Error validando Usuario: No se asignó un rol.");
            if (PasswordPlano.Count() < 8 || !PasswordPlano.Any(char.IsLower) || !PasswordPlano.Any(char.IsUpper) || !PasswordPlano.Any(char.IsNumber) || !ValidarPassChar.validarPassword(PasswordPlano)) throw new UsuarioException("Error validando Usuario: La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y uno de los siguientes símbolos: . , # ; : ! ");
            if (FechaRegistro == DateTime.MinValue) throw new UsuarioException("Error validando Usuario: No se pudo asignar una fecha de creación.");
        }
        #endregion
    }
}
