using DemoSingleton.Models.Repositories;
using DemoSingleton.Models.Services;
using System;

namespace DemoSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            ISimpleRepository<int> intService1 = FakeService1.Instance;
            ISimpleRepository<int> intService2 = FakeService1.Instance;
            intService1.Print(42);
            Console.WriteLine($"Même instance ? : {intService1 == intService2}");
            Console.WriteLine();

            ISimpleRepository<string> stringService1 = FakeService2.Instance;
            ISimpleRepository<string> stringService2 = FakeService2.Instance;
            stringService1.Print("Quarante deux");
            Console.WriteLine($"Même instance ? : {stringService1 == stringService2}");
            Console.WriteLine();

            ISimpleRepository<Guid> guidService1 = FakeService3.Instance;
            ISimpleRepository<Guid> guidService2 = FakeService3.Instance;
            guidService1.Print(Guid.NewGuid());
            Console.WriteLine($"Même instance ? : {guidService1 == guidService2}");
            Console.WriteLine();
        }
    }
}
