## Task 3

### Creating, using controls in WPF

1. Change buttons to complex buttons in menu in the application. You can your own controls or layout inside buttons. As below where `StackPanel` is used.

```
        <StackPanel Grid.Column="0">
            <Button Background="White" Command="{Binding AddCustomerCommand}">
                <Button.Content>
                    <StackPanel>
                      <Path Width="40" Height="40" Margin="1"
                      Data="M15,14C12.33,14 7,15.33 7,18V20H23V18C23,15.33 17.67,14 15,14M6,10V7H4V10H1V12H4V15H6V12H9V10M15,12A4,4 0 0,0 19,8A4,4 0 0,0 15,4A4,4 0 0,0 11,8A4,4 0 0,0 15,12Z"
                      Fill="#000000"
                      Stretch="Uniform" />
                      <TextBlock Margin="0 5 0 0" Text="Add customer"></TextBlock>
                    </StackPanel>
                </Button.Content>
            </Button>
            <Button Background="White" Command="{Binding ListCustomerCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Width="40" Height="40" Margin="1"
                        Data="M16 17V19H2V17S2 13 9 13 16 17 16 17M12.5 7.5A3.5 3.5 0 1 0 9 11A3.5 3.5 0 0 0 12.5 7.5M15.94 13A5.32 5.32 0 0 1 18 17V19H22V17S22 13.37 15.94 13M15 4A3.39 3.39 0 0 0 13.07 4.59A5 5 0 0 1 13.07 10.41A3.39 3.39 0 0 0 15 11A3.5 3.5 0 0 0 15 4Z"
                        Fill="#000000"
                        Stretch="Uniform" />
                        <TextBlock Margin="0 5 0 0" Text="List customers"></TextBlock>
                    </StackPanel>
                </Button.Content>
            </Button>
        </StackPanel>
```

2. Add `Margin` property to `ContentControl` in `MainWindowView` to make the layout prettier.

```
<ContentControl Margin="20" Grid.Column="1" Content="{Binding CurrentViewModel}"/>
 ```
 
 3. Add layout for `ListCustomerView` you can use `UniformGrid` and `DockPanel`. Try different controls for displaying items (controls which inherit `ListBox`, `DataGrid`,`ItemsSource`)

```
 <UniformGrid Columns="1" Rows="2">
        <DockPanel Grid.Row="0">
            <ItemsControl ItemsSource="{Binding Customers}" DockPanel.Dock="Left"/>
            <ListBox DisplayMemberPath="Name" ItemsSource="{Binding Customers}" DockPanel.Dock="Right"/>
        </DockPanel>
        <DataGrid Grid.Row="1" CanUserAddRows="False"
                  AlternatingRowBackground="LightBlue" AlternationCount="2" AutoGenerateColumns="False"                  
                  ItemsSource="{Binding Customers}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="TaxIdentifier" Binding="{Binding TaxIdentifier}"/>
                <DataGridTextColumn Header="Address" Binding="{Binding Address}"/>
            </DataGrid.Columns>
        </DataGrid>

    </UniformGrid>
```

4. Bind `List<Customer>` to display customers on the view. Add necessary code to the view model.

```cs
  public class ListCustomerViewModel : BaseViewModel
  {
        private List<Customer> _customers = new List<Customer>();

        public List<Customer> Customers
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
            this.Customers.Add(Customer.CreateFullDataCustomer("Jan", "2321321", "Warszawa"));
           
        }
   }
```

5. Add async `Task` to add asynchronusly additional `Customers` and inspect if a record will be inserted in controls. As you can see it does not work properly, when you switch 
between views then the collection is refreshed.

```cs
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
                this.Customers.Add(Customer.CreateFullDataCustomer("Adam", "2321321", "Warszawa"));

            });
    ...
```

6. Change `List<Customer>` into `ObservableCollection<Customer>` and inspect if the problem still exists.

```cs
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
```

7. Try to update collection in the main thread. Use `BeginInvoke` to add new customer. Check if now the problem is resolved.

```cs
 private void AddCustomer()
        {
            Task.Run(async () =>
            {
                await Task.Delay(2000);

            }).ContinueWith(t =>
            {
                App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                {
                    this.Customers.Add(Customer.CreateFullDataCustomer("Adam", "2321321", "Bydgoszcz"));
                });
            });
        }
```

8. Add margins in `AddCustomerView` to controls in labels and textboxes.

```
   <TextBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="1" Text="{Binding Name}"></TextBox>
   <TextBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="2" Text="{Binding TaxIdentifier}"></TextBox>
   <TextBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="3" Text="{Binding Address}"></TextBox>
```

9. Add extra properties in the `Customer` class.

```cs
 public bool IsActive { get; set; }
 public DateTime ActiveFrom { get; set; }
```

10. Add additional properties and new controls in `AddCustomerView`. Remember about margins.

```cs public DateTime ActiveFrom
        {
            get { return _customer.ActiveFrom; }
            set
            {
                _customer.ActiveFrom = value;
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
```

```
<CheckBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="4" IsChecked="{Binding IsActive}"></CheckBox>
<DatePicker Margin="0 10 0 0" Grid.Column="1" Grid.Row="5" SelectedDate="{Binding ActiveFrom}"></DatePicker>
```

11. Inspect how the application works. Add some initial values to new properties in the viewmodel's constructor.

```cs
public AddCustomerViewModel()
{
    _customer = Customer.CreateEmptyCustomer();
    IsActive = true;
    ActiveFrom = DateTime.Now;

    InitializeCommand();
}
```

12. Modify `AddCustomerView` form by adding extra "Set Default" button. Use next `StackPanel` 

```
   <StackPanel Grid.Row="6" Grid.ColumnSpan="2" Margin="40,30,40,0">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Button Width="150" Content="Save" Command="{Binding SaveCommand}" CommandParameter="Mouse"></Button>
                <Button Width="150" Content="Set default" Command="{Binding SetDefaultCommand}"></Button>
            </StackPanel>
          
            <Label Margin="0,20,0,0" Content="{Binding Status}" HorizontalAlignment="Center"/>
        </StackPanel>
```

13. Add command for setting default properties.

```cs
   SetDefaultCommand = new RelayCommand(o =>
            {
                IsActive = true;
                ActiveFrom = DateTime.Now;
                Name = String.Empty;
                TaxIdentifier = String.Empty;
                Address = String.Empty;
            });
```

14. Change `UpdateSourceTrigger` to `PropertyChanged` and inspect how the save button enabling after losing focus or property changed.

```
<TextBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="1" Text="{Binding Name, UpdateSourceTrigger=PropertyChanged}"></TextBox>
<TextBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="2" Text="{Binding TaxIdentifier, UpdateSourceTrigger=PropertyChanged}"></TextBox>
 ```
 
 15. Add default values in the `AddCustomerViewModel` to the constuctor. Change `Binding Mode` in the textbox assigned with `Address`.

```cs
   public AddCustomerViewModel()
   {
       _customer = Customer.CreateEmptyCustomer();
       IsActive = true;
       ActiveFrom = DateTime.Now;
       Name = "Oponeo";
       TaxIdentifier = "32321321";
       Address = "ul. Testowa, Warszawa";

       InitializeCommand();
   }
 ```
 
 ```
 <TextBox Margin="0 10 0 0" Grid.Column="1" Grid.Row="3" Text="{Binding Path=Address, Mode=OneWayToSource}"></TextBox>
 ```
 
 16. Add extra button and use `RelativeSource` to the parent's `DataContext` to switch to `ListCustomerView`.

```
 <Button Width="150" Content="Lista kontrahentów" Command="{Binding RelativeSource={RelativeSource FindAncestor, 
         AncestorType={x:Type Window}}, Path=DataContext.ListCustomerCommand}">
</Button>
 ```               
