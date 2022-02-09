## Task 1

### Propery triggers, event triggers and datatriggers

1. In `Oponeo.WMS.Model` project add a new class and name it as `DeliveryNote`.

2. Create properties for keeping `DocumentNumber`, `Customer`, `DocumentDate` and `Description`

```cs
  public class DeliveryNote
  {
        public Customer Customer { get; set; }

        public DateTime DocumentDate { get; set; }

        public string Description { get; set; }

        public string DocumentNumber { get; set; }
  }
```

3. In `Oponeo.WMS.WPFClient` project create folders `DeliveryNotes` in `Views` as well as `ViewModels`.

4. Create simple view (remember it must be a user-control view type) for adding delivery node. Call it as `AddDeliveryNoteView`.

5. Prepare simple Grid layout for the new created view.

```
 <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="2*"/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="auto"/>
        </Grid.RowDefinitions>

        <Label Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2" HorizontalAlignment="Center" FontSize="18" FontWeight="Bold" Content="Delivery note form"/>
        
        <Label Content="Document number" Grid.Row="1"/>
        <Label Content="Document date" Grid.Row="2"/>
        <Label Content="Document description" Grid.Row="3"/>
        <Label Content="Selected customer" Grid.Row="4"/>
    </Grid>
 ```
 
 6. Create corresponding viewmodel, name it as `AddDeliveryNoteViewModel`. Add simple properties. Remember about inheritance from `BaseViewModel` and using `OnPropertyChanged()` in setters.
 
 ```cs
 public class AddDeliveryNoteViewModel : BaseViewModel
    {
        private DeliveryNote _deliveryNote = new DeliveryNote();

        public string Description
        {
            get { return _deliveryNote.Description; }
            set
            {
                _deliveryNote.Description = value;
                OnPropertyChanged();
            }
        }

        public Customer SelectedCustomer
        {
            get { return _deliveryNote.Customer; }
            set
            {
                _deliveryNote.Customer = value;
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

        public string DocumentNumber
        {
            get { return _deliveryNote.DocumentNumber; }
            set
            {
                _deliveryNote.DocumentNumber = value;
                OnPropertyChanged();
            }
        }

        public AddDeliveryNoteViewModel()
        {
        }
    }
 ```
 
 7. Add in `MainWindow.xaml` data templates for `AddDeliveryNoteView`. Remember about correct namespaces.
 
 ```
<DataTemplate DataType="{x:Type vm_deliveryNotes:AddDeliveryNoteViewModel}">
     <v_deliveryNotes:AddDeliveryNoteView/>
 </DataTemplate>
 ```
 
 ```
 xmlns:vm_deliveryNotes="clr-namespace:Oponeo.WMS.WPFClient.ViewModels.DeliveryNotes"
 xmlns:v_deliveryNotes="clr-namespace:Oponeo.WMS.WPFClient.Views.DeliveryNotes"
```

8. Add extra button to menu in `MainWindow`.

```
 <Button Command="{Binding AddDeliveryNoteCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Fill="Black" Stretch="Uniform" Width="40" Height="40"
                         Data="M6,2A2,2 0 0,0 4,4V20A2,2 0 0,0 6,22H18A2,2 0 0,0 20,20V8L14,2H6M6,4H13V9H18V20H6V4M8,12V14H16V12H8M8,16V18H13V16H8Z"/>
                        <TextBlock Text="Delivery notes" FontSize="14"/>
                    </StackPanel>
                </Button.Content>
    </Button>
 ```
 
 9. Add `AddDeliveryNoteCommand` to `MainWindowViewModel` to handle adding delivery.
 
 ```cs
     AddDeliveryNoteCommand = new RelayCommand(o =>
     {
        SetViewModel(typeof(AddDeliveryNoteViewModel));
     });
 ```

10. Add controls to new form and bind them with corresponing properties.

```
        <TextBox  Text="{Binding DocumentNumber}" Grid.Row="1" Grid.Column="1"/>
        <DatePicker SelectedDate="{Binding DocumentDate}" Grid.Row="2" Grid.Column="1"/>
        <TextBox Text="{Binding Description}" Grid.Row="3" Grid.Column="1"/>
        <ComboBox SelectedItem="{Binding SelectedCustomer}" DisplayMemberPath="Name" ItemsSource="{Binding Customers}" Grid.Row="4" Grid.Column="1"/>
```

11. Add collection to `ComboBox`'s item source. And in `ctor` add at least two record. Remove and add `DisplayMemberPath` in `ComboBox` control. Inspect what values are shown.

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

        public AddDeliveryNoteViewModel()
        {
            this.Customers.Add(Customer.CreateFullDataCustomer("Oponeo", "125789214", "ul.Testowa 1, Bydgoszcz"));
            this.Customers.Add(Customer.CreateFullDataCustomer("New customer", "DE56752121", "ul.Testowa 1, Berlin"));
        }
```

12. Add `StackPanel` and put buttons into it like below.

```
<StackPanel Grid.Row="6" Grid.ColumnSpan="2" Margin="40,30,40,0">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Button Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
                <Button Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button>
            </StackPanel>
</StackPanel>
```

13. In `Styles.xaml` add new style for textboxes which will be used in `AddDeliveryNoteView`. Use `Triggers` to change button color when mouse is above button.

```
 <Style x:Key="DeliveryTextBox" TargetType="{x:Type TextBox}">
        <Style.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background" Value="LightBlue"/>
            </Trigger>
        </Style.Triggers>
    </Style>
 ```
 
 14. Add style file to `ResourceDictionary` in `AddDeliveryNoteView` as below.

```
    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
```

15. Run application and check if your property trigger works correctly.

16. Apply datatrigger to `DatePicker`. 

```
  <DatePicker SelectedDate="{Binding DocumentDate}" Grid.Row="2" Grid.Column="1">
            <DatePicker.Style>
                <Style TargetType="{x:Type DatePicker}">
                    <Setter Property="IsEnabled" Value="False"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedCustomer.IsActive}" Value="True">
                            <Setter Property="IsEnabled" Value="True"></Setter>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </DatePicker.Style>
        </DatePicker>
```

17. Add an overloaded method for creating `Customer` which allows to put `isActive` parameter.

```cs
     public static Customer CreateFullDataCustomer(string name, string taxIdentifier, string address, bool isActive)
        {
            return new Customer
            {
                Name = name,
                TaxIdentifier = taxIdentifier,
                Address = address,
                IsActive = isActive
            };
        }
```

18. Modify collection in `AddDeliveryNoteViewModel`. Run application and check if `DatePicker` is enabled depending on choosen customer.

```cs
 public AddDeliveryNoteViewModel()
        {
            this.Customers.Add(Customer.CreateFullDataCustomer("Oponeo", "125789214", "ul.Testowa 1, Bydgoszcz", true));
            this.Customers.Add(Customer.CreateFullDataCustomer("New customer", "DE56752121", "ul.Testowa 1, Berlin"));
        }
```

19. Add `EventTrigger` with `ColorAnimation`. Inspect how it works when you got and lost focus.

```
<TextBox Text="{Binding DocumentNumber}" Grid.Row="1" Grid.Column="1">
            <TextBox.Style>
                <Style TargetType="{x:Type TextBox}">
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="GotFocus">
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation Duration="0:0:0.55" Storyboard.TargetProperty="Background.Color" To="LightCoral"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                        <EventTrigger RoutedEvent="LostFocus">
                            <BeginStoryboard>
                                <Storyboard>
                                    <ColorAnimation Duration="0:0:0.55" Storyboard.TargetProperty="Background.Color" To="White"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </TextBox.Style>
        </TextBox>
```

20. Change the style of textboxes in `Styles.xaml` for `DeliveryTextBox` and use `MultiTrigger` instead of a classic trigger. Inspect how it looks like.

```
 <Style x:Key="DeliveryTextBox" TargetType="{x:Type TextBox}">
        <Style.Triggers>
            <MultiTrigger>
                <MultiTrigger.Conditions>
                    <Condition Property="IsMouseOver" Value="True"></Condition>
                    <Condition Property="IsKeyboardFocused" Value="True"></Condition>
                </MultiTrigger.Conditions>
                <MultiTrigger.Setters>
                    <Setter Property="Background" Value="LightBlue"/>
                </MultiTrigger.Setters>
            </MultiTrigger>
        </Style.Triggers>
    </Style>
```

21. Replace `DataTrigger` with `MultiDataTrigger` and inspect application.

```
<DatePicker SelectedDate="{Binding DocumentDate}" Grid.Row="2" Grid.Column="1">
            <DatePicker.Style>
                <Style TargetType="{x:Type DatePicker}">
                    <Setter Property="IsEnabled" Value="False"/>
                    <Style.Triggers>
                        <MultiDataTrigger>
                            <MultiDataTrigger.Conditions>
                                <Condition Binding="{Binding SelectedCustomer.IsActive}" Value="True"></Condition>
                                <Condition Binding="{Binding DocumentNumber}" Value="10"></Condition>
                            </MultiDataTrigger.Conditions>
                            <MultiDataTrigger.Setters>
                            <Setter Property="IsEnabled" Value="True"></Setter>
                        </MultiDataTrigger.Setters>
                        </MultiDataTrigger>
                    </Style.Triggers>
                </Style>
            </DatePicker.Style>
        </DatePicker>
```
