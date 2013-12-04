using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Resources;

namespace UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateUser()
        {
            
        }

        [TestMethod]
        public void GetAllUsers()
        {
            var userRepo = new UserRepository();
            var users = userRepo.GetAllUsers();

            Assert.IsTrue(users.Any());
        }
    }
}
