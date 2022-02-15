using Oponeo.WMS.Model;
using System;
using System.Collections.Generic;

namespace Oponeo.WMS.WPFClientPrism.Service
{
    internal interface ICustomerService
    {
        void AddCustomer(Customer customer);
        IEnumerable<Customer> GetAll();
        Guid Guid { get; }
    }
}
