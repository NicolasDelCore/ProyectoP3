using System.Security.Cryptography;

namespace EcosistemasMarinos.LogicaNegocio.Tools
{

    public abstract class Encriptador {

	//Encryption Key
	private static string EncryptionKeyB64 = "PJC7HnliwcxXw4FM8Ep3sX9NIL3R5CZnDvp8IyyCSlg=";

        //Sistema de encriptación AES-256: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.aes?view=net-7.0&redirectedfrom=MSDN
        public static byte[] EncriptamientoAES(string plainText, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0) throw new ArgumentNullException("Error: no hay texto a encriptar");
            if (IV == null || IV.Length <= 0) throw new ArgumentNullException("Error: no hay IV para encriptar");

            //KEY, dejada en código por pedido del profe
            var base64Bytes = Convert.FromBase64String(EncryptionKeyB64);
            byte[] encryptionKey = base64Bytes;

            byte[] encrypted;

            //Crear objeto AES con la Key y el IV especificados
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = 256;
                aesAlg.IV = IV;
                aesAlg.Key = encryptionKey;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(encryptionKey, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public static string DesencriptamientoAES(byte[] cipherText, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0) throw new ArgumentNullException("Error: no hay texto a desencriptar");
            if (IV == null || IV.Length <= 0) throw new ArgumentNullException("Error: no hay IV para desencriptar");

            //KEY, dejada en código por pedido del profe
            var base64Bytes = Convert.FromBase64String(EncryptionKeyB64);
            byte[] encryptionKey = base64Bytes;

            // Declare the string used to hold
            // the decrypted text.
            string? plaintext = null;

            // Create an Aes object with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = encryptionKey;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        //implementar o no perder tiempo con hasheo?
        //Sistema de hasheo SHA-256 https://stackoverflow.com/questions/20621950/asp-net-identitys-default-password-hasher-how-does-it-work-and-is-it-secure
    }
}
