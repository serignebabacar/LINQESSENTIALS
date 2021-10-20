﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    public static class MyLinq
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> sources, Func<T, bool> predicate)
        {
            /* var result = new List<T>();
               result = sources.Where(predicate).ToList();*/
            foreach (var source in sources)
            {
                if (predicate(source))
                    yield return source;
            }
        }
        public static IEnumerable<double> Random()
        {
            var random = new Random();
            while (true)
            {
                yield return random.NextDouble();
            }
        }
    }
}
