using System;
using System.Security.Cryptography;
using System.Text;
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
            string keyString = "User1" + DateTime.Now;
            byte[] key = Encoding.UTF8.GetBytes(keyString);
            byte[] encrypted = Encryption.EncryptString(original, key);
            
            string roundtrip = Encryption.DecryptString(encrypted, key);

            Assert.AreEqual(original, roundtrip);
        }
    }
}
