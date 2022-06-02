using DemoMicrosoft.Models.Dependencies;
using DemoMicrosoft.Models.Repositories;
using System.Data.Common;

namespace DemoMicrosoft.Models.Services
{
    internal class FakeServiceWithDependency : ISimpleRepository<string>
    {
        private readonly IDependency<string> _dependency;

        public FakeServiceWithDependency(IDependency<string> dependency)
        {
            _dependency = dependency;
        }

        public void Print(string value)
        {
            _dependency.DoSomething(value);
        }
    }
}



