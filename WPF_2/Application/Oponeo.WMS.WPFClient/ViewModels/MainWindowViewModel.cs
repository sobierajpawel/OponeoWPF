using Oponeo.WMS.Model;
using Oponeo.WMS.WPFClient.Command;
using Oponeo.WMS.WPFClient.ViewModels.Customers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oponeo.WMS.WPFClient.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private List<BaseViewModel> viewModels = new List<BaseViewModel>();

        private BaseViewModel _currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public string MessageText => "Test";

        public ICommand AddCustomerCommand { get; set; }

        public ICommand ListCustomerCommand { get; set; }

        public MainWindowViewModel()
        {
            InitializeCommand();
        }

        private void InitializeCommand()
        {
            AddCustomerCommand = new RelayCommand(o =>
            {
                SetViewModelAsCurrent(typeof(AddCustomerViewModel));
            });
            ListCustomerCommand = new RelayCommand(o =>
            {
                SetViewModelAsCurrent(typeof(ListCustomerViewModel));
            });
        }

        private void SetViewModelAsCurrent(Type type)
        {
            if (type.IsSubclassOf(typeof(BaseViewModel)))
            {
                if (viewModels.Any(x=>x.GetType() == type))
                {
                    CurrentViewModel = (BaseViewModel)viewModels.Where(x => x.GetType() == type).FirstOrDefault();
                }
                else
                {
                    CurrentViewModel = (BaseViewModel)Activator.CreateInstance(type);
                    viewModels.Add(CurrentViewModel);
                }
                
            }
        }

        //public ObservableCollection<TypeAndDisplay> NavigationViewModelTypes { get; set; } = new ObservableCollection<TypeAndDisplay>
        //(
        //    new List<TypeAndDisplay>
        //    {
        //        new TypeAndDisplay{ Name="Log In", VMType= typeof(LoginViewModel) },
        //        new TypeAndDisplay{ Name="User", VMType= typeof(UserViewModel) }
        //    }
        //);

    }
}
