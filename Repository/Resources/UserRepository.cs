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
        private RKDbContext db;

        public UserRepository()
        {
            db = new RKDbContext();
        }

        public IQueryable<UserDetails> GetAllUsers()
        {
            //return db.Users.Select(x => new User {UserDetails = x}).AsQueryable();
            var ok = db.Users;
            
            return ok;
        }

    }
}
