using NUnit.Framework;

namespace Core.Lightfsm.UnitTests
{
    using Classes;
    using Lightfsm.Classes.DIContainer;

    public class DIContainerTests
    {
        [Test]
        public void GivenRegisteredClassByInterface_VerifyCanResolveThroughDIContainer()
        {
            // Arrange
            var dependencyResolver = new DependencyResolver();
            dependencyResolver.RegisterType<ITestOneInterface, InjectedClass>();
            dependencyResolver.RegisterType<ITestTwoInterface, InjectedClass>();
            dependencyResolver.RegisterType<IDITestClass, DITestClass>();

            // Act
            dependencyResolver.ResolveType<IDITestClass>();

            // Assert
            Assert.Pass();
        }

        [Test]
        public void GivenRegisterClassByInterfaceWithTwoInterfacedParamsCtor_VerifyCanResolveThroughDIContainer()
        {
            // Arrange
            var dependencyResolver = new DependencyResolver();
            dependencyResolver.RegisterType<ITestOneInterface, InjectedClass>();
            dependencyResolver.RegisterType<ITestTwoInterface, InjectedClass>();
            dependencyResolver.RegisterType<IDITestClass, DITestClass>();

            // Act
            IDITestClass diTestClassImpl = dependencyResolver.ResolveType<IDITestClass>();
            DITestClass diTestClass = (DITestClass)diTestClassImpl;

            // Assert
            Assert.Pass();
        }

        [Test]
        public void GivenRegisterClassByInterfaceWithTwoInterfacedParamsCtor2_VerifyCanResolveThroughDIContainer()
        {
            // Arrange
            var dependencyResolver = new DependencyResolver();
            dependencyResolver.RegisterType<ITestOneInterface, InjectedClass>();
            dependencyResolver.RegisterType<ITestTwoInterface, InjectedClass2>();
            
            dependencyResolver.RegisterType<IDITestClass, DITestClass>();

            // Act
            var x = dependencyResolver.ResolveType<IDITestClass>();
            DITestClass diTestClass = (DITestClass)x;

            // Assert
            Assert.Pass();
        }



        [SetUp]
        public void Setup()
        {

        }
    }
}