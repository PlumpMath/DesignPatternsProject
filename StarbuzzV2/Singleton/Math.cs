using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class Math
    {
        private static volatile Math instance;
        private static object syncRoot = new Object();

        private Math() { }

        public static Math Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Math();
                    }
                }

                return instance;
            }
        }

        public double devide(double a, double b) {
            return (a / b);
        }
        public double multiply(double a, double b) {
            return (a * b);
        }
        public double min(double a, double b) {
            return (a - b);
        }
        public double add(double a, double b) {
            return (a + b);
        }
    }
}
