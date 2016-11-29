using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    class LinkedListIterator<T>
    {
        private ListNode<T> current;

        internal ListNode<T> Current
        {
            get
            {
                return current;
            }

            set
            {
                current = value;
            }
        }

        public LinkedListIterator(ListNode<T> theNode) {
            Current = theNode;
        }

        public bool isValid() {
            return Current != null;
        }

        public T retrieve() {
            if (isValid())
            {
                return Current.Element;
            }
            else {
                return default(T);
            }
        }

        public void advance() {
            if (isValid()) {
                Current = Current.Next;
            }
        }
    }
}
