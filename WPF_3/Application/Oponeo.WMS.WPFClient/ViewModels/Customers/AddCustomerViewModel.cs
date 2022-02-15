using Oponeo.WMS.Model;
using Oponeo.WMS.WPFClient.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oponeo.WMS.WPFClient.ViewModels.Customers
{
    public class AddCustomerViewModel : BaseViewModel
    {
        private Customer _customer;
        private const int WAIT_SAVING_PROCESS_SECONDS = 3000;

        public string Name
        {
            get { return _customer.Name; }
            set
            {
                _customer.Name = value;
                OnPropertyChanged();
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

        private string _status;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        public bool IsActive
        {
            get { return _customer.IsActive; }
            set
            {
                _customer.IsActive = value;
                OnPropertyChanged();
            }
        }

        public DateTime ActiveFrom
        {
            get { return _customer.ActiveFrom; }
            set
            {
                _customer.ActiveFrom = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public ICommand SetDefaultCommand { get; set; }

        public AddCustomerViewModel()
        {
            _customer = Customer.CreateEmptyCustomer();
            Name = "Oponeo";
            ActiveFrom = DateTime.Now;
            IsActive = true;

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SetDefaultCommand = new RelayCommand(o =>
            {
                SetDefaultValues();
            });

            SaveCommand = new RelayCommand(o =>
            {
                if (o is string parameter)
                {
                    Task.Run(() => SaveData(parameter));
                }
            },x => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(TaxIdentifier) && !string.IsNullOrWhiteSpace(Address));
        }

        private void SaveData(string parameter)
        {
            Status = $"Saving process from {parameter}...";
            Thread.Sleep(WAIT_SAVING_PROCESS_SECONDS);
            Status = $"The current customer {Name} has been saved";
        }

        private void SetDefaultValues()
        {
            Name = String.Empty;
            TaxIdentifier = String.Empty;
            Address = String.Empty;
            ActiveFrom = DateTime.Now;
            IsActive = true;
        }
    }

}
