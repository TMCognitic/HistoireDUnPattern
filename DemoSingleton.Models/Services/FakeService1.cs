using DemoSingleton.Models.Repositories;
using System;

namespace DemoSingleton.Models.Services
{
    public class FakeService1 : ISimpleRepository<int>
    {
        #region Singleton Implementation 1
        public static readonly ISimpleRepository<int> Instance = new FakeService1();

        private FakeService1()
        {
        }
        #endregion
        public void Print(int value)
        {
            Console.WriteLine($"J'affiche une valeur de type {value.GetType().Name} : {value}");
        }
    }
}




