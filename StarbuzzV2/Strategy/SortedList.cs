using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.Strategy
{
    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortstrategy) {
            this._sortStrategy = sortstrategy;
        }

        public void Add(string name) {
            _list.Add(name);
        }

        public void Sort() {
            _sortStrategy.Sort(_list);

            foreach (string name in _list)
            {
                Console.WriteLine("" + name);
            }
            Console.WriteLine();
        }
    }
}
