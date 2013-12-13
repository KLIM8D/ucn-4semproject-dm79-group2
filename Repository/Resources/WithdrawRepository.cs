using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class WithdrawRepository
    {
        private RKConn db;

        public WithdrawRepository()
        {
            db = new RKConn();
        }

        public int InsertWithdraw(vault_withdraws withdraw)
        {
            db.vault_withdraws.Add(withdraw);
            return db.SaveChanges();
        }

        public IQueryable<vault_withdraws> GetWithdrawsByUser(int userId)
        {
            return db.vault_withdraws.Where(x => x.usr_det_id.Equals(userId));
        }
    }
}
