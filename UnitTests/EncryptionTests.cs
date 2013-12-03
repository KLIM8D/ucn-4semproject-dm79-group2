using System;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Security;

namespace UnitTests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void TestDecrypt()
        {
            const string original = "Here is some data to encrypt!";
            // Create a new instance of the AesCryptoServiceProvider 
            // class.  This generates a new key and initialization vector (IV). 
            var enc = new Encryption();
            using (var myAes = new AesCryptoServiceProvider())
            {
                // Encrypt the string to an array of bytes. 
                byte[] encrypted = enc.EncryptStringToBytes(original, myAes.Key, myAes.IV);
                // Decrypt the bytes to a string. 
                string roundtrip = enc.DecryptStringFromBytes(encrypted, myAes.Key, myAes.IV);

                Assert.AreEqual(original, roundtrip);
            }
        }
    }
}
