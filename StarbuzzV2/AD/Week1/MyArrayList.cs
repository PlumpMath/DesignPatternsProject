using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    class MyArrayList : SimpleArrayList
    {
        private int[] _list;
        private int _size;
        private int _current = 0;

        public MyArrayList(int size) {
            _list = new int[size];
            _size = size;
        }

        public void add(int n)
        {
            _list[_current] = n;
            _current++;
        }

        public void clear()
        {
            _list = new int[_size];
        }

        public int get(int index)
        {
            if (index < _size)
            {
                return _list[index];
            }
            else {
                return -1;
                Console.WriteLine("Index out of range");
            }
        }

        public void print()
        {
            for (int i = 0; i < _size; i++) {
                Console.WriteLine("Number {0}: {1}", i, _list[i]);
            }
        }

        public void set(int index, int n)
        {
            if (index < _size)
            {
                _list[index] = n;
            }
            else {
                Console.WriteLine("Index out of range");
            }
        }

        public int countOccurences(int n)
        {
            int occurences = 0;

            for (int i = 0; i < _list.Length; i++) {
                if (n == _list[i]) {
                    occurences++;
                }
            }

            return occurences;
        }
    }
}
