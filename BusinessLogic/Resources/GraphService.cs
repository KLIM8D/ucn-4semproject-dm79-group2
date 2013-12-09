using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<Vertex> Vertices { get; set; } 
        public Dictionary<Vertex, bool> Visited { get; set; }
        public Dictionary<Vertex, Vertex> Nodes { get; set; }

        public GraphService()
        {
            Vertices = new List<Vertex>();
            var v1 = new Vertex() {ID = 1, Neighbours = new List<Vertex>()};
            var v2 = new Vertex() {ID = 2, Neighbours = new List<Vertex>()};
            var v3 = new Vertex() {ID = 3, Neighbours = new List<Vertex>()};
            var v4 = new Vertex() {ID = 4, Neighbours = new List<Vertex>()};
            var v5 = new Vertex() {ID = 5, Neighbours = new List<Vertex>()};
            var v6 = new Vertex() {ID = 6, Neighbours = new List<Vertex>()};
            var v7 = new Vertex() {ID = 7, Neighbours = new List<Vertex>()};
            var v8 = new Vertex() {ID = 8, Neighbours = new List<Vertex>()};


            v1.Neighbours.Add(v2);
            v1.Neighbours.Add(v8);

            v2.Neighbours.Add(v1);
            v2.Neighbours.Add(v3);

            v3.Neighbours.Add(v2);
            v3.Neighbours.Add(v4);
            v3.Neighbours.Add(v8);

            v4.Neighbours.Add(v3);
            v4.Neighbours.Add(v7);

            v5.Neighbours.Add(v6);

            v6.Neighbours.Add(v5);
            v6.Neighbours.Add(v6);

            v7.Neighbours.Add(v4);
            v7.Neighbours.Add(v6);
            v7.Neighbours.Add(v8);

            v8.Neighbours.Add(v1);
            v8.Neighbours.Add(v3);
            v8.Neighbours.Add(v7);

            Vertices.Add(v1);
            Vertices.Add(v2);
            Vertices.Add(v3);
            Vertices.Add(v4);
            Vertices.Add(v5);
            Vertices.Add(v6);
            Vertices.Add(v7);
            Vertices.Add(v8);
        }

        public List<Vertex> GetDirections(int startId, int endId)
        {
            var returnList = new List<Vertex>();
            var q = new Queue<Vertex>();
            Visited = new Dictionary<Vertex, bool>();
            Nodes = new Dictionary<Vertex, Vertex>();

            var start = Vertices.FirstOrDefault(x => x.ID.Equals(startId));
            var end = Vertices.FirstOrDefault(x => x.ID.Equals(endId));

            if(start == null)
                throw new Exception("Could not find start vertice with specified ID: " + startId);
            if (end == null)
                throw new Exception("Could not find end vertice with specified ID: " + endId);

            var current = start;
            q.Enqueue(current);
            Visited.Add(current, true);

            while (q.Any())
            {
                current = q.Dequeue();
                if (current.ID.Equals(end.ID))
                    break;
                else
                {
                    foreach (var vertex in current.Neighbours)
                    {
                        if (!Visited.ContainsKey(vertex))
                        {
                            q.Enqueue(vertex);
                            Visited.Add(vertex, true);
                            Nodes.Add(vertex, current);
                        }
                    }
                }
            }

            if (!current.ID.Equals(end.ID))
                return null;

            returnList.Add(end);
            for (var node = end; Nodes.TryGetValue(node, out node);)
                returnList.Add(node);

            returnList.Reverse();

            return returnList;
        }
    }
}
