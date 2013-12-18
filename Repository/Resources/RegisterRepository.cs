using System;
using System.Collections.Generic;
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

        public register_travel GetLatestTravelsByUserId(int value)
        {
            return _db.register_travel.Where(x => x.usr_det_id.Equals(value))
                .OrderByDescending(x => x.reg_tra_timestamp).FirstOrDefault();
        }

        public IQueryable<register_travel> IsAContinuedJourney(int userId)
        {
            var date = DateTime.Now.AddHours(-1);
            var call1 = _db.register_travel.Where(x => x.usr_det_id.Equals(userId) && x.reg_dat_typ_id == 1 && x.reg_tra_timestamp >= date)
                    .OrderByDescending(y => y.reg_tra_timestamp).Take(2);
            if (call1.Count() < 2)
                return null;

            var v1 = call1.FirstOrDefault(); //Last checkin
            var v2 = call1.ToList()[1]; //First checkin

            if (v2.reg_tra_timestamp.AddHours(1) < v1.reg_tra_timestamp) //Complicated shiiet
                return null;

            return
                _db.register_travel.Where(x => x.usr_det_id.Equals(userId) 
                    && x.reg_tra_timestamp >= date).Take(4)
                    .OrderByDescending(y => y.reg_tra_timestamp).Include(h => h.transit_locations.routing_zones).Take(2); //Birds droppin from the sky
        }

        public register_date_type InsertRegisterDateType(register_date_type registerDateType)
        {
            _db.register_date_type.Add(registerDateType);
            _db.SaveChanges();
            return registerDateType;
        }
    }
}