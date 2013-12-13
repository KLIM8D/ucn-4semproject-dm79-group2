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

        public int GetTransitIdFromAreaId(int value)
        {
            var transitLocations = _db.transit_locations.FirstOrDefault(x => x.tra_loc_area_id.Equals(value));
            return transitLocations != null ? transitLocations.tra_loc_id : 0;
        }
    }
}