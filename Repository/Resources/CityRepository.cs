﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class CityRepository
    {
        private RKConn db;

        public CityRepository()
        {
            db = new RKConn();
        }

        public geo_zipcodes GetCity(int zipCode)
        {
            return db.geo_zipcodes.FirstOrDefault(x => x.geo_zip_code.Equals(zipCode));
        }

        public void InsertZipCode(geo_zipcodes value)
        {
            db.geo_zipcodes.Add(value);
            db.SaveChanges();
        }

        public void InsertUserAddress(user_address value)
        {
            db.user_address.Add(value);
            db.SaveChanges();
        }
    }
}
