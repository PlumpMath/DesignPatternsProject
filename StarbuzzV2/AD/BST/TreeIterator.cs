using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.BST
{
    abstract class TreeIterator<T>
    {
        protected BinaryTree<T> t;
        protected BinaryNode<T> current;

        public TreeIterator(BinaryTree<T> theTree){
            t = theTree;
            current = null;
            }

        public bool isValid() {
            return current != null;
        }

        public T retrieve() {
            if (current == null) {
                throw new Exception("Element not found!");
            }
            return current.getElement();
        }

        abstract public void first();
        abstract public void advance();
    }
}
