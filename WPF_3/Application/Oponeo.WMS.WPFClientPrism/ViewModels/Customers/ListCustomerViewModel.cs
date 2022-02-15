using Oponeo.WMS.WPFClientPrism.Service;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oponeo.WMS.WPFClientPrism.ViewModels.Customers
{
    internal class ListCustomerViewModel : BindableBase
    {
        private readonly ICustomerService _customerService;
        public ListCustomerViewModel(ICustomerService customerService)
        {
            this._customerService = customerService;

            var customers = this._customerService.GetAll();
        }
    }
}
