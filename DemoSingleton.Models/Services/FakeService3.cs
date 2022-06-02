using DemoSingleton.Models.Repositories;
using System;

namespace DemoSingleton.Models.Services
{
    public class FakeService3 : ISimpleRepository<Guid>
    {
        #region Singleton Implementation 3
        private static ISimpleRepository<Guid> _instance;

        public static ISimpleRepository<Guid> Instance
        {
            //A partir de C# 8.0
            get { return _instance ??= new FakeService3(); }
        }

        private FakeService3()
        {
        }
        #endregion
        public void Print(Guid value)
        {
            Console.WriteLine($"J'affiche une valeur de type {value.GetType().Name} : {value}");
        }
    }
}



