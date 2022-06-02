namespace DemoDependencyInjection.Models.Dependencies
{
    public interface IDependency<T>
    {
        void DoSomething(T value);
    }
}
