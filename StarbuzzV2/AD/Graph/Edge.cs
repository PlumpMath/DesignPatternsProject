using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Graph
{
    class Edge
    {
        public Vertex dest;
        public double cost;

        public Edge(Vertex dest, double cost) {
            this.dest = dest;
            this.cost = cost;
        }
    }
}
