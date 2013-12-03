﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Repositories
{
    public class UserRepository
    {
        private RKDbContext db;

        public UserRepository()
        {
            db = new RKDbContext();
        }

        public IQueryable<User> GetAllUsers()
        {
            return db.Users.Select(x => new User {UserDetails = x}).AsQueryable();
        }

    }
}
