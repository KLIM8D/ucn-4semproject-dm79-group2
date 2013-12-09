using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Resources;
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
            byte[] key = new Hashing().MD5("Chris09-12-2013 14:12:31");
            byte[] encrypted = Encryption.EncryptString(original, key);
            
            string roundtrip = Encryption.DecryptString(encrypted, key);

            Assert.AreEqual(original, roundtrip);
        }

        [TestMethod]
        public void TestDecryptUser()
        {
            var userRepo = new UserRepository();

            const string original = "2804900000";
            var user = userRepo.GetUserById(11);
            byte[] key = new Hashing().MD5(user.uname + user.created_timestamp);
            string ssn = Encryption.DecryptString(user.ssn, key);

            Assert.AreEqual(original, ssn);
        }
    }
}
