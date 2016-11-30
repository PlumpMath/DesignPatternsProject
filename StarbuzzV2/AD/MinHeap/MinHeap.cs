using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.MinHeap
{
    class MinHeap
    {
        public int size;
        public int[] mH;
        public int position;
        public MinHeap(int size)
        {
            this.size = size;
            mH = new int[size + 1];
            position = 0;
        }
        public void createHeap(int[] arrA)
        {
            if (arrA.Length > 0)
            {
                for (int i = 0; i < arrA.Length; i++)
                {
                    insert(arrA[i]);
                }
            }
        }
        public void display()
        {
            Console.WriteLine();
            Console.Write("Elements of the Heap Array are : ");
            for (int m = 0; m < size; m++)
                if (mH.Length != 0)
                    Console.Write(mH[m] + " ");
                else
                    Console.Write("-- ");
            Console.WriteLine();
            int emptyLeaf = 32;
            int itemsPerRow = 1;
            int column = 0;
            int j = 0;
            String separator = "...............................";
            Console.WriteLine(separator + separator);
            while (size > 0)
            {
                if (column == 0)
                    for (int k = 0; k < emptyLeaf; k++)
                        Console.Write(' ');
                Console.Write(mH[j]);

                if (++j == size)
                    break;
                if (++column == itemsPerRow)
                {
                    emptyLeaf /= 2;
                    itemsPerRow *= 2;
                    column = 0;
                    Console.WriteLine();
                }
                else
                    for (int k = 0; k < emptyLeaf * 2 - 2; k++)
                        Console.Write(' ');
            }
            Console.WriteLine("\n" + separator + separator);
        }
        public void insert(int x)
        {
            if (position == 0)
            {
                mH[position + 1] = x;
                position = 2;
            }
            else {
                mH[position++] = x;
                bubbleUp();
            }
        }
        public void bubbleUp()
        {
            int pos = position - 1;
            while (pos > 0 && mH[pos / 2] > mH[pos])
            {
                int y = mH[pos];
                mH[pos] = mH[pos / 2];
                mH[pos / 2] = y;
                pos = pos / 2;
            }
        }
        public int extractMin()
        {
            int min = mH[1];
            mH[1] = mH[position - 1];
            mH[position - 1] = 0;
            position--;
            sinkDown(1);
            return min;
        }

        public void sinkDown(int k)
        {
            int a = mH[k];
            int smallest = k;
            if (2 * k < position && mH[smallest] > mH[2 * k])
            {
                smallest = 2 * k;
            }
            if (2 * k + 1 < position && mH[smallest] > mH[2 * k + 1])
            {
                smallest = 2 * k + 1;
            }
            if (smallest != k)
            {
                swap(k, smallest);
                sinkDown(smallest);
            }

        }
        public void swap(int a, int b)
        {
            int temp = mH[a];
            mH[a] = mH[b];
            mH[b] = temp;
        }
    }
}
