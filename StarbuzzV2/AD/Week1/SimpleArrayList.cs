using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    interface SimpleArrayList
    {
        void add(int n);
        int get(int index);
        void set(int index, int n);
        void print();
        void clear();
        int countOccurences(int n);
    }
}
