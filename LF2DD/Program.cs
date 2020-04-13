using System;
using System.IO;
using System.Text;

namespace LF2DD
{
    class Program
    {
        public const string Version = "1.0.0";

        private static void DisplayUsage()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine(" LF2DD.exe encrypt <file to encrypt> <output file>");
            Console.WriteLine(" LF2DD.exe decrypt <file to decrypt> <output file>");
            Console.WriteLine();
            Console.WriteLine("https://github.com/Mcpg/lf2dd");
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"LF2DD {Version} - LF2 Data file encryptor and decryptor by Damcpg");
            Console.WriteLine("--------------------------------------------------------------");

            if (args.Length != 3 || (args[0].ToLower() != "encrypt" && args[0].ToLower() != "decrypt"))
            {
                DisplayUsage();
                return;
            }

            string inputFilePath = args[1];
            string outputFilePath = args[2];

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Error: input file doesn't exist");
                Environment.Exit(1);
            }

            byte[] inputFileData = File.ReadAllBytes(inputFilePath);

            if (args[0].ToLower() == "encrypt")
            {
                Console.WriteLine($"Encrypting {inputFilePath} => {outputFilePath}...");
                File.WriteAllBytes(outputFilePath, EncryptionUtils.Encrypt(Encoding.ASCII.GetString(inputFileData)));
            }
            else if (args[0].ToLower() == "decrypt")
            {
                Console.WriteLine($"Decrypting {inputFilePath} => {outputFilePath}...");
                File.WriteAllText(outputFilePath, EncryptionUtils.Decrypt(inputFileData));
            }

            Console.WriteLine("Success!");
        }
    }
}
