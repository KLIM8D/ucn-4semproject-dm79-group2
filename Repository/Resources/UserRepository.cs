using System;
using System.Collections.Generic;
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
    }
}
