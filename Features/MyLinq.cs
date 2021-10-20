using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    public static  class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> t){
            int count = 0;
            foreach (var item in t)
            {
                count += 1;
            }
            return count;
        }
    }
}
