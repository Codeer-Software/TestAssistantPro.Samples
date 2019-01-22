using DemoApp.Model;
using DemoApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace DemoApp
{
    public partial class App
    {
        protected override Window CreateShell()
            => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
            => containerRegistry.RegisterInstance<IModelDataManager>(new ModelDataManager());

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
            => moduleCatalog.AddModule<DemoAppModule>();
    }
}
