using System.Data.Entity;
using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class TransitRepository
    {
        private readonly RKConn _db;

        public TransitRepository()
        {
            _db = new RKConn();
        }

        public transit_locations GetAreaFromStationId(int value)
        {
            return _db.transit_locations.Where(x => x.tra_loc_id.Equals(value)).Include(y => y.routing_zones.transit_locations).FirstOrDefault();
        }
    }
}