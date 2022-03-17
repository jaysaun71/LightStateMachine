namespace Lightfsm.Wpfexmpl
{
    using System;
    using System.Collections.Generic;

    internal static class DependencyResolver
    {
        public static Dictionary<Type,object> Dependencies = new Dictionary<Type,object>();

        public static void RegisterType<T>(Func<T> typeCreator)
        {
            T x = typeCreator();
            Dependencies.Add(typeof(T), x);
        }

        public static T ResolveType<T>()
        {
            object result;
            bool x = Dependencies.TryGetValue(typeof(T), out result);
            if (x)
            {
                return (T)result;
            }

            // that's null casted to type later on implement exception handling
            return (T)result;
        }
    }
}
