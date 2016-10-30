using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.BST
{
    public class BinaryTree<T>
    {
        private BinaryNode<T> _root;

        public BinaryNode<T> Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
            }
        }

        public BinaryTree() { 
        }

        public BinaryTree(T rootItem) {
            Root = new BinaryNode<T>(rootItem);
        }

        public int size() {
            return BinaryNode<T>.size(Root);
        }

        public int height() {
            return BinaryNode<T>.height(Root);
        }

        public void printPreOrder() {
            if (Root != null) {
                Root.printPreOrder();
            }
        }

        public void printPostOrder()
        {
            if (Root != null)
            {
                Root.printPostOrder();
            }
        }

        public void printInOrder()
        {
            if (Root != null)
            {
                Root.printInOrder();
            }
        }

        public void makeEmpty() {
            Root = null;
        }

        public bool isEmpty() {
            return Root == null;
        }

        public void merge(T root,BinaryTree<T> treeA, BinaryTree<T> treeB) {
            if (treeA.Root == treeB.Root && treeA.Root != null) {
                throw new ArgumentException();
            }
            Root = new BinaryNode<T>(root, treeA.Root, treeB.Root);
            if (this != treeA) treeA.Root = null;
            if (this != treeB) treeB.Root = null;
        }
    }
}
