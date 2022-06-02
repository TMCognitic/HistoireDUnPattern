using DemoIOC.Models.Repositories;
using System;

namespace DemoIOC.Models.Services
{
    internal class FakeService : ISimpleRepository<int>
    {
        public void Print(int value)
        {
            Console.WriteLine($"J'affiche une valeur de type {value.GetType().Name} : {value}");
        }
    }
}




