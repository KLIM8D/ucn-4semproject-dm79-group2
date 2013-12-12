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

        public register_date_type InsertRegisterDateType(register_date_type registerDateType)
        {
            _db.register_date_type.Add(registerDateType);
            _db.SaveChanges();
            return registerDateType;
        }

    }
}