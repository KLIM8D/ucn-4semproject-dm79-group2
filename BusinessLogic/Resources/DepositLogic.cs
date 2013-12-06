using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Resources;

namespace BusinessLogic.Resources
{
    class DepositLogic
    {
        public bool SaveDeposit(Deposit deposit)
        {
            DepositRepository depositRepository = new DepositRepository();
            depositRepository.InsertDeposit(deposit);

            return true;
        }
    }
}
