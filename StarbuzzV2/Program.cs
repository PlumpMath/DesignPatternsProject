using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarbuzzV2.AbstracFactory;
using StarbuzzV2.Factory;
using Singleton;
using StarbuzzV2.Observer;
using StarbuzzV2.Strategy;
using StarbuzzV2.Strategy.ConcreteStrategies;
using StarbuzzV2.Command;
using StarbuzzV2.Composite;

namespace StarbuzzV2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Decorator Pattern Example
            // Create book
            Esspresso beverage1 = new Esspresso();
            // Make video borrowable, then borrow and display
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

            Console.ReadKey();
        }
    }
}
