namespace DemoLocator.Models.Repositories
{
    public interface ISimpleRepository<T>
    {
        void Print(T value);
    }
}
