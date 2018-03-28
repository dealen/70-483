using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymetricAndAsymetricEncryptionTests
{
    public class BasicEncryptionAndDecryption : IRun
    {
        public void Run()
        {
            EncryptSymmetrically("komputer");
            ExportingAPublicKey();
        }

        private void EncryptSymmetrically(string text)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            using (SymmetricAlgorithm symethricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symethricAlgorithm, text);
                string roundTrip = Decrypt(symethricAlgorithm, encrypted);

                Console.WriteLine($"Original text: {text}");
                Console.WriteLine($"Encrypted: {encrypted}");
                Console.WriteLine($"Decrypted text: {roundTrip}");
            }
        }

        static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
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


        private void ExportingAPublicKey()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXml = rsa.ToXmlString(false);
            Console.WriteLine(publicKeyXml);
            Console.WriteLine("----------------------");
            string privateKeyXml = rsa.ToXmlString(true);
            Console.WriteLine(privateKeyXml);
        }
    }
}
