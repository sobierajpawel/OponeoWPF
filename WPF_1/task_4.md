## Task 4

### Creating a project in PRISM

1. Create right-click solution -> Add -> New Project and create new WPFClient for Prism. Name a project as **"Oponeo.WMS.WPFClientPrism"**.

2. Install Prism.Unity from Nuget package manager.

3. Change in App.xaml declaration with PrismApplication like this.
```
<prism:PrismApplication
             x:Class="Oponeo.WMS.WPFClientPrism.App"
             ...
             xmlns:prism="http://prismlibrary.com/">
<Application.Resources>
...
```

4. Change code behind - App.xaml.cs and implement methods needed by PrismApplication.

```cs
 public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            throw new System.NotImplementedException();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            throw new System.NotImplementedException();
        }
    }
```

5. Change implementation of this methods into.

```cs
  public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
```

6. Create Views and ViewModels folder in this created project which will be similar like at the beginning of the task 3. Below you find them. Remove ```OnPropertyChanged()``` calls and the inheritance from BaseViewModel. Add changing method like in the task 3.

```cs
 public class MainWindowViewModel 
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _taxIdentifier;

        public string TaxIdentifier
        {
            get { return _taxIdentifier; }
            set { _taxIdentifier = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        
        public string FullCustomerData
        {
            get => $"CustomerName:{Name}, TaxIdentifier:{TaxIdentifier}, Address: {Address}";
        }

        public MainWindowViewModel()
        {
            Customer customer = Customer.CreateCustomerWithFields("Oponeo", "321321321", "Warszawa ul. Testowa 1");
            TaxIdentifier = customer.TaxIdentifier;
            Address = customer.Address;
            Name = customer.Name;
            ChangeValueAfterWhile();
        }

        private void ChangeValueAfterWhile()
        {
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                Name = "Changed name";
            });
        }

        public override string ToString()
        {
            return $"CustomerName:{Name}, TaxIdentifier:{TaxIdentifier}, Address: { Address}";
        }
    }
```
```
<Window x:Class="Oponeo.WMS.WPFClientPrism.Views.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Oponeo.WMS.WPFClientPrism"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid Margin="10">

        <Grid.RowDefinitions>
            <RowDefinition Height="auto" />
            <RowDefinition Height="auto" />
            <RowDefinition Height="auto" />
            <RowDefinition Height="auto" />
            <RowDefinition Height="auto" />
            <RowDefinition Height="auto" />
        </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>

        <Label Grid.Row="0" Grid.ColumnSpan="2" FontSize="12" FontWeight="Bold" HorizontalAlignment="Center"/>

        <Label Grid.Row="1">Customer Name</Label>
        <Label Grid.Row="2">Tax identifier</Label>
        <Label Grid.Row="3">Address</Label>
        <Button Grid.Row="4" Margin="20" Grid.ColumnSpan="2">Save</Button>

        <TextBox x:Name="CustomerTextBox" Grid.Column="1" Grid.Row="1" Text="{Binding Name}"></TextBox>
        <TextBox x:Name="TaxIdentifierTextBox" Grid.Column="1" Grid.Row="2" Text="{Binding TaxIdentifier}"></TextBox>
        <TextBox x:Name="AddressTextBox" Grid.Column="1" Grid.Row="3" Text="{Binding Address}"></TextBox>

        <Label Grid.Row="5" Grid.ColumnSpan="2" FontSize="12" FontWeight="Bold" HorizontalAlignment="Center" Content="{Binding FullCustomerData}"/>
    </Grid>
</Window>
```

7. Add inhertiance from ```BindableBase``` to ```MainWindowViewModel```. Add autowiring ViewModel class. Inspect if the constructor of ```MainWindowViewModel``` is being called.

```cs
 public class MainWindowViewModel : BindableBase
```
```
xmlns:prism="http://prismlibrary.com/"
prism:ViewModelLocator.AutoWireViewModel="True"
```

8. Replace setters in ```MainWindowViewModel``` with using ```SetProperty()``` method from Prism.

```cs
        public string Name
        {
            get { return _name; }
            set => SetProperty(ref _name, value);
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
```

8. Inspect what will happen. As you will notice propery ```FullCustomerData``` will not change. Replace setter in ```Name``` property to:

```cs
public string Name
{
    get { return _name; }
    set => SetProperty(ref _name, value, () => { RaisePropertyChanged(nameof(FullCustomerData)); });
}
```
9. Run and inspect if everything works corectly.
