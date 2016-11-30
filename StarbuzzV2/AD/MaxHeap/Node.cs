using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.MaxHeap
{
    class Node
    {
        private int nodeItem;
        public Node(int value)
        { nodeItem = value; }
        public int getvalue()
        { return nodeItem; }
        public void setvalue(int id)
        { nodeItem = id; }
    }
}
