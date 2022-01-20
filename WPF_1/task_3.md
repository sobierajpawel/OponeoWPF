## Task 3 ##

### Creating ViewModel  

1. First we need to create a viewmodel class. Create a class and name it MainWindowViewModel in **ViewModels** folder.

2. Write a viewmodel class which replace properties and method ```ToString()``` in User class from task 2. It should look like this below.

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

  public MainWindowViewModel()
  {

  }

  public override string ToString()
  {
      return $"CustomerName:{Name}, TaxIdentifier:{TaxIdentifier}, Address: { Address}";
  }
}
```

3. Add namespace into XAML class.

```
xmlns:vms="clr-namespace:Oponeo.WMS.WPFClient.ViewModels"
```

4. Replace model class into new created ViewModel

```
<Window.DataContext>
    <vms:MainWindowViewModel />
</Window.DataContext>
```

5. Replace code behind method after clicking button (replace ```Customer``` into ```MainWindowViewModel``` class).

```cs
private void Button_Click(object sender, RoutedEventArgs e)
{
    if (this.DataContext is MainWindowViewModel mainWindowViewModel)
    {
        MessageBox.Show(mainWindowViewModel.ToString());
    }           
}
```

6. Inspect if application work the same like at the end of the task 2.

7. Add static method into Customer class which allows to create a rich customer object like this.

```cs
public static Customer CreateCustomerWithFields(string name, string taxIdentifier, string address)
{
    return new Customer
    {
       Name = name,
       TaxIdentifier = taxIdentifier,
       Address = address
     };
}
```

8. Create abstract BaseViewModel in ViewModels folder.

```cs
public abstract class BaseViewModel : INotifyPropertyChanged
{
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
}
```

9. Replace properties from MainWindowViewModel to call a customer's object properties. Create also rich a rich instance of ```Customer``` class. Place inheritance from ```BaseViewModel```.

```cs
public class MainWindowViewModel : BaseViewModel
    {
        private Customer _customer;

        public string Name
        {
            get { return _customer.Name; }
            set { _customer.Name = value; }
        }

        public string TaxIdentifier
        {
            get { return _customer.TaxIdentifier; }
            set { _customer.TaxIdentifier = value; }
        }

        public string Address
        {
            get { return _customer.TaxIdentifier; }
            set { _customer.TaxIdentifier = value; }
        }

        public MainWindowViewModel()
        {
            _customer = Customer.CreateCustomerWithFields("Oponeo", "321321321", "Warszawa ul. Testowa 1");
        }

        public override string ToString()
        {
            return $"CustomerName:{Name}, TaxIdentifier:{TaxIdentifier}, Address: { Address}";
        }
    }
```
10. Add method using async changing value in view model and call it in the constructor.

```cs
public MainWindowViewModel()
{
    _customer = Customer.CreateCustomerWithFields("Oponeo", "321321321", "Warszawa ul. Testowa 1");
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
```

11. Inspect if a value in the customer name field will change. Call then ```onPropertyChanged()``` in setter. Run and check what will happen.

```cs
public string Name
{
    get { return _customer.Name; }
    set 
    { 
        _customer.Name = value;
        OnPropertyChanged();
    }
}
        
```
12. Add another extra field into ViewModel with FullCustomerData.

```cs
public string FullCustomerData
{
    get => $"CustomerName:{Name}, TaxIdentifier:{TaxIdentifier}, Address: {Address}";
}
```

13. Add an extra label in XAML file to display this full data, set proper binding and check if it displays value after start (add an extra row in your Grid if needed).
```
<Label Grid.Row="5" Grid.ColumnSpan="2" FontSize="12" FontWeight="Bold" HorizontalAlignment="Center" Content="{Binding FullCustomerData}"/>
```

14. Call ```OnPropertyChanged()``` for ```FullCustomerData``` in setter while setting value for ```Name```. Inspect what will happen.

```cs
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
```
