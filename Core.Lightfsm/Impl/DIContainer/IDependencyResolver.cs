namespace Core.Lightfsm.Classes.DIContainer
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