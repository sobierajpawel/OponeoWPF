using Oponeo.WMS.Model;
using Oponeo.WMS.WPFClientPrism.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Customer>();
        }
    }
}
