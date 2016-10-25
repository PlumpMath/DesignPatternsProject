using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2
{
    abstract class Beverage
    {
        private string _description = "unknow beverage";

        // Property
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public abstract double Cost();
    }
}
