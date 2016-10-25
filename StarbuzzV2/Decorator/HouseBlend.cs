using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2
{
    class HouseBlend : Beverage
    {

        // Constructor
        public HouseBlend()
        {
            base.Description = "House Blend";
        }

        public override double Cost()
        {
            return .89;
        }
    }
}
