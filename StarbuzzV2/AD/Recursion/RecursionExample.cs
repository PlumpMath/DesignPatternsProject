using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarbuzzV2.AD.Recursion
{
    class RecursionExample
    {
        public int TelLeesTekens(string s)
        {
            int count = 0;

            if (s.Count() > 1)
            {
                for (int i = 0; i < s.Count(); i++)
                {
                    string singleChar = s.Substring(i, 1);
                    count += TelLeesTekens(singleChar);
                }
            }
            else
            {
                char[] letter = s.ToCharArray();
                if (!char.IsDigit(letter[0]) && !char.IsLetter(letter[0]) && !char.IsWhiteSpace(letter[0]))
                {
                    count++;
                }

            }

            return count;
        }
    }
}
