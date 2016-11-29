using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2
{
    class Espresso : Beverage
    {
        // Constructor
        public Espresso()
        {
            base.Description = "Esspresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }
}
