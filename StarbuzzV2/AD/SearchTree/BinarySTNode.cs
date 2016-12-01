using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.SearchTree
{
    class BinarySTNode<T>
    {
        private T _element;
        private BinarySTNode<T> _left { get; set; }
        private BinarySTNode<T> _right { get; set; }

        BinarySTNode(T element)
        {
            _element = element;
            _left = _right = null;
        }
    }
}
