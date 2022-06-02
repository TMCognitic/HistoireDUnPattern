using System;

namespace DemoIOC.Tools.IOC
{
    public interface ISimpleIOC
    {
        TResource GetResource<TResource>();
        void Register<TInterface, TResource>() where TResource : TInterface;
        void Register<TInterface, TResource>(Func<TInterface> builder) where TResource : TInterface;
        void Register<TResource>();
        void Register<TResource>(Func<TResource> builder);
    }
}