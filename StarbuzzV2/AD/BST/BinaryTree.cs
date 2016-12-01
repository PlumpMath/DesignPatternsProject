using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.BST
{
    public class BinaryTree<T> where T : IComparable
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

        public BinaryTree()
        {
            Root = null;
        }

        #region basic tree features
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
        #endregion

        #region Search Tree functions

        public void Insert(T x)
        {
            Root = Insert(x, Root);
        }

        public void Remove(T x)
        {
            Root = Remove(x, Root);
        }

        public void RemoveMin()
        {
            Root = RemoveMin(Root);
        }

        public T FindMin()
        {
            return elementAt(FindMin(Root));
        }

        public T FindMax()
        {
            return elementAt(FindMax(Root));
        }

        public T Find(T x)
        {
            return elementAt(Find(x,Root));
        }

        private BinaryNode<T> Find(T x, BinaryNode<T> root)
        {
            while (root != null)
            {
                if (x.CompareTo(root.getElement()) < 0)
                {
                    root = root.getleft();
                }else if (x.CompareTo(root.getElement()) > 0)
                {
                    root = root.getRight();
                }
                else
                {
                    return root;
                }
            }
            return null;
        }

        private BinaryNode<T> FindMax(BinaryNode<T> root)
        {
            if (root != null)
            {
                while (root.getRight() != null)
                {
                    root = root.getRight();
                }
            }
            return root;
        }

        private T elementAt(BinaryNode<T> t)
        {
            if (t != null)
            {
                return t.getElement();
            }
            return default(T);
        }
        private BinaryNode<T> RemoveMin(BinaryNode<T> root)
        {
            if (root == null)
            {
                throw new NoNullAllowedException("Item does not exist");
            }
            else if (root.getleft() != null)
            {
                root.setLeft(RemoveMin(root.getleft()));
                return root;
            }
            else
            {
                return root.getRight();
            }

        }
       private BinaryNode<T> FindMin(BinaryNode<T> root)
        {
            if (root != null)
            {
                while (root.getleft() != null)
                {
                    root = root.getleft();
                }
            }
            return root;
        }

        private BinaryNode<T> Insert(T x, BinaryNode<T> root)
        {

            if (root == null)
            {
                Console.WriteLine("Root is null");
                root = new BinaryNode<T>(x);
            }else if (x.CompareTo(root.getElement()) < 0)
            {
                Console.WriteLine("Set Left");
                root.setLeft(Insert(x,root.getleft()));
            }
            else if (x.CompareTo(root.getElement()) > 0)
            {
                Console.WriteLine("Set Right");
                root.setRight(Insert(x, root.getRight()));
            }
            else
            {
                Console.WriteLine("Comparing test:");
                Console.WriteLine(x.CompareTo(root.getElement()));
                //throw new DuplicateNameException("The following element is allready in the tree:"+x.ToString());
            }
            return root;
        }

        private BinaryNode<T> Remove(T x, BinaryNode<T> root)
        {
            if (root == null)
            {
                throw new NoNullAllowedException("Item does not exist");
            }
            if (x.CompareTo(root.getElement()) < 0)
            {
                root.setLeft(Remove(x,root.getleft()));
            }else if (x.CompareTo(root.getElement()) < 0)
            {
                root.setRight(Remove(x, root.getRight()));
            }else if (root.getleft() != null && root.getRight() != null)
            {
                root.setElement(FindMin(root.getRight()).getElement());
                root.setRight(RemoveMin(root.getRight()));
            }
            else
            {
                root = (root.getleft() != null) ? root.getleft() : root.getRight();
            }
            return root;
        }
        #endregion

    }
}
