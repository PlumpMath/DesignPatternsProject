using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2
{
    /// <summary>
    /// The 'ConcreteDecorator' class
    /// </summary>
    class Mocha : Decorator
    {
        // Constructor
        public Mocha(Beverage beverage)
          : base(beverage)
        {
            Description = beverage.Description += ", Mocha";
        }

        public override double Cost()
        {
            return base.Cost() + .20;
        }
    }
}
