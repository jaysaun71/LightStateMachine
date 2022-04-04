namespace Core.Lightfsm.Impl.DIContainer
{
    using System;

    public interface IDependencyResolver
    {
        void RegisterType<T>(Func<T> typeCreator);

        void RegisterType<TInterface, TImpl>()
            where TImpl : TInterface;

        T ResolveType<T>();
    }
}