using System;

namespace DemoLocator.Models.Dependencies
{
    public class Dependency<T> : IDependency<T>
    {
        public void DoSomething(T value)
        {
            Console.WriteLine($"La dépendence fait quelque chose avec la valeur : {value}");
        }
    }
}
