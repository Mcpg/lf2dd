using System.Text;

namespace LF2DD
{
    /// <summary>
    /// A class containing LF2 data string encryption and decryption methods.
    /// The encryption algorithm is very simple, so just reading through the code should be enough.
    /// </summary>
    public static class EncryptionUtils
    {
        public const string EncryptionKey = "odBearBecauseHeIsVeryGoodSiuHungIsAGo";

        /// <summary>
        /// Encrypts an ASCII string into the LF2 format.
        /// </summary>
        /// <param name="data">string to encrypt</param>
        /// <returns>encrypted string</returns>
        public static byte[] Encrypt(string data)
        {
            byte[] asciiString = Encoding.ASCII.GetBytes(data);

            // Each encrypted file also has a 123-byte long header with uninitialized data, just because
            byte[] result = new byte[asciiString.Length + 123];

            for (int i = 0; i < asciiString.Length; i++)
            {
                result[i + 123] = (byte)(asciiString[i] + (int) EncryptionKey[i % (EncryptionKey.Length)]);
            }

            return result;
        }

        /// <summary>
        /// Decrypts a string in the LF2 format to an ASCII string
        /// </summary>
        /// <param name="encrypted">string to decrypt</param>
        /// <returns>decrypted string</returns>
        public static string Decrypt(byte[] encrypted)
        {
            byte[] result = new byte[encrypted.Length - 123];

            for (int i = 123; i < result.Length; i++)
            {
                result[i - 123] = (byte)(encrypted[i] - EncryptionKey[(i - 123) % (EncryptionKey.Length)]);
            }

            return Encoding.ASCII.GetString(result);
        }
	}
}
