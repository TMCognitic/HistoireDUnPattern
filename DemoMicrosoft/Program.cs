using DemoMicrosoft.Models;
using DemoMicrosoft.Models.Repositories;
using System;
using System.Data.Common;

namespace DemoMicrosoft
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimpleRepository<int> intService1 = ResourcesLocator.Instance.FakeService;
            ISimpleRepository<int> intService2 = ResourcesLocator.Instance.FakeService;
            intService1.Print(42);
            Console.WriteLine($"Même instance ? : {intService1 == intService2}");
            Console.WriteLine();

            ISimpleRepository<string> stringService1 = ResourcesLocator.Instance.FakeServiceWithDependency;
            ISimpleRepository<string> stringService2 = ResourcesLocator.Instance.FakeServiceWithDependency;
            stringService1.Print("Quarante deux");
            Console.WriteLine($"Même instance ? : {stringService1 == stringService2}");
            Console.WriteLine();

            DbProviderFactory providerFactory1 = ResourcesLocator.Instance.DbProviderFactory;
            DbProviderFactory providerFactory2 = ResourcesLocator.Instance.DbProviderFactory;
            Console.WriteLine($"Même instance de DbProviderFactory ? : {providerFactory1 == providerFactory2}");
            Console.WriteLine();
        }
    }
}
