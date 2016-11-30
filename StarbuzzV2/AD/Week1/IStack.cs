using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Week1
{
    interface IStack<T>
    {
        void Push(T data);
        T Pop();
        T Top();
    }
}
