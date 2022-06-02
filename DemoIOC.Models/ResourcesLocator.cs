using DemoIOC.Models.Dependencies;
using DemoIOC.Models.Repositories;
using DemoIOC.Models.Services;
using DemoIOC.Tools.Locator;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace DemoIOC.Models
{
    public sealed class ResourcesLocator : LocatorBase
    {
        #region Implémentation du Singleton
        private static ResourcesLocator _instance;

        public static ResourcesLocator Instance
        {
            get
            {
                return _instance ??= new ResourcesLocator();
            }
        }       

        private ResourcesLocator()
        {

        }
        #endregion

        protected override void ConfigureResources()
        {
            Container.Register<DbProviderFactory, SqlClientFactory>();
            Container.Register<ISimpleRepository<int>, FakeService>();
            Container.Register<IDependency<string>, Dependency<string>>();
            Container.Register<ISimpleRepository<string>, FakeServiceWithDependency>(() => new FakeServiceWithDependency(Container.GetResource<IDependency<string>>()));
        }

        public ISimpleRepository<int> FakeService
        {
            get
            {
                return Container.GetResource<ISimpleRepository<int>>();
            }
        }
        
        public ISimpleRepository<string> FakeServiceWithDependency
        {
            get
            {
                return Container.GetResource<ISimpleRepository<string>>();
            }
        }

        public DbProviderFactory DbProviderFactory
        {
            get
            {
                return Container.GetResource<DbProviderFactory>();
            }
        }
    }
}
