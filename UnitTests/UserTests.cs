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
        public void GetUserIdByUserName()
        {
            int userId = _userRepo.GetUserId("Morten");

            Assert.IsNotNull(userId);
        }

        [TestMethod]
        public void InsertUser()
        {
            User user = new User
                        {
                            fname = "Gunhild",
                            lname = "gunhild",
                            city = "Aalborg",
                            created_timestamp = DateTime.Now,
                            uname = "Test",
                            email = "CoolEmail@hotmail.com",
                            is_active = true,
                            passwd = "omg123",
                            phoneno = 28135473,
                            sec_group = "User",
                            zipcode = 9000,
                            street = "HenningVej 203",
                            ssn = Encoding.UTF8.GetBytes("2804900000")
                        };
            _userLogic.SaveUser(user);
        }
    }
}
