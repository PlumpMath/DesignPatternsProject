using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.BST
{
    public class BinaryNode<T>
    {
        private T _element;
        private BinaryNode<T> _left;
        private BinaryNode<T> _right;

        public BinaryNode() {
        }

        public BinaryNode(T element,BinaryNode<T> lt, BinaryNode<T> rt) {
            _element = element;
            _left = lt;
            _right = rt;
        }

        public BinaryNode(T element)
        {
            _element = element;
        }

        public T getElement() {
            return _element;
        }

        public BinaryNode<T> getleft() {
            return _left;
        }

        public BinaryNode<T> getRight()
        {
            return _right;
        }

        public void setElement(T x) {
            _element = x;
        }

        public void setLeft(BinaryNode<T> node) {
            _left = node;
        }

        public void setRight(BinaryNode<T> node) {
            _right = node;
        }

        public static int size(BinaryNode<T> t) {
            if (t == null)
            {
                return 0;
            }
            else {
                return 1 + size(t._left) + size(t._right);
            }
        }

        public static int height(BinaryNode<T> t) {
            if (t == null)
            {
                return -1;
            }
            else {
                return 1 + Math.Max(height(t._left),height(t._right));
            }
        }

        public BinaryNode<T> duplicate() {
            BinaryNode<T> root = new BinaryNode<T>(_element);

            if (_left != null) root._left = _left;
            if (_right != null) root._right = _right;

            return root;
        }

        public void printPreOrder() {

            Console.WriteLine(_element);

            if (_left != null) {
                _left.printPreOrder();
            }

            if (_right != null)
            {
                _right.printPreOrder();
            }
        }

        public void printInOrder() {

            if (_left != null)
            {
                _left.printInOrder();
            }

            Console.WriteLine(_element);

            if (_right != null)
            {
                _right.printInOrder();
            }
        }

        public void printPostOrder() {

            if (_left != null)
            {
                _left.printPostOrder();
            }

            if (_right != null)
            {
                _right.printPostOrder();
            }

            Console.WriteLine(_element);

        }
    }
}
