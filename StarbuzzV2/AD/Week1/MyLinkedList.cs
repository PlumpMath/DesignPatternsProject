using StarbuzzV2.AD.Week1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    class MyLinkedList<T> : SimpleLinkedList<T>
    {
        private ListNode<T> header;
        public MyLinkedList() {
            header = new ListNode<T>(default(T));
        }

        public bool isEmpty() {
            return header.Next == null;
        }

        public void makeEmpty() {
            header.Next = null;
        }
        public void addFirst(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);
            newNode.Next = header.Next;
            header.Next = newNode;
        }

        public LinkedListIterator<T> zeroth() {
            return new LinkedListIterator<T>(header);
        }

        public LinkedListIterator<T> first() {
            return new LinkedListIterator<T>(header.Next);
        }

        public void clear()
        {
            header.Next = null;
        }

        public T getFirst()
        {
            return header.Next.Element;
        }

        public void insert(int index, T data)
        {
            ListNode<T> node = header;
            ListNode<T> newNode = new ListNode<T>(data);
            int i = 0;
            while (node?.Next != null)
            {
                if (i == index)
                {
                    newNode.Next = node.Next;
                    node.Next = newNode;
                }
                node = node.Next;
                i++;
            }
        }

        public void print()
        {
            throw new NotImplementedException();
        }

        public void removeFirst()
        {
            header.Next = header.Next.Next;
        }

        public LinkedListIterator<T> find(T x) {
            ListNode<T> itr = header.Next;

            while (itr != null && !itr.Element.Equals(x)) {
                itr = itr.Next;
            }

            return new LinkedListIterator<T>(itr);
        }

        public LinkedListIterator<T> findPrevious(T x) {
            ListNode<T> itr = header;
            while (itr != null && !itr.Next.Element.Equals(x))
            {
                itr = itr.Next;
            }

            return new LinkedListIterator<T>(itr);
        }

        public static void printList( MyLinkedList<T> theList) {

            if (theList.isEmpty())
            {
                Console.WriteLine("Empty List");
            }
            else {
                LinkedListIterator<T> itr = theList.first();
                while (itr.isValid()) {
                    Console.Write(itr.retrieve() + " ");
                    itr.advance();
                }
            }
        }

        public void remove(T x) {
            LinkedListIterator<T> p = findPrevious(x);
            if (p.Current.Next != null) {
                p.Current.Next = p.Current.Next.Next;
            }
        }
    }
}
