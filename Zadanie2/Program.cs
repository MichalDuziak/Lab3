using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            string testData = GenerateTestData(1024 * 1024); // 1MB test data
            byte[] dataBytes = Encoding.UTF8.GetBytes(testData);

            Console.WriteLine("Algorithm\tBlock Size\tTime (s/block)\tBytes/s (RAM)\tBytes/s (HDD)");

            // AES (CSP) 128 bit
            MeasurePerformance(new AesCryptoServiceProvider() { KeySize = 128 }, dataBytes, "AES (CSP) 128 bit");

            // AES (CSP) 256 bit
            MeasurePerformance(new AesCryptoServiceProvider() { KeySize = 256 }, dataBytes, "AES (CSP) 256 bit");

            // AES Managed 128 bit
            MeasurePerformance(new AesManaged() { KeySize = 128 }, dataBytes, "AES Managed 128 bit");

            // AES Managed 256 bit
            MeasurePerformance(new AesManaged() { KeySize = 256 }, dataBytes, "AES Managed 256 bit");

            // Rijndael Managed 128 bit
            MeasurePerformance(new RijndaelManaged() { KeySize = 128 }, dataBytes, "Rijndael Managed 128 bit");

            // Rijndael Managed 256 bit
            MeasurePerformance(new RijndaelManaged() { KeySize = 256 }, dataBytes, "Rijndael Managed 256 bit");

            // DES 56 bit
            MeasurePerformance(new DESCryptoServiceProvider(), dataBytes, "DES 56 bit");

            // 3DES 168 bit
            MeasurePerformance(new TripleDESCryptoServiceProvider(), dataBytes, "3DES 168 bit");
        }

        static string GenerateTestData(int size)
        {
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                sb.Append((char)rnd.Next(32, 127)); // Generate printable ASCII characters
            }
            return sb.ToString();
        }

        static void MeasurePerformance(SymmetricAlgorithm algorithm, byte[] dataBytes, string algorithmName)
        {
            algorithm.GenerateKey();
            algorithm.GenerateIV();

            var stopwatch = new Stopwatch();
 
            stopwatch.Start();
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor())
            {
                byte[] encrypted = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);
            }
            stopwatch.Stop();
            double encryptionTimeRAM = stopwatch.Elapsed.TotalSeconds;
            double bytesPerSecondRAM = dataBytes.Length / encryptionTimeRAM;

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllBytes(tempFilePath, dataBytes);

            byte[] fileDataBytes = File.ReadAllBytes(tempFilePath);
            stopwatch.Restart();
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor())
            {
                byte[] encrypted = encryptor.TransformFinalBlock(fileDataBytes, 0, fileDataBytes.Length);
            }
            stopwatch.Stop();
            double encryptionTimeHDD = stopwatch.Elapsed.TotalSeconds;
            double bytesPerSecondHDD = fileDataBytes.Length / encryptionTimeHDD;

            File.Delete(tempFilePath);

            Console.WriteLine($"{algorithmName}\t{algorithm.BlockSize}\t{encryptionTimeRAM:F6}\t{bytesPerSecondRAM:F2}\t{bytesPerSecondHDD:F2}");
        }
    }
}
