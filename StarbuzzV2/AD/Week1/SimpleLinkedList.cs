using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    interface SimpleLinkedList<T>
    {
        void addFirst(T data); // voeg een item toe aan het begin van de lijst
        void clear();
        void print();
        void insert(int index, T data); // voeg een item in op een bepaalde index (niet overschrijven!)
        void removeFirst(); // verwijder het eerste item
        T getFirst(); // geeft het eerste item terug
    }

}
