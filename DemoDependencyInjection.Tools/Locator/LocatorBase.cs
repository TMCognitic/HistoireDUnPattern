using DemoDependencyInjection.Tools.IOC;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDependencyInjection.Tools.Locator
{
    public abstract class LocatorBase
    {
        protected ISimpleIOC Container { get; private set; }

        protected LocatorBase(): this(new SimpleIOC())
        {

        }

        protected LocatorBase(ISimpleIOC container)
        {
            Container = container;
            ConfigureResources();
        }

        protected abstract void ConfigureResources();
    }
}
