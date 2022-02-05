using Oponeo.WMS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Oponeo.WMS.WPFClient.ViewModels.Customers
{
    public class ListCustomerViewModel : BaseViewModel
    {
        private const int WAITED_TIME_FOR_NEW_CUSTOMER_IN_SECONDS = 2000;

        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set 
            { 
                _customers = value; 
                OnPropertyChanged();
            }
        }


        public ListCustomerViewModel()
        {
            this.Customers.Add(Customer.CreateFullDataCustomer("Oponeo", "125789214", "ul.Testowa 1, Bydgoszcz"));
            AddNewCustomer();
        }

        private void AddNewCustomer()
        {
            Task.Run(async () =>
            {
                await Task.Delay(WAITED_TIME_FOR_NEW_CUSTOMER_IN_SECONDS);
               
            }).ContinueWith(t=>
            {
                App.Current.Dispatcher.BeginInvoke((Action)delegate(){
                    this.Customers.Add(Customer.CreateFullDataCustomer("New customer", "DE56752121", "ul.Testowa 1, Berlin"));
                });
            });
        }
    }
}
