using System;
using System.Data.Entity.Core.Objects;
using System.Text;
using System.Collections.Generic;
using BusinessLogic.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Models;
using Repository.Resources;

namespace UnitTests
{
    [TestClass]
    public class DepositTests
    {
        private DepositRepository _depRepo;
        private DepositLogic _depLogic;

        public DepositTests()
        {
            _depRepo = new DepositRepository();
            _depLogic = new DepositLogic();
        }

        [TestMethod]
        public void InsertDeposit()
        {
            var deposit = new vault_depositits()
            {
                vau_dep_amount = 100,
                //vau_dep_timestamp = DateTime.Now,
                usr_det_id = 1
            };
            _depLogic.SaveDeposit(deposit);
        }
    }
}
