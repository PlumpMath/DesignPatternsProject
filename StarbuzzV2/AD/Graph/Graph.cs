using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Graph
{
    class Graph
    {
        public static readonly double INFINITY = double.MaxValue;

        private Dictionary<string, Vertex> _vertexMap = new Dictionary<string, Vertex>();
        public void addEdge(string sourceName, string destName, double cost) {
            Vertex v = getVertex(sourceName);
            Vertex w = getVertex(destName);
            v.adj.Add(new Edge(w, cost));
        }

        public void printPath(string destName) {
            Vertex w;
            bool exist = _vertexMap.TryGetValue(destName, out w);
            if (!exist)
            {
                throw new ArgumentException();
            }
            else if (w.dist == INFINITY)
            {
                Console.WriteLine(destName + " is unreachable");
            }
            else
            {
                Console.WriteLine("(Cost is: "+ w.dist +") ");
                printPath(w);
                Console.WriteLine();
            }

        }

        public void unweighted(string startName) {
            clearAll();
            Vertex start = _vertexMap[startName];
            Queue<Vertex> q = new Queue<Vertex>();
            q.Enqueue(start);start.dist = 0;
            while (q.Count != 0) {
                Vertex v = q.Dequeue();

                foreach(Edge e in v.adj) {
                    Vertex w = e.dest;

                    if (w.dist == INFINITY) {
                        w.dist = v.dist + 1;
                        w.prev = v;
                        q.Enqueue(w);
                    }
                }
            }
            
        }

        public void dijkstra(string startName) {
            Queue<Path> q = new Queue<Path>();

            Vertex start = _vertexMap[startName];

            clearAll();
            q.Enqueue(new Path(start,0));
            start.dist = 0;

            int nodesSeen = 0;
            while (q.Count != 0 && nodesSeen < _vertexMap.Count) {
                Path vrec = q.Dequeue();
                Vertex v = vrec.dest;
                if (v.scratch != 0) {
                    continue;
                }

                v.scratch = 1;
                nodesSeen++;

                foreach (Edge e in v.adj) {
                    Vertex w = e.dest;
                    double cvw = e.cost;

                    if (cvw < 0) {
                        throw new Exception("Graph has negative edges");
                    }

                    if (w.dist > v.dist + cvw)
                    {
                        w.dist = v.dist + cvw;
                        w.prev = v;
                        q.Enqueue(new Path(w,w.dist));
                    }
                }
            }

        }

        public void negative(string startName) {

        }

        public void acyclic(string startName) {

        }

        private Vertex getVertex(string vertexName) {
            Vertex v;
            if (!_vertexMap.TryGetValue(vertexName, out v))
            {
                v = new Vertex(vertexName);
                _vertexMap[vertexName] = v;
            }
            return v;
        }

        private void printPath(Vertex dest) {
            if (dest.prev != null) {
                printPath(dest.prev);
                Console.WriteLine(" to ");
            }
            Console.WriteLine(dest.name);
        }

        private void clearAll() {
            foreach(Vertex v in _vertexMap.Values) {
                v.reset();
            }
        }

        
    }
}
