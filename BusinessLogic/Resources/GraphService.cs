using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Resources;
using Utils.DataTypes;

namespace BusinessLogic.Resources
{
    public class Vertex
    {
        public Vertex()
        {
            Neighbours = new List<Vertex>();
        }

        public int ID { get; set; }
        public List<Vertex> Neighbours { get; set; }
    }

    public class GraphService
    {
        public List<routing_zones> Vertices { get; set; } 
        public Dictionary<int, bool> Visited { get; set; }
        public Dictionary<routing_zones, routing_zones> Nodes { get; set; }
        private RoutingRepository RouteRepo;

        public GraphService()
        {
            RouteRepo = new RoutingRepository();
            Vertices = RouteRepo.GetAllZonesWithNeighbors().ToList();
        }

        public List<routing_zones> GetDirections(int startId, int endId)
        {
            var returnList = new List<routing_zones>();
            var q = new Queue<routing_zones>();
            Visited = new Dictionary<int, bool>();
            Nodes = new Dictionary<routing_zones, routing_zones>();

            var start = Vertices.FirstOrDefault(x => x.rot_zon_area_id.Equals(startId));
            var end = Vertices.FirstOrDefault(x => x.rot_zon_area_id.Equals(endId));

            if(start == null)
                throw new Exception("Could not find start vertice with specified ID: " + startId);
            if (end == null)
                throw new Exception("Could not find end vertice with specified ID: " + endId);

            var current = start;
            q.Enqueue(current);
            Visited.Add(current.rot_zon_area_id, true);

            while (q.Any())
            {
                current = q.Dequeue();
                if (current.rot_zon_area_id.Equals(end.rot_zon_area_id))
                    break;
                else
                {
                    foreach (var vertex in current.routing_zone_neighbors)
                    {
                        if (!Visited.ContainsKey(vertex.rot_zon_ngr_area))
                        {
                            q.Enqueue(Vertices.FirstOrDefault(x => x.rot_zon_area_id.Equals(vertex.rot_zon_ngr_area)));
                            Visited.Add(vertex.rot_zon_ngr_area, true);
                            Nodes.Add(Vertices.FirstOrDefault(x => x.rot_zon_area_id.Equals(vertex.rot_zon_ngr_area)), current);
                        }
                    }
                }
            }

            if (!current.rot_zon_area_id.Equals(end.rot_zon_area_id))
                return null;

            returnList.Add(end);
            for (var node = end; Nodes.TryGetValue(node, out node);)
                returnList.Add(node);

            returnList.Reverse();

            return returnList;
        }

        public int TravelPrice(int startId, int endId)
        {
            int i = GetDirections(startId, endId).Count;
            return i == 1 ? 20 : i*10; // if you travel in 1 zone you pay 20, if you travel more than 1 zone you pay 10 for each zone
        }
    }
}