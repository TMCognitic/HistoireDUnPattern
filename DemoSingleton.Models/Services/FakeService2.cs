using DemoSingleton.Models.Repositories;
using System;

namespace DemoSingleton.Models.Services
{
    public class FakeService2 : ISimpleRepository<string>
    {
        #region Singleton Implementation 2
        private static ISimpleRepository<string> _instance;

        public static ISimpleRepository<string> Instance
        {
            get { return _instance ?? (_instance = new FakeService2()); }
        }

        private FakeService2()
        {
        }
        #endregion
        public void Print(string value)
        {
            Console.WriteLine($"J'affiche une valeur de type {value.GetType().Name} : {value}");
        }
    }
}



