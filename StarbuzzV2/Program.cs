﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarbuzzV2.AbstracFactory;
using StarbuzzV2.Factory;
using Singleton;
using StarbuzzV2.AD;
using StarbuzzV2.Observer;
using StarbuzzV2.Strategy;
using StarbuzzV2.Strategy.ConcreteStrategies;
using StarbuzzV2.Command;
using StarbuzzV2.Composite;
using StarbuzzV2.AD.Week1;
using StarbuzzV2.AD.Graph;
using StarbuzzV2.AD.BST;
using StarbuzzV2.AD.MaxHeap;
using StarbuzzV2.AD.MinHeap;
using StarbuzzV2.COR;

namespace StarbuzzV2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Design Patterns
            #region Decorator Pattern Example
            Espresso beverage1 = new Espresso();
            Console.WriteLine("Double Mocha Esspresso");
            Mocha d1 = new Mocha(beverage1);
            Mocha d2 = new Mocha(d1);
            Console.WriteLine(d2.Cost() + " " + d2.Description);

            Console.WriteLine("\n House Blend, Moch, Whip");
            HouseBlend beverage2 = new HouseBlend();
            Mocha d3 = new Mocha(beverage2);
            Whip d4 = new Whip(d3);
            Console.WriteLine(d4.Cost() + " " + d4.Description);
            #endregion

            #region Factory Pattern
            // Note: constructors call Factory Method
            Document[] documents = new Document[2];

            documents[0] = new Resume();
            documents[1] = new Report();

            // Display document pages
            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
            #endregion

            #region Abstract Factory Pattern
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();
            #endregion

            #region Singleton
            Console.WriteLine(Singleton.Math.Instance.add(34, 3));
            #endregion

            #region Obsever Pattern
            BaggageHandler provider = new BaggageHandler();
            ArrivalsMonitor observer1 = new ArrivalsMonitor("BaggageClaimMonitor1");
            ArrivalsMonitor observer2 = new ArrivalsMonitor("SecurityExit");

            provider.BaggageStatus(712, "Detroit", 3);
            observer1.Subscribe(provider);
            provider.BaggageStatus(712, "Kalamazoo", 3);
            provider.BaggageStatus(400, "New York-Kennedy", 1);
            provider.BaggageStatus(712, "Detroit", 3);
            observer2.Subscribe(provider);
            provider.BaggageStatus(511, "San Francisco", 2);
            provider.BaggageStatus(712);
            observer2.Unsubscribe();
            provider.BaggageStatus(400);
            provider.LastBaggageClaimed();
            #endregion

            #region Strategy Pattern
            SortedList studentRecords = new SortedList();
            studentRecords.Add("samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();
            #endregion

            #region Composite Pattern
            CompositeElement root = new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Circle"));
            root.Add(new PrimitiveElement("Green Box"));

            CompositeElement comp = new CompositeElement("Two Circles");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            PrimitiveElement pe = new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            root.Display(1);
            #endregion

            #region Command Pattern
            User user = new User();

            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            user.Undo(4);
            user.Redo(3);
            #endregion

            #region COR (Chain of Responsibility)
            // Setup Chain of Responsibility
            Handler h1 = new ConcreteHandlerA();
            Handler h2 = new ConcreteHandlerB();
            Handler h3 = new ConcreteHandlerC();
            h2.SetSuccessor(h3);
            h1.SetSuccessor(h2);
            

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }
            #endregion

            #endregion

            #region AD

            #region List
            MyArrayList list = new MyArrayList(5);
            //setting values
            list.add(1);
            list.add(2);
            list.add(3);
            list.add(4);
            list.add(5);

            Console.WriteLine(list.get(2) + " staat op positie 2");
            //testing print function
            list.print();
            //testing set function
            list.set(2, 10);//true
            list.print();
            list.set(10, 2);//false
            //occurences test
            list.set(0, 2);
            list.set(4, 2);
            list.countOccurences(2);
            //testing clear
            list.clear();
            list.print();

            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.addFirst(1);
            linkedList.addFirst(12);
            linkedList.addFirst(3);
            linkedList.addFirst(4);
            linkedList.addFirst(5);
            linkedList.insert(0,123);
            linkedList.remove(12);
            MyLinkedList<int>.printList(linkedList);
            Console.ReadLine();
            #endregion

            #region Graph
            Graph g = new Graph();

            try
            {

                StreamReader d = new StreamReader(Console.ReadLine());
                string line;
                while ((line = d.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] words = line.Split(' ');
                    try
                    {
                        if (words.Length > 3)
                        {
                            Console.WriteLine("Skipping bad line: " + line);
                            continue;
                        }
                        string source = words[0];
                        string dest = words[1];
                        int cost = Int32.Parse(words[2]);

                        g.addEdge(source, dest, cost);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Skipping bad line: " + line);
                        Console.WriteLine(e);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e); }


            //while (processRequest(g));
            #endregion

            #region Binairy tree
            string seperator = "-----------------------------------------------------------------------";
            Console.WriteLine(seperator);
            Console.WriteLine("Binary Tree Basic: ");
            BinaryNode<int> NodeA = new BinaryNode<int>(2);
            BinaryNode<int> NodeB = new BinaryNode<int>(5);
            BinaryNode<int> NodeC = new BinaryNode<int>(6);
            BinaryNode<int> NodeD = new BinaryNode<int>(3);
            BinaryNode<int> NodeE = new BinaryNode<int>(7);
            BinaryNode<int> NodeF = new BinaryNode<int>(10);
            BinaryNode<int> NodeG = new BinaryNode<int>(1);

            NodeE.setRight(NodeG);

            NodeA.setLeft(NodeC);
            NodeA.setRight(NodeD);

            NodeB.setLeft(NodeE);
            NodeB.setRight(NodeF);


            BinaryTree<int> tree = new BinaryTree<int>(12);
            tree.Root.setLeft(NodeA);
            tree.Root.setRight(NodeB);

            tree.printPreOrder();
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Binary Search Tree: ");
            BinaryTree<int> BST = new BinaryTree<int>();
            BST.Insert(5);
            BST.Insert(1254);
            BST.Insert(252);
            BST.Insert(378);
            BST.Insert(45);

            BST.Insert(668);
            BST.Insert(71);
            BST.Insert(8);
            BST.Insert(942);
            //fail test
            BST.Insert(1);

            Console.WriteLine(seperator);
            Console.WriteLine("Printing in order: ");
            BST.printInOrder();
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Finding Min:");
            Console.WriteLine(BST.FindMin());
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Finding Max: ");
            Console.WriteLine(BST.FindMax());
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Finding value 5:");
            Console.WriteLine(BST.Find(5));
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Removing 5");
            BST.Remove(5);
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Printing in order: ");
            BST.printInOrder();
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Removing Min");
            BST.RemoveMin();
            Console.ReadLine();

            Console.WriteLine(seperator);
            Console.WriteLine("Printing in order: ");
            BST.printInOrder();
            Console.ReadLine();
            #endregion

            #region Max heap
            MaxHeap theHeap = new MaxHeap(21);
            theHeap.Insert(40);
            theHeap.Insert(70);
            theHeap.Insert(20);
            theHeap.Insert(60);
            theHeap.Insert(50);
            theHeap.Insert(100);
            theHeap.Insert(82);
            theHeap.Insert(35);
            theHeap.Insert(90);
            theHeap.Insert(10);
            theHeap.DisplayHeap();

            Console.WriteLine("Inserting a new node with value 120");
            theHeap.Insert(120);
            theHeap.DisplayHeap();

            Console.WriteLine("Removing max element");
            theHeap.Remove();
            theHeap.DisplayHeap();

            Console.WriteLine("Changing root to 130");
            theHeap.HeapIncreaseDecreaseKey(0, 130);
            theHeap.DisplayHeap();

            Console.WriteLine("Changing root to 5");
            theHeap.HeapIncreaseDecreaseKey(0, 5);
            theHeap.DisplayHeap();
            Console.ReadLine();
            #endregion

            #region Min heap
            int[] arrA = { 50, 2, 30, 7, 40, 4, 10, 16, 12 };
            Console.WriteLine("Original Array : ");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.Write("  " + arrA[i]);
            }
            MinHeap m = new MinHeap(arrA.Length);
            Console.WriteLine("\nMin-Heap : ");
            m.createHeap(arrA);
            m.display();
            Console.WriteLine("Extract Min :");
            for (int i = 0; i < arrA.Length; i++)
            {
                Console.Write("  " + m.extractMin());
            }
            #endregion

            #region Sorting
            Console.WriteLine();
            int[] tmpArray = { 0, 15, 48, 60, 88, 123, 1, 5, 4, 12, 99, 11, 200, 41 };
            Console.WriteLine(seperator);
            Console.WriteLine("Base Array: ");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SortingAlgorithms.ShellSort(tmpArray);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Shell sorted Array in: "+elapsedMs+"ms");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);
            Console.ReadKey();

            tmpArray = new[] { 0, 15, 48, 60, 88, 123, 1, 5, 4, 12, 99, 11, 200, 41 };
            Console.WriteLine("Base Array: ");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);

            watch = System.Diagnostics.Stopwatch.StartNew();
            SortingAlgorithms.PerformInsertionSort(tmpArray);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Insertion sorted Array in: " + elapsedMs + "ms");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);
            Console.ReadKey();

            tmpArray = new[] { 0, 15, 48, 60, 88, 123, 1, 5, 4, 12, 99, 11, 200, 41};
            Console.WriteLine("Base Array: ");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);

            watch = System.Diagnostics.Stopwatch.StartNew();
            SortingAlgorithms.MergeSort(tmpArray);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Merge sorted Array in: " + elapsedMs + "ms");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);
            Console.ReadKey();

            tmpArray = new[] { 0, 15, 48, 60, 88, 123, 1, 5, 4, 12, 99, 11, 200, 41,46 };
            Console.WriteLine("Base Array: ");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);

            watch = System.Diagnostics.Stopwatch.StartNew();
            SortingAlgorithms.QuickSort(tmpArray,0,tmpArray.Length-1);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Quick sorted Array in: " + elapsedMs + "ms");
            SortingAlgorithms.Show_array_elements(tmpArray);
            Console.WriteLine(seperator);
            Console.ReadKey();
            #endregion
            #endregion
            Console.ReadKey();
        }
        #region processRequest
        public static Boolean processRequest(Graph g)
        {
            try
            {
                Console.WriteLine("Enter start node: ");
                String startname = Console.ReadLine();

                Console.WriteLine("Enter destination node: ");
                String destName = Console.ReadLine();

                Console.WriteLine("Enter algorithm (u,d,n,a): ");
                String alg = Console.ReadLine();
                switch (alg)
                {
                    case "u":
                        g.unweighted(startname);
                        Console.WriteLine("Unweighted started");
                        break;
                    case "d":
                        g.dijkstra(startname);
                        Console.WriteLine("dijkstra started");
                        break;
                    case "n":
                        g.negative(startname);
                        Console.WriteLine("negative started");
                        break;
                    case "a":
                        g.acyclic(startname);
                        Console.WriteLine("acyclic started");
                        break;
                }

                g.printPath(destName);
            }
            catch (ArgumentException e)
            {
                return false;
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            return true;
        }

        #endregion
    }
}
