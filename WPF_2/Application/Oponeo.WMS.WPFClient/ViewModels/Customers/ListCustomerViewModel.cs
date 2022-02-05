using Oponeo.WMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Oponeo.WMS.WPFClient.ViewModels.Customers
{
    internal class ListCustomerViewModel : BaseViewModel
    {

        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
            }
        }

        //private List<Customer> _customers = new List<Customer>();

        //public List<Customer> Customers
        //{
        //    get { return _customers; }
        //    set
        //    {
        //        _customers = value;
        //        OnPropertyChanged();
        //    }
        //}


        public ListCustomerViewModel()
        {
            this.Customers.Add(Customer.CreateFullDataCustomer("Jan", "2321321", "Warszawa"));
            AddCustomer();

        }

        private void AddCustomer()
        {
            Task.Run(async () =>
            {
                await Task.Delay(2000);

            }).ContinueWith(t =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    this.Customers.Add(Customer.CreateFullDataCustomer("Adam", "2321321", "Warszawa"));
                });
            });
        }
    }
}
