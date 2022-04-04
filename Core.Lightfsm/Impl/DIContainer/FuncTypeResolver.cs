namespace Core.Lightfsm.Impl.DIContainer
{
    using System;

    internal class FuncTypeResolver<TInterface> : ITypeResolver
    {
        private Func<TInterface> resolverFunc;

        private FuncTypeResolver(Func<TInterface> resolverFunc)
        {
            this.resolverFunc = resolverFunc;
        }

        public T ResolveType<T>()
        {
            T result = (T)Convert.ChangeType(this.ResolveType(), typeof(T));
            return result;
        }

        public object ResolveType()
        {
            return this.resolverFunc.Invoke();
        }

        internal static FuncTypeResolver<TInterface> CreateFuncTypeResolver(Func<TInterface> func)
        {
            return new FuncTypeResolver<TInterface>(func);
        }
    }
}