using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Graph
{
    class Vertex
    {
        public string name;
        public ICollection<Edge> adj;
        public double dist;
        public Vertex prev;
        public int scratch;

        public Vertex(string name) {
            this.name = name;
            adj = new LinkedList<Edge>();
            reset();
        }

        public void reset()
        {
            dist = Graph.INFINITY;
            prev = null;
            //pos = null;
            scratch = 0;
        }
    }
}
