using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMicrosoft.Tools.Locator
{
    public abstract class LocatorBase
    {
        protected IServiceProvider Container { get; private set; }

        protected LocatorBase()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            Container = serviceCollection.BuildServiceProvider();
        }

        protected abstract void ConfigureServices(IServiceCollection services);
    }
}
