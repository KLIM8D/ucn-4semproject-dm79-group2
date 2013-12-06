using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Models;
using Repository.Resources;

namespace UnitTests
{
    [TestClass]
    public class UserTests
    {
        private UserRepository _userRepo;
        private UserLogic _userLogic;

        public UserTests()
        {
            _userRepo = new UserRepository();
            _userLogic = new UserLogic();
        }

        [TestMethod]
        public void GetUserById()
        {
            User user = _userRepo.GetUserById(1);

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void InsertUser()
        {
            User user = new User
                        {
                            fname = "Chris",
                            lname = "Tindbæk",
                            city = "Aabybro",
                            created_timestamp = DateTime.Now,
                            email = "Christind@hotmail.com",
                            is_active = true,
                            passwd = "chrischrischris",
                            phoneno = 28135473,
                            sec_group = "User",
                            ssn = 2804900000
                        };
            _userLogic.SaveUser(user);
        }
    }
}
