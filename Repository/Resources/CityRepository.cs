using System;
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
    }
}
