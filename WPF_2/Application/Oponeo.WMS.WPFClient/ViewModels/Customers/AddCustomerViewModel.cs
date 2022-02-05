using Oponeo.WMS.Model;
using Oponeo.WMS.WPFClient.Command;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oponeo.WMS.WPFClient.ViewModels.Customers
{
    internal class AddCustomerViewModel : BaseViewModel
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

        public ICommand SaveCommand { get; set;}

        private string _status;

        public string Status
        {
            get { return _status; }
            set { _status = value; OnPropertyChanged(); }
        }


        public string FullCustomerData
        {
            get => $"FullCustomerData: Name-{Name};TaxIdentifier-{TaxIdentifier};Address-{Address}";
        }


        public AddCustomerViewModel()
        {
            _customer = Customer.CreateEmptyCustomer();
            InitializeCommand();
        }

        public override string ToString()
        {
            return $"MainWindowViewModel: Name:{Name};TaxIdentifier:{TaxIdentifier}; Address:{Address}";
        }


        private void InitializeCommand()
        {
            Name = "Test";
            SaveCommand = new RelayCommand(o =>
            {
                string source = string.Empty;

                if (o is string parameter)
                {
                    source = parameter;
                }

                Task.Run(() => Save(source));
            }, x => !string.IsNullOrWhiteSpace(TaxIdentifier));
        }

        private void Save(string source)
        {
            Status = $"Saving... from {source}";
            Thread.Sleep(5000);
            Status = $"Customer {Name} has been saved";
        }
    }
}
