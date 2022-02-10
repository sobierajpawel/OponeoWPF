## Task 4

### PRISM DI and Navigation via RegionManager

1. Create `ListCustomerView` (remember it must be as a user control) and the corresponding `ListCustomerViewModel` in the `Oponeo.WMS.ClientPrism` project. Remember about the inheritance from `BindableBase`

```cs
public class ListCustomerViewModel : BindableBase
```

2. Add auto-wired view model for the view's declaration.

```
<UserControl x:Class="Oponeo.WMS.WPFClientPrism.Views.Customers.AddCustomerView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:Oponeo.WMS.WPFClientPrism.Views.Customers"
             xmlns:prism="http://prismlibrary.com/"
             prism:ViewModelLocator.AutoWireViewModel="True"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    <Grid>
            
    </Grid>
</UserControl>
```

3. Add simple menu in `MainWindow` based on `DataTemplate` like in the `Oponeo.WMS.WPFClient` project.

```
 <Window.Resources>
        <DataTemplate DataType="{x:Type vm_customers:AddCustomerViewModel}">
            <v_customers:AddCustomerView/>
        </DataTemplate>
        <DataTemplate DataType="{x:Type vm_customers:ListCustomerViewModel}">
            <v_customers:ListCustomerView/>
        </DataTemplate>
    </Window.Resources>
    <Grid Margin="20">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="150"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>

        <StackPanel Grid.Column="0">
            <Button Command="{Binding AddCustomerCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Fill="Black" Stretch="Uniform" Width="40" Height="40"
                         Data="M15,14C12.33,14 7,15.33 7,18V20H23V18C23,15.33 17.67,14 15,14M6,10V7H4V10H1V12H4V15H6V12H9V10M15,12A4,4 0 0,0 19,8A4,4 0 0,0 15,4A4,4 0 0,0 11,8A4,4 0 0,0 15,12Z"/>
                        <TextBlock Text="Add customer" FontSize="14"/>
                    </StackPanel>
                </Button.Content>
            </Button>
            <Button Command="{Binding ListCustomerCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Fill="Black" Stretch="Uniform" Width="40" Height="40"
                         Data="M16 17V19H2V17S2 13 9 13 16 17 16 17M12.5 7.5A3.5 3.5 0 1 0 9 11A3.5 3.5 0 0 0 12.5 7.5M15.94 13A5.32 5.32 0 0 1 18 17V19H22V17S22 13.37 15.94 13M15 4A3.39 3.39 0 0 0 13.07 4.59A5 5 0 0 1 13.07 10.41A3.39 3.39 0 0 0 15 11A3.5 3.5 0 0 0 15 4Z"/>
                        <TextBlock Text="Customers" FontSize="14"/>
                    </StackPanel>
                </Button.Content>
            </Button>
        </StackPanel>

        <ContentControl Margin="20" Grid.Column="1" Content="{Binding CurrentViewModel}"/>
    </Grid>
</Window>
```

4. Remember about proper namespace for views and viewmodels.

```
   xmlns:vm_customers="clr-namespace:Oponeo.WMS.WPFClientPrism.ViewModels.Customers"
   xmlns:v_customers="clr-namespace:Oponeo.WMS.WPFClientPrism.Views.Customers"
```

5. Add `BindableBase` inheritance for `AddCustomerViewModel`.

6. Replace `MainWindowViewModel` for similar implementation like in the `Oponeo.WMS.WPFClient`. Remember about using `DelegateCommand` and replacing `BaseViewModel` with `BindableBase`.
Use also `SetProperty<T>` instead of `OnPropertyChanged`.

```cs
 internal class MainWindowViewModel : BindableBase
    {
        private List<BindableBase> _viewModels = new List<BindableBase>();

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                SetProperty(ref _currentViewModel,value);
            }
        }

        public ICommand AddCustomerCommand { get; set; }

        public ICommand ListCustomerCommand { get; set; }


        public MainWindowViewModel()
        {
            AddCustomerCommand = new DelegateCommand(() =>
            {
                SetViewModel(typeof(AddCustomerViewModel));
            });

            ListCustomerCommand = new DelegateCommand(() =>
            {
                SetViewModel(typeof(ListCustomerViewModel));
            });
        }

        private void SetViewModel(Type type)
        {
            if (type.IsSubclassOf(typeof(BindableBase)))
            {
                if (_viewModels.Any(x => x.GetType() == type))
                {
                    CurrentViewModel = (BindableBase)_viewModels.Where(x => x.GetType() == type).FirstOrDefault();
                }
                else
                {
                    CurrentViewModel = (BindableBase)Activator.CreateInstance(type);
                    _viewModels.Add(CurrentViewModel);
                }
            }
        }
    }
```

7. Add simple `Label` for `ListCustomerView` and `AddCustomerView` and check if it works correctly.

```
 <Grid>
        <Label Content="AddCustomerView"/>
    </Grid>
```


```
 <Grid>
        <Label Content="ListCustomerView"/>
    </Grid>
```

8. Add `Services` folder in the `Oponeo.WMS.WPFClientPrism`.

9. Add interface in this folder `ICustomerService`.

```cs
  public interface ICustomerService
    {
        void AddNewCustomer(Customer customer);
        IEnumerable<Customer> GetCustomers();
        Guid GetGuid { get; }
    }
```

10. Add `CustomerService` implementation.

```cs
 public class CustomerService : ICustomerService
    {
        private List<Customer> customers = new List<Customer>();

        public CustomerService()
        {
            guid = Guid.NewGuid();
        }

        private Guid guid;
        public Guid GetGuid => guid;

        public void AddNewCustomer(Customer customer)
        {
            this.customers.Add(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }
    }
```

11. Change `MainWindowViewModel` implementation to pass `IUnityContainer` implementation injected in the `ctor`.

```cs
      private IUnityContainer _unityContainer;

        public MainWindowViewModel(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
            AddCustomerCommand = new DelegateCommand(() =>
            {
                SetViewModel(typeof(AddCustomerViewModel));
            });

            ListCustomerCommand = new DelegateCommand(() =>
            {
                SetViewModel(typeof(ListCustomerViewModel));
            });
        }
  ```
  
  12. Change `SetViewModel` method in `MainWindowViewModel` class.
  
  ```cs
   private void SetViewModel(Type type)
        {
            if (type.IsSubclassOf(typeof(BindableBase)))
            {
                if (_viewModels.Any(x => x.GetType() == type))
                {
                    CurrentViewModel = (BindableBase)_viewModels.Where(x => x.GetType() == type).FirstOrDefault();
                }
                else
                {
                    CurrentViewModel = (BindableBase)_unityContainer.Resolve(type,null, null);
                    _viewModels.Add(CurrentViewModel);
                }
            }
        }
  ```
  
  13. Add injecting `CustomerService` in both `AddCustomerViewModel` and `ListCustomerViewModel`.
  
  ```cs
    public class AddCustomerViewModel : BindableBase
    {
        private readonly CustomerService _customerService;

        public AddCustomerViewModel(CustomerService customerService)
        {
            _customerService = customerService;
        }
    }
  ```
  
  ```cs
   public class ListCustomerViewModel : BindableBase
    {
        private readonly CustomerService _customerService;

        public ListCustomerViewModel(CustomerService customerService)
        {
            _customerService = customerService;
        }
    }
  ```
  
  14. Place breakpoints in both constructors and inspect if `CustomerService` is properly injected in the `AddCustomerViewModel` as well as `ListCustomerViewModel`.
  
  15. Replace `CustomerService` with `ICustomerService` and inspect if exception is thrown when you click for a differnet module.
  
  ```cs
  public class AddCustomerViewModel : BindableBase
    {
        private readonly ICustomerService _customerService;

        public AddCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
    }
 ```
 
 16. Write in `App.xaml.cs` in the method `RegisterTypes` an extra diagnostic extenstion.
 
 ```cs
         protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
#if DEBUG
            containerRegistry.GetContainer().AddExtension(new Diagnostic());
#endif
        }
 ```
 
 17. Register `CustomerService` as `ICustomerService' in `RegisterTypes` method.
 
 ```cs
  containerRegistry.Register<ICustomerService, CustomerService>();
 ```
 
 18. Add code to check in viewmodels' constructors.
 
 ```cs
  private readonly ICustomerService _customerService;

        public AddCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            _customerService.AddNewCustomer(new Model.Customer
            {
                Name = "Oponeo"
            });
        }
```

```cs
 public class ListCustomerViewModel : BindableBase
    {
        private readonly ICustomerService _customerService;

        public ListCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;

            var list = _customerService.GetCustomers();
        }
    }
```

19. Run and inspect if is the same instance.

20. Remove `prism:ViewModelLocator.AutoWireViewModel="True"` if constructors are invoked twice.

21. Replace registration as a singleton and inspect what will happen when you put breakpoints.

```cs
 containerRegistry.RegisterSingleton<ICustomerService, CustomerService>();
```

22. Remove `DataTemplates` in `MainWindow.xaml`.

23. Replace `ContentControl` with `RegionManager` and `RegionName`

```
<ContentControl Margin="20" Grid.Column="1" prism:RegionManager.RegionName="MainRegion"/>
```

24. Add `RegisterForNavigation` in `RegisterTypes` for `AddCustomerView` and `ListCustomerView` as below.

```cs
   protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
#if DEBUG
            containerRegistry.GetContainer().AddExtension(new Diagnostic());
#endif
            containerRegistry.RegisterSingleton<ICustomerService, CustomerService>();

            containerRegistry.RegisterForNavigation<AddCustomerView>("AddCustomerView");
            containerRegistry.RegisterForNavigation<ListCustomerView>("ListCustomerView");
        }
```

25. Add `prism:ViewModelLocator.AutoWireViewModel="True"` in the `AddCustomerView` as well as `ListCustomerView`.

26. Change implementation in `MainWindowViewModel` to this one.

```cs
 private IUnityContainer _unityContainer;

        private IRegionManager _regionManager;

        public MainWindowViewModel(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;

            AddCustomerCommand = new DelegateCommand(() =>
            {
                _regionManager.RequestNavigate("MainRegion", new Uri("AddCustomerView", UriKind.Relative), (NavigationResult r) =>
                 {
                     string result = $"{r.Error} {r.Result}";
                 });
            });

            ListCustomerCommand = new DelegateCommand(() =>
            {
                _regionManager.RequestNavigate("MainRegion", new Uri("ListCustomerView", UriKind.Relative), (NavigationResult r) =>
                {
                    string result = $"{r.Error} {r.Result}";
                });
            });
        }
```
