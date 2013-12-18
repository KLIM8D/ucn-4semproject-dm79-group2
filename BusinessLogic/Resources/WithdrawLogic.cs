using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Resources;

namespace BusinessLogic.Resources
{
    public class WithdrawLogic
    {
        public bool SaveDeposit(vault_withdraws withdraw)
        {
            var withdrawRepository = new WithdrawRepository();
            withdrawRepository.InsertWithdraw(withdraw);

            return true;
        }

        public IQueryable<vault_withdraws> GetWithdrawsByUserId(int userId)
        {
            var withdrawRepository = new WithdrawRepository();
            return withdrawRepository.GetWithdrawsByUser(userId);
        }
    }
}
