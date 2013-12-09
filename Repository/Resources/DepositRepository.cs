using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class DepositRepository
    {
        private RKConn db;

        public DepositRepository()
        {
            db = new RKConn();
        }

        public int InsertDeposit(vault_depositits deposit)
        {
            db.vault_depositits.Add(deposit);
            return db.SaveChanges();
        }
    }
}
