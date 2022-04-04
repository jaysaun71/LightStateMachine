namespace Core.Lightfsm.Classes.DIContainer
{
    // TODO: i've been doing the class shielding by interface. it could be good to have exposed and internal methods at some scope
    internal interface ITypeResolver
    {
        TInterface ResolveType<TInterface>();
        object ResolveType();
    }
}