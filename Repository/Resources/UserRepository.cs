using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class UserRepository
    {
        private RKConn db;

        public UserRepository()
        {
            db = new RKConn();
        }

        //public IQueryable<> GetAll()
        //{
        //    return db.user_details;
        //}

        //public User GetById(int id)
        //{
        //    return;
        //}

        public User GetUserById(int id)
        {
            var param = new SqlParameter("@UID", id);
            var query = db.Database.SqlQuery<User>("exec getUserByUID @UID", param);

            return query.FirstOrDefault();
        }

        public int GetUserId(string userName)
        {
            //var ok = db.security_credentials.Where(x => x.sec_cre_uname.Equals(userName))
            //        .Select(x => x.user_details.FirstOrDefault().usr_det_id).FirstOrDefault();
            //return ok;
            security_credentials secCred = db.security_credentials.FirstOrDefault(x => x.sec_cre_uname.Equals(userName));
            user_details userDet = db.user_details.FirstOrDefault(x => x.sec_cre_id.Equals(secCred.sec_cre_id));
            if (userDet != null)
            {
                return userDet.usr_det_id;
            }
            return -1;
        }

        public security_credentials GetCredentials(string userName)
        {
            return db.security_credentials.FirstOrDefault(x => x.sec_cre_uname.Equals(userName));
        }

        public user_details InsertDetails(user_details value)
        {
            db.user_details.Add(value);
            db.SaveChanges();

            return value;
        }

        public security_credentials InsertSecurityCred(security_credentials value)
        {
            db.security_credentials.Add(value);
            db.SaveChanges();

            return value;
        }

        public bool ValidateCred(string userName, string password)
        {
            return db.security_credentials.Any(x => x.sec_cre_uname.Equals(userName) && x.sec_cre_passwd.Equals(password));
        }

        public int GetUidByCardNo(int value)
        {
            var cardIssued = db.card_issued.FirstOrDefault(x => x.car_iss_no.Equals(value));
            return cardIssued != null ? cardIssued.usr_det_id : 0;
        }
    }
}