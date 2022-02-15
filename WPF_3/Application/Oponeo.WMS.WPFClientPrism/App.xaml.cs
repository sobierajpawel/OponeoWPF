using Oponeo.WMS.Model;
using Oponeo.WMS.WPFClientPrism.Service;
using Oponeo.WMS.WPFClientPrism.Views;
using Oponeo.WMS.WPFClientPrism.Views.Customers;
using Prism.Ioc;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using Unity;

namespace Oponeo.WMS.WPFClientPrism
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var shell = Container.Resolve<MainWindow>();
            return shell;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var container = Container.GetContainer();
            var regionManager = container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("MainRegion", "ListCustomerView");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ICustomerService, CustomerService>();

#if DEBUG
            containerRegistry.GetContainer().AddExtension(new Diagnostic());
#endif
            containerRegistry.RegisterForNavigation<AddCustomerView>("AddCustomerView");
            containerRegistry.RegisterForNavigation<ListCustomerView>("ListCustomerView");

        }
    }
}
