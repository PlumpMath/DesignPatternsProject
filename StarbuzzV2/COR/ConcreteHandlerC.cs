using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.COR
{
    class ConcreteHandlerC : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",
                  this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
}
