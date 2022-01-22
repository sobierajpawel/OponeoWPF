using Oponeo.WMS.Model;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace Oponeo.WMS.WPFClientPrism.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                SetProperty(ref _name, value, () => { RaisePropertyChanged(nameof(FullCustomerData)); });
            }
        }

        private string _taxIdentifier;

        public string TaxIdentifier
        {
            get { return _taxIdentifier; }
            set => SetProperty(ref _taxIdentifier, value);
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set => SetProperty(ref _address, value);
        }

        public string FullCustomerData
        {
            get => $"FullCustomerData: Name-{Name};TaxIdentifier-{TaxIdentifier};Address-{Address}";
        }

        public MainWindowViewModel(Customer customer)
        {
            customer = Customer.CreateFullDataCustomer("Oponeo", taxIdentifier: "54224", address: "ul Testowa 1, Bydgodszcz");
            Name = customer.Name;
            TaxIdentifier = customer.TaxIdentifier; 
            Address = customer.Address;
            SetDataAfterAWhile();
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
