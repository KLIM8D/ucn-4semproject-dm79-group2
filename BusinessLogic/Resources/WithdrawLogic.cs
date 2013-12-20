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
        private readonly WithdrawRepository _withdrawRepository;
        public WithdrawLogic()
        {
            _withdrawRepository = new WithdrawRepository();
        }

        public bool SaveWithdraw(vault_withdraws withdraw)
        {
            _withdrawRepository.InsertWithdraw(withdraw);
            
            return true;
        }

        public IQueryable<vault_withdraws> GetWithdrawsByUserId(int userId)
        {
            return _withdrawRepository.GetWithdrawsByUser(userId);
        }
    }
}
