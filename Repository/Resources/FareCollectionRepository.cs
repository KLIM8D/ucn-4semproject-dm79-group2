using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Resources
{
    public class FareCollectionRepository
    {
         private RKConn _db;

        public FareCollectionRepository()
        {
            _db = new RKConn();
        }

        public int InsertFareCollection(collection_fares fares)
        {
            _db.collection_fares.Add(fares);
            return _db.SaveChanges();
        }

        public IQueryable<collection_fares> GetAllFaresByUserId(int userId)
        {
            return _db.collection_fares.Where(x => x.usr_det_id.Equals(userId)).Include(x => x.vault_withdraws);
        }

        public collection_fares GetCollectionFareByTravelId(int travelId)
        {
            return _db.collection_fares.FirstOrDefault(x => x.reg_tra_id.Equals(travelId));
        }
    }
}
