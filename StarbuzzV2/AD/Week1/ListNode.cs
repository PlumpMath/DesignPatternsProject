using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    class ListNode<T>
    {
        T element;
        ListNode<T> next;

        public ListNode(T element) {
            Element = element;
        }

        public T Element
        {
            get
            {
                return element;
            }

            set
            {
                element = value;
            }
        }

        internal ListNode<T> Next
        {
            get
            {
                return next;
            }

            set
            {
                next = value;
            }
        }
    }
}
