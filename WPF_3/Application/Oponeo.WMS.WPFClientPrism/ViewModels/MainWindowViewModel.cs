using Oponeo.WMS.WPFClientPrism.ViewModels.Customers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Unity;

namespace Oponeo.WMS.WPFClientPrism.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        public ICommand AddCustomerCommand { get; set; }

        public ICommand ListCustomerCommand { get; set; }

        public ICommand AddDeliveryNoteCommand { get; set; }

        private IUnityContainer _unityContainer;
        private IRegionManager _regionManager;

        public MainWindowViewModel(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            this._unityContainer = unityContainer;
            this._regionManager = regionManager; ;

            AddCustomerCommand = new DelegateCommand(() =>
            {
                this._regionManager.RequestNavigate("MainRegion", new Uri("AddCustomerView", UriKind.Relative), (NavigationResult nr) =>
                {
                    string result = $"{nr.Error} {nr.Result}";
                });
            });

            ListCustomerCommand = new DelegateCommand(() =>
            {
                this._regionManager.RequestNavigate("MainRegion", new Uri("ListCustomerView", UriKind.Relative));
            });

        }

      
    }
}
