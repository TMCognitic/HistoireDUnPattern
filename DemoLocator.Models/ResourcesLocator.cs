using DemoLocator.Models.Dependencies;
using DemoLocator.Models.Repositories;
using DemoLocator.Models.Services;

namespace DemoLocator.Models
{
    public sealed class ResourcesLocator
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

        #region Propriétés
        private ISimpleRepository<int> _fakeService;
        public ISimpleRepository<int> FakeService {
            get {
                return _fakeService ??= new FakeService();
            }
        }

        #region Masqué pour raison de mise en page
        private IDependency<string> _dependency;
        private IDependency<string> Dependency {
            get {
                return _dependency ??= new Dependency<string>();
            }
        }
        #endregion

        private ISimpleRepository<string> _fakeServiceWithDependency;
        public ISimpleRepository<string> FakeServiceWithDependency {
            get {
                return _fakeServiceWithDependency ??= 
                    new FakeServiceWithDependency(Dependency);
            }
        }
        #endregion
    }
}


