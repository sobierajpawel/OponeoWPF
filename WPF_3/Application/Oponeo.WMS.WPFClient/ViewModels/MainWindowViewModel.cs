using Oponeo.WMS.WPFClient.Commands;
using Oponeo.WMS.WPFClient.ViewModels.Customers;
using Oponeo.WMS.WPFClient.ViewModels.DeliveryNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Oponeo.WMS.WPFClient.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private List<BaseViewModel> _viewModels = new List<BaseViewModel>();

        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set 
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCustomerCommand { get; set; }

        public ICommand ListCustomerCommand { get; set; }

        public ICommand AddDeliveryNoteCommand { get; set; }

        public MainWindowViewModel()
        {
            AddCustomerCommand = new RelayCommand(o =>
            {
                SetViewModel(typeof(AddCustomerViewModel));
            });

            ListCustomerCommand = new RelayCommand(o =>
            {
                SetViewModel(typeof(ListCustomerViewModel));
            });

            AddDeliveryNoteCommand = new RelayCommand(o =>
            {
                SetViewModel(typeof(AddDeliveryNoteViewModel));
            });
        }

        private void SetViewModel(Type type)
        {
            if (type.IsSubclassOf(typeof(BaseViewModel)))
            {
                if (_viewModels.Any(x=>x.GetType() == type))
                {
                    CurrentViewModel = (BaseViewModel)_viewModels.Where(x=>x.GetType()==type).FirstOrDefault();
                }
                else
                {
                    CurrentViewModel = (BaseViewModel)Activator.CreateInstance(type);
                    _viewModels.Add(CurrentViewModel);
                }
            }
        }
    }
}
