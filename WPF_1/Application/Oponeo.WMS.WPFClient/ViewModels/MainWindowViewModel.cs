using Oponeo.WMS.Model;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Oponeo.WMS.WPFClient.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private Customer _customer;

        public string Name
        {
            get { return _customer.Name; }
            set 
            {
                _customer.Name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullCustomerData));
            }
        }

        public string TaxIdentifier
        {
            get { return _customer.TaxIdentifier; }
            set 
            { 
                _customer.TaxIdentifier = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get { return _customer.Address; }
            set 
            { 
                _customer.Address = value;
                OnPropertyChanged();
            }
        }

        public string FullCustomerData
        {
            get => $"FullCustomerData: Name-{Name};TaxIdentifier-{TaxIdentifier};Address-{Address}";
        }


        public MainWindowViewModel()
        {
            _customer = Customer.CreateEmptyCustomer();
            //SetDataAfterAWhile();
        }

        public override string ToString()
        {
            return $"MainWindowViewModel: Name:{Name};TaxIdentifier:{TaxIdentifier}; Address:{Address}";
        }


        private void SetDataAfterAWhile()
        {
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                Name = "Oponeo - changed";
            });
        }
    }
}
