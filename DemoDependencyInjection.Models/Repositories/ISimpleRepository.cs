﻿namespace DemoDependencyInjection.Models.Repositories
{
    public interface ISimpleRepository<T>
    {
        void Print(T value);
    }
}
