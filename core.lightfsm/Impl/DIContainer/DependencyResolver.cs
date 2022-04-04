namespace Core.Lightfsm.Classes.DIContainer
{

    /// DIContiner let us to use user defined dynamic and built-in resolver methods
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;
    using System.Dynamic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Class provide functionality to register and resolving the type with its dependencies.
    /// </summary>
    public class DependencyResolver : IDependencyResolver
    {
        // Create demo app that shows view tree and allows to go through viewtree
        // ViewModel must be capable of resolve any dependencies dynamically
        private readonly IDictionary<Type, ITypeResolver> container = new Dictionary<Type, ITypeResolver>();

        /// <summary>
        /// Registering the implementation of interface through function.
        /// </summary>
        /// <typeparam name="TInterface">registered interface.</typeparam>
        /// <param name="typeCreator">func that returns with interface implementation.</param>
        /// <remarks>
        /// Implementation is resolved at the moment of resolving the object. lifetime: transient.
        /// </remarks>
        public void RegisterType<TInterface>(Func<TInterface> typeCreator)
        {
            this.container.Add(typeof(TInterface), FuncTypeResolver<TInterface>.CreateFuncTypeResolver(typeCreator));
        }

        /// <summary>
        /// Registering type that implements interface.
        /// </summary>
        /// <typeparam name="TInterface">Registered interface.</typeparam>
        /// <typeparam name="TImpl">Implementation to be returned when <see cref="ResolveType{TInterface}"/> called.</typeparam>
        public void RegisterType<TInterface, TImpl>()
            where TImpl : TInterface
        {
            this.container.Add(typeof(TInterface), DynamicTypeResolver<TInterface, TImpl>.CreateDynamicTypeResolver(this.container));
        }

        /// <summary>
        /// Resolved object by registered <see cref="TInterface"/>.
        /// </summary>
        /// <typeparam name="TInterface">Interface to resolve object for.</typeparam>
        /// <returns>Objects that implements of <see cref="TInterface"/>.</returns>
        public TInterface ResolveType<TInterface>()
        {
            ITypeResolver result;
            bool hasValue = this.container.TryGetValue(typeof(TInterface), out result);
            if (hasValue)
            {
                return result.ResolveType<TInterface>();
            }

            // TODO: that's null casted to type later on implement exception handling
            return (TInterface)new object();
        }

        // /// <summary>
        // /// Method instantiate and return type implementing the <see cref="TInterface"/>.
        // /// </summary>
        // /// <typeparam name="TInterface">Interface to resolve</typeparam>
        // public TInterface CreateImplByInterface<TInterface>()
        // {
        //     return (TInterface)this.ResolveImplByInterfaceDynamic(typeof(TInterface));
        // }
        //
        // private object ResolveImplByInterfaceDynamic(Type interfaceType)
        // {
        //
        //     ITypeResolver type;
        //     var implType = this.container.TryGetValue(interfaceType, out type);
        //
        //     if (!implType) throw new Exception("The type is not registered.");
        //     // if (!type.IsClass && type.IsAbstract)
        //     // {
        //     //     throw new Exception("The Type trying to resolve is not a class or it is abstract");
        //     // }
        //
        //     //var constructorInfos = type.GetConstructors();
        //     //ParameterInfo[] parameters = constructorInfos[0].GetParameters();
        //
        //     //var resolvedParams = parameters.Select(x => this.ResolveImplByInterfaceDynamic(x.ParameterType));
        //
        //     return null; //Activator.CreateInstance(obnj);//, resolvedParams.ToArray());
        // }
    }
}