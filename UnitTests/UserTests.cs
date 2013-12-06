using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Models;
using Repository.Resources;

namespace UnitTests
{
    [TestClass]
    public class UserTests
    {
        private UserRepository _userRepo;

        public UserTests()
        {
            _userRepo = new UserRepository();
        }

        [TestMethod]
        public void GetUserById()
        {
            User user = _userRepo.GetUserById(1);

            Assert.IsNotNull(user);
        }
    }
}
