using System;
using System.Linq;
using System.Collections.Generic;

namespace PXELDAR
{
    public static class EnumerableExtensions
    {
        //===================================================================================

        public static IEnumerable<T> CreateFromNode<T>(T node, Func<T, T> nextNodeGetter)
                   where T : class
        {
            T temp = node;
            yield return temp;

            while (true)
            {
                temp = nextNodeGetter(temp);
                if (temp == null)
                {
                    yield break;
                }

                yield return temp;
            }
        }

        //===================================================================================

        public static IEnumerable<T> Linearize<T>(T node, Func<T, IEnumerable<T>> childrenGetter)
        {
            yield return node;

            foreach (var child in childrenGetter(node))
            {
                foreach (var x in Linearize<T>(child, childrenGetter))
                {
                    yield return x;
                }
            }
        }

        //===================================================================================

        public static void Foreach<T>(this IReadOnlyList<List<T>> lists, Action<int, int, T> action)
        {
            for (int x = 0; x < lists.Count; x++)
            {
                for (int y = 0; y < lists[x].Count; y++)
                {
                    action(x, y, lists[x][y]);
                }
            }
        }

        //===================================================================================

        public static bool TryGetFirstElement<T>(this IList<T> list, out T element)
        {
            element = default(T);
            if (!list.IsNullOrEmpty())
            {
                element = list[0];
                return true;
            }
            return false;
        }

        //===================================================================================

        public static T SafeGetFirstOrDefault<T>(this IList<T> list, Func<T, bool> predicate)
        {
            if (!list.IsNullOrEmpty())
            {
                return list.FirstOrDefault(predicate);
            }
            return default(T);
        }

        //===================================================================================

        public static T[] ToArrayOrSelf<T>(this IEnumerable<T> enumerable)
        {
            var asArray = enumerable as T[];
            return asArray ?? enumerable.ToArray();
        }

        //===================================================================================

        public static List<T> ToListOrSelf<T>(this IEnumerable<T> enumerable)
        {
            var asList = enumerable as List<T>;
            return asList ?? enumerable.ToList();
        }

        //===================================================================================

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }

        //===================================================================================
    }
}