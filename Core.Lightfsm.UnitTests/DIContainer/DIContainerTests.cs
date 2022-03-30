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
            DependencyResolver.RegisterType<ITestOneInterface, InjectedClass>();
            DependencyResolver.RegisterType<ITestTwoInterface, InjectedClass>();
            DependencyResolver.RegisterType<IDITestClass, DITestClass>();

            // Act
            DependencyResolver.CreateImplByInterface<IDITestClass>();

            // Assert
            Assert.Pass();
        }

        [Test]
        public void GivenRegisterClassByInterfaceWithTwoInterfacedParamsCtor_VerifyCanResolveThroughDIContainer()
        {
            // Arrange
            DependencyResolver.RegisterType<ITestOneInterface, InjectedClass>();
            DependencyResolver.RegisterType<ITestTwoInterface, InjectedClass>();
            DependencyResolver.RegisterType<IDITestClass, DITestClass>();

            // Act
            var x = DependencyResolver.CreateImplByInterface<IDITestClass>();
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