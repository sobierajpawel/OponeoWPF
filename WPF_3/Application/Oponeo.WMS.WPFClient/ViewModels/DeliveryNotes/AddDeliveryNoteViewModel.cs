using Oponeo.WMS.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Oponeo.WMS.WPFClient.ViewModels.DeliveryNotes
{
    internal class AddDeliveryNoteViewModel : BaseViewModel
    {
        private DeliveryNote _deliveryNote = new DeliveryNote();

        public string DocumentNumber
        {
            get { return _deliveryNote.DocumentNumber; }
            set
            {
                //if (value.Length < 5 || value.Length > 10)
                //    throw new ArgumentException("A value inserted in the DocumentNumber field must be between 5 and 10 characters");

                _deliveryNote.DocumentNumber = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _deliveryNote.Description; }
            set
            {
                _deliveryNote.Description = value;
                OnPropertyChanged();
            }
        }

        public DateTime DocumentDate
        {
            get { return _deliveryNote.DocumentDate; }
            set
            {
                _deliveryNote.DocumentDate = value;
                OnPropertyChanged();
            }
        }

        private bool _isActiveCustomer;

        public bool IsActiveCustomer
        {
            get { return _isActiveCustomer; }
            set 
            {
                _isActiveCustomer = value;
                OnPropertyChanged();
            }
        }


        public Customer SelectedCustomer
        {
            get { return _deliveryNote.Customer; }
            set
            {
                _deliveryNote.Customer = value;
                if (_deliveryNote.Customer != null)
                {
                    IsActiveCustomer = _deliveryNote.IsCustomerActive();
                }
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        public ObservableCollection<Customer>  Customers
        {
            get { return customers; }
            set 
            { 
                customers = value;
                OnPropertyChanged();
            }
        }

        //public string Error => String.Empty;

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string result = string.Empty;

        //        switch(columnName)
        //        {
        //            case "DocumentNumber":
        //                {
        //                    if (string.IsNullOrWhiteSpace(DocumentNumber))
        //                        result = "The field of the document number must be filled out";
        //                    else if (DocumentNumber.Length < 10)
        //                        result = "The field of the document number must have length maximum 9 characters";
        //                }
        //                break;
        //            case "Description":
        //                {
        //                    if (string.IsNullOrWhiteSpace(Description))
        //                        result = "The field of the description must be filled out";
        //                }
        //                break;
        //        }

        //        return result;
        //    }
        //}

        public AddDeliveryNoteViewModel()
        {
            DocumentDate = DateTime.Now.AddDays(1);
            Customers.Add(Customer.CreateFullDataCustomer("Oponeo", "545453221", "Bydgoszcz", isActive: true));
            Customers.Add(Customer.CreateFullDataCustomer("SDA academy", "545453221", "Warszawa", isActive: false));
        }
    }
}
