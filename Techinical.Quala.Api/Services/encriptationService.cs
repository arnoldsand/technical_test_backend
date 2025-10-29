using System.Security.Cryptography;
using System.Text;

namespace Techinical.Quala.Api.Services
{
    public class encriptationService: IencriptationService
    {
        // Define el tamaño de la clave y el IV requerido por AES.
        // **IMPORTANTE:** La clave DEBE tener 16, 24 o 32 bytes de longitud.
        private const int KeySize = 32; // 256 bits
        private const int IvSize = 16;  // 128 bits

        /// <summary>
        /// Encripta una cadena de texto usando AES con la llave secreta proporcionada.
        /// </summary>
        /// <param name="plainText">La cadena a cifrar.</param>
        /// <param name="keyString">La llave secreta (debe ser de 32 caracteres/bytes para 256-bit).</param>
        /// <returns>La cadena cifrada en formato Base64.</returns>
        public string Encrypt(string plainText)
        {
            string keyString = "#fdafAADV#$%%&dxddDDYDSKDHSDKUUE";
            // 1. Validar la clave y el texto
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if (string.IsNullOrEmpty(keyString))
                throw new ArgumentNullException(nameof(keyString));

            byte[] key = Encoding.UTF8.GetBytes(keyString);
            if (key.Length != KeySize)
                throw new ArgumentException($"La llave debe tener {KeySize} bytes (32 caracteres UTF8) para el cifrado AES-256.");

            // 2. Crear un objeto AES
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.CBC; // Modo de operación: Cipher Block Chaining (estándar)
                aesAlg.Padding = PaddingMode.PKCS7; // Relleno: PKCS7

                // 3. Generar un Vector de Inicialización (IV) aleatorio y único
                //    El IV es crucial para la seguridad y DEBE ser único por cada cifrado.
                aesAlg.GenerateIV();
                byte[] iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // 4. Cifrar los datos
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Escribir el IV primero en el flujo (necesario para la desencriptación)
                    msEncrypt.Write(iv, 0, iv.Length);

                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }
                    // 5. Devolver el IV + el texto cifrado en Base64
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Desencripta una cadena cifrada usando AES con la llave secreta.
        /// </summary>
        public string Decrypt(string cipherText)
        {
            string keyString = "#fdafAADV#$%%&dxddDDYDSKDHSDKUUE";
            // 1. Validar la clave
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));
            if (string.IsNullOrEmpty(keyString))
                throw new ArgumentNullException(nameof(keyString));

            byte[] key = Encoding.UTF8.GetBytes(keyString);
            if (key.Length != KeySize)
                throw new ArgumentException($"La llave debe tener {KeySize} bytes (32 caracteres UTF8) para el cifrado AES-256.");

            // 2. Convertir de Base64 a bytes
            byte[] cipherTextBytesWithIv = Convert.FromBase64String(cipherText);

            // 3. Extraer el Vector de Inicialización (IV)
            if (cipherTextBytesWithIv.Length < IvSize)
                throw new FormatException("Texto cifrado inválido: falta el IV.");

            byte[] iv = new byte[IvSize];
            Array.Copy(cipherTextBytesWithIv, 0, iv, 0, IvSize);

            // 4. Extraer el texto cifrado (sin el IV)
            int cipherTextLength = cipherTextBytesWithIv.Length - IvSize;
            byte[] cipherTextBytes = new byte[cipherTextLength];
            Array.Copy(cipherTextBytesWithIv, IvSize, cipherTextBytes, 0, cipherTextLength);

            // 5. Crear objeto AES y desencriptar
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
