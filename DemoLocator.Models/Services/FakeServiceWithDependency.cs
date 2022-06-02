using DemoLocator.Models.Dependencies;
using DemoLocator.Models.Repositories;
using System;

namespace DemoLocator.Models.Services
{
    public class FakeServiceWithDependency : ISimpleRepository<string>
    {
        private readonly IDependency<string> _dependency;

        internal FakeServiceWithDependency(IDependency<string> dependency)
        {
            _dependency = dependency;
        }

        public void Print(string value)
        {
            _dependency.DoSomething(value);
        }
    }
}



