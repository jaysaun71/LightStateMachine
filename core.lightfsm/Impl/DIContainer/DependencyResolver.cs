namespace Core.Lightfsm.Classes.DIContainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public static class DependencyResolver
    {
        public static Dictionary<Type,object> Dependencies = new Dictionary<Type, object>();

        /// <summary>
        /// Map interface to the class.
        /// </summary>
        public static Dictionary<Type,Type> InterfaceImplMap = new Dictionary<Type, Type>();

        public static void RegisterType<T>(Func<T> typeCreator)
        {
            T x = typeCreator();
            Dependencies.Add(typeof(T), x);
        }

        public static void RegisterType<TInterface, TImpl>()
            where TImpl : TInterface
        {
            InterfaceImplMap.Add(typeof(TInterface), typeof(TImpl));
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

        /// <summary>
        /// Method instantiate and return type implementing the <see cref="TInterface"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface to resolve</typeparam>
        public static TInterface CreateImplByInterface<TInterface>()
        {
            if (!typeof(TInterface).IsInterface)
            {
                throw new Exception("trying to resolve non interface type.");
            }

            Type type;
            var implType = InterfaceImplMap.TryGetValue(typeof(TInterface),out type);

            if (!implType) throw new Exception("The type is not registered.");

            if (!type.IsClass && type.IsAbstract)
            {
                throw new Exception("The Type trying to resolve is not a class or it is abstract");
            }

            var constructorInfos = type.GetConstructors();
            ParameterInfo[] parameters = constructorInfos[0].GetParameters();

            var resolvedParams = parameters.Select(x => ResolveImplByInterfaceDynamic(x.ParameterType));

            return (TInterface)Activator.CreateInstance(type, resolvedParams.ToArray());
        }

        private static object ResolveImplByInterfaceDynamic(Type interfaceType)
        {

            Type type;
            var implType = InterfaceImplMap.TryGetValue(interfaceType, out type);

            if (!implType) throw new Exception("The type is not registered.");

            if (!type.IsClass && type.IsAbstract)
            {
                throw new Exception("The Type trying to resolve is not a class or it is abstract");
            }

            var constructorInfos = type.GetConstructors();
            ParameterInfo[] parameters = constructorInfos[0].GetParameters();

            var resolvedParams = parameters.Select(x => ResolveImplByInterfaceDynamic(x.ParameterType));

            return Activator.CreateInstance(type, resolvedParams.ToArray());
        }

        public static void GetTypeInfo(Type type)
        {
            ConstructorInfo[] ctors = type.GetConstructors();
            var parameterInfos = ctors[0].GetParameters();
        }
    }
}
