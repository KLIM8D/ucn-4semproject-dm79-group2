using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Resources;

namespace BusinessLogic.Resources
{
    public class DepositLogic
    {
        public bool SaveDeposit(vault_depositits deposit)
        {
            var depositRepository = new DepositRepository();
            depositRepository.InsertDeposit(deposit);

            return true;
        }

        public IQueryable<vault_depositits> GetDepositsByUserId(int userId)
        {
            var depositRepository = new DepositRepository();
            return depositRepository.GetDepositsByUserId(userId);
        }
    }
}