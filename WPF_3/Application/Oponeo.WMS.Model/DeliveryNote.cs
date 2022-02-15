using System;

namespace Oponeo.WMS.Model
{
    public class DeliveryNote
    {
        public Customer Customer { get; set; }

        public DateTime DocumentDate { get; set; }

        public string DocumentNumber { get; set; }

        public string Description { get; set; }

        public bool IsCustomerActive()
        {
            if (Customer != null)
            {
                return Customer.IsActive;   
            }
            return false;
        }

    }
}
