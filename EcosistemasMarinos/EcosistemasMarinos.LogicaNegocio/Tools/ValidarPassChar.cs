using System.Security.Cryptography;

namespace EcosistemasMarinos.LogicaNegocio.Tools {
    public abstract class ValidarPassChar {
        public static bool validarPassword(string pass) {
            char[] simbolosValidos = new char[] { '.', ',', '#', ';', ':', '!' };
            foreach (char simbolo in simbolosValidos) {
                if (pass.Contains(simbolo)) return true;
            }
            return false;
        }
    }
}