using System.Data.Entity;
using System.Linq;
using Repository.Models;

namespace Repository.Resources
{
    public class RoutingRepository
    {
        private RKConn db;

        public RoutingRepository()
        {
            db = new RKConn();
        }

        public IQueryable<routing_zones> GetAllZonesWithNeighbors()
        {
            var ok = db.routing_zones.Select(x => x).Include(x => x.routing_zone_neighbors.Select(a => a.routing_zones));
            return ok;
        }

        public IQueryable<routing_zone_neighbors> GetNeighborsByZone(routing_zones zone)
        {
            return db.routing_zone_neighbors.Where(x => x.rot_zon_id.Equals(zone.rot_zon_id));
        }
    }
}