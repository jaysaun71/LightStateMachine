The Dependency Resolver is simple implementation to fullfill the needs of
resolving the constructors dependencies through DI Container.


The development of the Dependency Resolver is done in agile manner with MVP start off. 


The MVP should contain:
Basic methods for registering interfaces and linking implementation to it.
Provide the option to choose between transient and singleton lifetime.
The object should be instantiated when its being resolved for the first time.


There are two common behaviours to resolve the type. 
The Consumer delegating the function that returns interface.
The Implementation that links types to its interface and put on Dependency Resolver
responisibility to instantiate type.

REMARKS:
The first approach pushes on consumer the responsibility of the type initialization.
The second approach put responisibility on Dependency Resolver to create needed objects 
and its dependencies. 

That approach requires traverse through the types container and the 
runtime excpetions may occur when the dependency is not registered. 

Idea: Implementation that checks if needed dependencies exist 
could be done at the Dependency Resolver initialization level. 

Idea: The behavioural strategy pattern is taken as possible desing solution for that. 
There is need to modify strategy pattern as the algorithm method have same signature across 
stategies implementations.

Resource: https://github.com/Sebastian-Nielsen/Strategy-Pattern-with-different-parameters/blob/master/paperThatPresentsTheSolution.pdf
Comment: That resource is providing solution for static parameters 
that can be resolved at object instatiation level.

DIContiner let us to use user defined dynamic and built-in resolver methods

Registering methods:
RegisterType<TInterface>(Func<TInterface> typeCreator)
RegisterType<TInterface, TImpl>() where TImpl : TInterface
Non generic registration method would imply some additional checks (TImpl : TInterface) and casting, mappings.
Future: implement RegisterType<TInterface>(Func<TInterface,T1,T2...> typeCreator)

Resolving methods:
T ResolveType<T>();
The resolve method is generic to get known type T as return. At class DependencyResolver level there is multiple T as its container of T-is 
with operational behaviour attached.
Actual Implementation of ResolveType is hidden by abstraction layer as Resolving can have different strategies. 
the expected return type(T) is explicitly known.

IDEA: For writing robust rich application the wrapping all business objects with some metadata(ie. exception) is worth considering

REMARKS:
Generic method is generic within the method scope.
Generic class is generic within the cope of class.
That should be consider when designing generic at application level. It stays that some additional work will be needed to combine generics
into bigger domain.

