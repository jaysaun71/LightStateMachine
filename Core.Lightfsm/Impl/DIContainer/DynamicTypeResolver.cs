namespace Core.Lightfsm.Impl.DIContainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// if that class is resolver it means should contain the methods for resolving not wrapping the type to be resolved.
    /// i should consider separater type wrapper and resolver.
    /// exercise: write down how to resolve types. (at abstract generic level)
    public class DynamicTypeResolver<TInterface, TImpl> : ITypeResolver
    {
        private readonly IDictionary<Type, ITypeResolver> container; // should container contain the Description with injected resovler (behaviour)

        private DynamicTypeResolver(IDictionary<Type, ITypeResolver> container)
        {
            this.container = container;
        }

        public T ResolveType<T>()
        {
            if (!typeof(T).IsInterface)
            {
                throw new Exception("trying to resolve non interface type.");
            }

            if (typeof(T) != typeof(TInterface))
            {
                throw new Exception("trying to resolve non matching T type.");
            }

            return (T)this.ResolveType();
        }

        /// <summary>
        /// That function could be injected as one of strategies that is static.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public object ResolveType()
        {
            var implType = typeof(TImpl);

            if (!implType.IsClass && implType.IsAbstract)
            {
                throw new Exception("The Type that is not a class cannot be resolved ");
            }

            var constructorInfos = implType.GetConstructors();
            ParameterInfo[] parameters = constructorInfos[0].GetParameters(); // Interfaces

            var resolvedParams = parameters.Select(x =>
            {
                bool hasValue = this.container.TryGetValue(x.ParameterType, out var implTypeResolver);
                if (!hasValue) throw new Exception("The type is not registered.");

                return implTypeResolver.ResolveType();
            });

            return Activator.CreateInstance(typeof(TImpl), resolvedParams.ToArray());
        }

        // TODO: that depedency on passing by reference container smells.
        internal static DynamicTypeResolver<TInterface,TImpl> CreateDynamicTypeResolver(IDictionary<Type, ITypeResolver> container)
        {
            return new DynamicTypeResolver<TInterface, TImpl>(container);
        }
    }
}