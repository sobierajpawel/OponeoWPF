using Oponeo.WMS.WPFClientPrism.Service;
using Prism.Mvvm;
using Prism.Regions;

namespace Oponeo.WMS.WPFClientPrism.ViewModels.Customers
{
    internal class AddCustomerViewModel : BindableBase, INavigationAware
    {
        private readonly ICustomerService _customerService;

        public AddCustomerViewModel(ICustomerService customerService)
        {
            this._customerService = customerService;
            this._customerService.AddCustomer(new Model.Customer
            {
                Name = "Oponeo"
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
