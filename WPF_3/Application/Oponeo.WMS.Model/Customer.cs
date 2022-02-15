using System;

namespace Oponeo.WMS.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string TaxIdentifier { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActiveFrom { get; set; }

        public Customer()
        {

        }

        public static Customer CreateEmptyCustomer()
        {
            return new Customer();
        }

        public static Customer CreateFullDataCustomer(string name, string taxIdentifier, string address)
        {
            return new Customer
            {
                Name = name,
                TaxIdentifier = taxIdentifier,
                Address = address
            };
        }

        public static Customer CreateFullDataCustomer(string name, string taxIdentifier, string address, bool isActive)
        {
            return new Customer
            {
                Name = name,
                TaxIdentifier = taxIdentifier,
                Address = address,
                IsActive = isActive
            };
        }

        public override string ToString()
        {
            return $"CustomerName:{Name};TaxIdentifier:{TaxIdentifier};Address:{Address}";
        }
    }
}
