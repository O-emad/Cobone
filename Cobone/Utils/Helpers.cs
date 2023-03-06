using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cobone.Utils
{
    public static class Helpers
    {
        public static string StripHTML(string input)
        {
            //return Regex.Replace(input, "<.*?>", String.Empty);
            char[] charArray = new char[input.Length];
            int index = 0;
            bool isInside = false;

            for (int i = 0; i < input.Length; i++)
            {
                char left = input[i];

                if (left == '<')
                {
                    isInside = true;
                    continue;
                }

                if (left == '>')
                {
                    isInside = false;
                    continue;
                }

                if (!isInside)
                {
                    charArray[index] = left;
                    index++;
                }
            }

            var text =  new string(charArray, 0, index);
           
            return text;
        }
    }
}
