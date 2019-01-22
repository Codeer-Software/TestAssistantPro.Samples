using DemoApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace DemoApp
{
    public class DemoAppModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(AllDisplayControl));
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(EntryControl));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }
    }
}
