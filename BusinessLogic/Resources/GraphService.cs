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
            Cost = double.PositiveInfinity;
        }

        public int ID { get; set; }
        public bool Visited { get; set; }
        public double Cost { get; set; }
        public Vertex PreviousVertex { get; set; }
        public Edge PreviousEdge { get; set; }
        public List<Vertex> Neighbours { get; set; }
    }

    public class Edge
    {
        public int ID { get; set; }
        public Vertex SourceVertex { get; set; }
        public Vertex TargetVertex { get; set; }
        public double Cost { get; set; }
        public bool IsReverse { get; set; }
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


            v1.Neighbours.Add(v2);
            v1.Neighbours.Add(v3);

            v2.Neighbours.Add(v1);
            v2.Neighbours.Add(v4);
            v2.Neighbours.Add(v6);

            v3.Neighbours.Add(v1);
            v3.Neighbours.Add(v5);

            v4.Neighbours.Add(v2);
            v4.Neighbours.Add(v6);

            v5.Neighbours.Add(v3);
            v5.Neighbours.Add(v6);

            v6.Neighbours.Add(v2);
            v6.Neighbours.Add(v4);
            v6.Neighbours.Add(v5);
            v6.Neighbours.Add(v7);

            v7.Neighbours.Add(v6);

            Vertices.Add(v1);
            Vertices.Add(v2);
            Vertices.Add(v3);
            Vertices.Add(v4);
            Vertices.Add(v5);
            Vertices.Add(v6);
            Vertices.Add(v7);
        }

        public List<Vertex> GetDirections(int startId, int endId)
        {
            var returnList = new List<Vertex>();
            var q = new Queue<Vertex>();
            Visited = new Dictionary<Vertex, bool>();
            Nodes = new Dictionary<Vertex, Vertex>();

            var start = Vertices.FirstOrDefault(x => x.ID.Equals(startId));
            var end = Vertices.FirstOrDefault(x => x.ID.Equals(endId));

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

            return returnList;
        }
    }
}
