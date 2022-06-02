using DemoMicrosoft.Models.Dependencies;
using DemoMicrosoft.Models.Repositories;
using DemoMicrosoft.Models.Services;
using DemoMicrosoft.Tools.Locator;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace DemoMicrosoft.Models
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

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<DbProviderFactory>(sp => SqlClientFactory.Instance);
            services.AddSingleton<ISimpleRepository<int>, FakeService>();
            services.AddSingleton<IDependency<string>, Dependency<string>>();
            services.AddSingleton<ISimpleRepository<string>, FakeServiceWithDependency>();
        }

        public ISimpleRepository<int> FakeService
        {
            get
            {
                return Container.GetService<ISimpleRepository<int>>();
            }
        }
        
        public ISimpleRepository<string> FakeServiceWithDependency
        {
            get
            {
                return Container.GetService<ISimpleRepository<string>>();
            }
        }

        public DbProviderFactory DbProviderFactory
        {
            get
            {
                return Container.GetService<DbProviderFactory>();
            }
        }
    }
}
