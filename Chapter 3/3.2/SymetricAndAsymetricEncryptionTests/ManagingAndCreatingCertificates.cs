using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SymetricAndAsymetricEncryptionTests
{
    public class ManagingAndCreatingCertificates : IRun
    {
        public void Run()
        {
            SigningAndVerifyingDataWithCertificate();
        }

        private void SigningAndVerifyingDataWithCertificate()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            SignAndVerify();
        }

        private void SignAndVerify()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            string textToSign = "test paragraph";
            byte[] signature = Sign(textToSign, "cn=WouterDeKort");
            // Uncomment this line to make the verification fail
            // signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }

        private byte[] Sign(string text, string certSubject)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(text);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        private bool Verify(string text, byte[] signature)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(text);
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        private byte[] HashData(string text)
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }

        private X509Certificate2 GetCertificate()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            X509Store my = new X509Store("testCertStore", StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }
    }
}
