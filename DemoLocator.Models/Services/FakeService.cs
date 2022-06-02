using DemoLocator.Models.Repositories;
using System;

namespace DemoLocator.Models.Services
{
    public class FakeService : ISimpleRepository<int>
    {
        internal FakeService()
        {

        }

        public void Print(int value)
        {
            Console.WriteLine($"J'affiche une valeur de type {value.GetType().Name} : {value}");
        }
    }
}




