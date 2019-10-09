using Prism.Unity;
using Prism.Regions;
using System.Windows;
using Prism.Ioc;

namespace WpfCore3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell() => Container.Resolve<MainWindow>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ContentView>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Container.Resolve<IRegionManager>().RequestNavigate("ContentRegion", nameof(ContentView));
        }
    }
}
