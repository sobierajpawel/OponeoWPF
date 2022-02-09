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
