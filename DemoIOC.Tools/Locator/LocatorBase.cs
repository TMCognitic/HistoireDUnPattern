using DemoIOC.Tools.IOC;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoIOC.Tools.Locator
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

