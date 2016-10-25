using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2
{
    class Esspresso : Beverage
    {
        // Constructor
        public Esspresso()
        {
            base.Description = "Esspresso";
        }

        public override double Cost()
        {
            return 1.99;
        }
    }
}
