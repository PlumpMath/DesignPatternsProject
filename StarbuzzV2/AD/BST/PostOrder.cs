using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.BST
{
    class PostOrder<T> : TreeIterator<T> where T : IComparable
    {
        protected Stack<StNode> s;
        protected class StNode {
            BinaryNode<T> node;
            int timesPopped;

            public StNode(BinaryNode<T> n) {
                Node = n; TimesPopped = 0;
            }

            public BinaryNode<T> Node
            {
                get
                {
                    return node;
                }

                set
                {
                    node = value;
                }
            }

            public int TimesPopped
            {
                get
                {
                    return timesPopped;
                }

                set
                {
                    timesPopped = value;
                }
            }
        }

        public PostOrder(BinaryTree<T> theThree): base(theThree) {
            s = new Stack<StNode>();
            s.Push(new StNode(t.Root));
        }

        public override void advance()
        {
            if (s.Count == 0) {
                if (current == null) {
                    throw new Exception("No such element");
                }
                current = null;
                return;
            }

            StNode cnode;
            while (true) {
                cnode = s.Pop();
                if (++cnode.TimesPopped == 3) {
                    current = cnode.Node;
                    return;
                }

                s.Push(cnode);

                if (cnode.TimesPopped == 1)
                {
                    if (cnode.Node.getleft() != null)
                    {
                        s.Push(new StNode(cnode.Node.getleft()));
                    }
                }
                else
                {
                    if (cnode.Node.getRight() != null)
                    {
                        s.Push(new StNode(cnode.Node.getRight()));
                    }
                }
            }

        }

        public override void first()
        {
            s.Clear();
            if (t.Root != null) {
                s.Push(new StNode(t.Root));
                advance();
            }
        }
    }
}
