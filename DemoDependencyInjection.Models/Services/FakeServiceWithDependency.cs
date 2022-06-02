using DemoDependencyInjection.Models.Dependencies;
using DemoDependencyInjection.Models.Repositories;
using System.Data.Common;

namespace DemoDependencyInjection.Models.Services
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



