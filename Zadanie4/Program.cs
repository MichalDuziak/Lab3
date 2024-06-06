using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Zadanie4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ustaw ścieżki do plików
            string inputFilePath = "input.txt";
            string encryptedFilePath = "encrypted.bin";
            string decryptedFilePath = "decrypted.txt";

            // Stwórz klucze RSA
            RSACryptoServiceProvider myRSA = new RSACryptoServiceProvider(2048);
            AesManaged myAES = new AesManaged();

            // Generowanie klucza AES
            myAES.GenerateKey();
            byte[] RSAciphertext = myRSA.Encrypt(myAES.Key, true);

            // Zapisz klucz RSA do pliku
            File.WriteAllBytes("RSA_key.bin", myRSA.ExportCspBlob(true));

            // Szyfrowanie pliku
            EncryptFile(inputFilePath, encryptedFilePath, myAES);
            Console.WriteLine("File encrypted.");

            // Deszyfrowanie klucza AES za pomocą RSA
            byte[] decryptedAESKey = myRSA.Decrypt(RSAciphertext, true);
            myAES.Key = decryptedAESKey;

            // Deszyfrowanie pliku
            DecryptFile(encryptedFilePath, decryptedFilePath, myAES);
            Console.WriteLine("File decrypted.");

            // Podpisywanie wiadomości
            string message = "this is an important message";
            byte[] signature = SignData(myRSA, message);
            Console.WriteLine("Message signed.");

            // Weryfikacja podpisu
            bool verified = VerifyData(myRSA, message, signature);
            Console.WriteLine($"Signature verified: {verified}");
        }

        static void EncryptFile(string inputFilePath, string outputFilePath, AesManaged aes)
        {
            aes.GenerateIV();
            byte[] iv = aes.IV;

            using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Create))
            {
                fileStream.Write(iv, 0, iv.Length);

                using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open))
                    {
                        inputFileStream.CopyTo(cryptoStream);
                    }
                }
            }
        }

        static void DecryptFile(string inputFilePath, string outputFilePath, AesManaged aes)
        {
            using (FileStream fileStream = new FileStream(inputFilePath, FileMode.Open))
            {
                byte[] iv = new byte[16];
                fileStream.Read(iv, 0, iv.Length);
                aes.IV = iv;

                using (CryptoStream cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create))
                    {
                        cryptoStream.CopyTo(outputFileStream);
                    }
                }
            }
        }

        static byte[] SignData(RSACryptoServiceProvider rsa, string data)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] dataBytes = Encoding.ASCII.GetBytes(data);
                return rsa.SignData(dataBytes, sha256);
            }
        }

        static bool VerifyData(RSACryptoServiceProvider rsa, string data, byte[] signature)
        {
            using (SHA256Managed sha256 = new SHA256Managed())
            {
                byte[] dataBytes = Encoding.ASCII.GetBytes(data);
                return rsa.VerifyData(dataBytes, sha256, signature);
            }
        }
    }
}
