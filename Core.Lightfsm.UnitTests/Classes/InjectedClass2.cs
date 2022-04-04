namespace Core.Lightfsm.UnitTests.Classes
{
    internal class InjectedClass2 : ITestTwoInterface
    {
        private ITestOneInterface testOne { get; }
        public InjectedClass2(ITestOneInterface testOne)
        {
            this.testOne = testOne;
        }
    }
}