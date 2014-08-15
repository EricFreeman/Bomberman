using System;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var e in enumerable)
            {
                action(e);
            }
        }
    }
}
