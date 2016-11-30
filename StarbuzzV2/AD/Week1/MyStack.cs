using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    class MyStack<T> : IStack<T>
    {
        MyLinkedList<T> list = new MyLinkedList<T>();
        public void Push(T data)
        {
            list.addFirst(data);
        }

        public T Pop()
        {
            T data = list.getFirst();
            list.removeFirst();
            return data;
        }

        public T Top()
        {
            return list.getFirst();
        }
    }
}
