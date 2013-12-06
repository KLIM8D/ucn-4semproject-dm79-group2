using System;
using System.Collections.Generic;
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
            var ok = db.Database.SqlQuery<User>("exec getUserByUID @UID", param);

            return ok.FirstOrDefault();
        }

        public security_credentials GetCredentials(string userName)
        {
            return db.security_credentials.FirstOrDefault(x => x.sec_cre_uname.Equals(userName));
        }

        public void InsertDetails(user_details value)
        {
            db.user_details.Add(value);
            db.SaveChanges();
        }

        public void InsertSecurityCred(security_credentials value)
        {
            db.security_credentials.Add(value);
            db.SaveChanges();
        }
    }
}
