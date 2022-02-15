using Oponeo.WMS.Model;
using System;
using System.Collections.Generic;

namespace Oponeo.WMS.WPFClientPrism.Service
{
    internal class CustomerService : ICustomerService
    {
        private List<Customer> _customerList = new List<Customer>();
        private Guid guid;
        public Guid Guid => guid;

        public CustomerService()
        {
            guid = Guid.NewGuid();
        }

        public void AddCustomer(Customer customer)
        {
            _customerList.Add(customer);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerList;
        }
    }
}
