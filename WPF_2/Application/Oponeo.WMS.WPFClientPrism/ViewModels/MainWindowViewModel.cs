using Oponeo.WMS.Model;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oponeo.WMS.WPFClientPrism.ViewModels
{
    internal class MainWindowViewModel : BindableBase
    {
        private const int WAIT_SAVING_PROCESS_SECONDS = 3000;

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                SetProperty(ref _name, value);
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

        private string _status;

        public string Status
        {
            get { return _status; }
            set => SetProperty(ref _status, value);
        }

        public ICommand SaveCommand { get; set; }

        public MainWindowViewModel(Customer customer)
        {
            customer = Customer.CreateFullDataCustomer("Oponeo", taxIdentifier: "54224", address: "ul Testowa 1, Bydgodszcz");
            Name = customer.Name;
            TaxIdentifier = customer.TaxIdentifier; 
            Address = customer.Address;

            SaveCommand = new DelegateCommand<string>(parameter => Task.Run(()=> SaveData(parameter)));
        }

        private void SaveData(string parameter)
        {
            Status = $"Saving process from {parameter}...";
            Thread.Sleep(WAIT_SAVING_PROCESS_SECONDS);
            Status = "The current customer has been saved";
        }
    }
}
