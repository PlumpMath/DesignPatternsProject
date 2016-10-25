using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2
{
    class Whip : Decorator
    {
        public Whip(Beverage beverage)
          : base(beverage)
        {
            Description = beverage.Description += ", Whip";
        }

        public override double Cost()
        {
            return base.Cost() + .20;
        }
    }
}
