using System;
using System.Data.Entity;
using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class RegisterRepository
    {
        private readonly RKConn _db;

        public RegisterRepository()
        {
            _db = new RKConn();
        }

        public register_travel InsertRegisterTravel(register_travel registerTravel)
        {
            _db.register_travel.Add(registerTravel);
            _db.SaveChanges();
            return registerTravel;
        }

        public IQueryable<register_travel> GetRegisterTravelByUserId(int value)
        {
            return _db.register_travel.Where(x => x.usr_det_id.Equals(value)).Include(t => t.transit_locations);
        }

        public bool IsAContinuedJourney(int userId)
        {
            return _db.register_travel.Where(x => x.usr_det_id.Equals(userId))
                    .Any(y => y.reg_tra_timestamp > DateTime.Now.AddHours(-1));
        }

        public register_date_type InsertRegisterDateType(register_date_type registerDateType)
        {
            _db.register_date_type.Add(registerDateType);
            _db.SaveChanges();
            return registerDateType;
        }
    }
}