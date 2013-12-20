using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class WithdrawRepository
    {
        private RKConn _db;

        public WithdrawRepository()
        {
            _db = new RKConn();
        }

        public int InsertWithdraw(vault_withdraws withdraw)
        {
            _db.vault_withdraws.Add(withdraw);
            return _db.SaveChanges();
        }

        public IQueryable<vault_withdraws> GetWithdrawsByUser(int userId)
        {
            return _db.vault_withdraws.Where(x => x.usr_det_id.Equals(userId));
        }

        public vault_withdraws GetLatestWithdrawsByUserId(int value, DateTime timestamp)
        {
            return
                _db.vault_withdraws.FirstOrDefault(x => x.usr_det_id.Equals(value) && x.vau_wit_timestamp.Equals(timestamp));
        }
    }
}
