## Task 2

### Converters

1. Add `BooleanToVisibilityConverter` in `AddDeliveryNoteView`.

```
 <UserControl.Resources>
        <ResourceDictionary>
            <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
```

2. Bind StackPanel's visibility to the `IsActive` property for the selected `Customer`. Use `BooleanToVisibilityConverter` to bind it correctly.

```
<StackPanel Visibility="{Binding SelectedCustomer.IsActive, Converter={StaticResource BooleanToVisibilityConverter}}" Grid.Row="6" Grid.ColumnSpan="2" Margin="40,30,40,0">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Button Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
                <Button Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button>
            </StackPanel>
</StackPanel>
```

3. Inspect and check how it works. Propably you'll notice that from the very beginning the `StackPanel` is visible although selected customer is not chosen. It happens because of `null` value in `SelectedCustomer`.
We may fix that by adding extra property which handle with `null` like this.

```cs
  public Customer SelectedCustomer
        {
            get { return _deliveryNote.Customer; }
            set
            {
                _deliveryNote.Customer = value;
                if (_deliveryNote.Customer != null)
                {
                    IsActiveCustomer = _deliveryNote.Customer.IsActive;
                }
                OnPropertyChanged();
            }
        }

        private bool _isActiveCustomer;
        public bool IsActiveCustomer
        {
            get
            {
                return _isActiveCustomer;
            }
            set
            {
                _isActiveCustomer = value;
                OnPropertyChanged();
            }
        }
```

```
    <StackPanel Visibility="{Binding IsActiveCustomer, Converter={StaticResource BooleanToVisibilityConverter}}" Grid.Row="6" Grid.ColumnSpan="2" Margin="40,30,40,0">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Button Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
                <Button Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button>
            </StackPanel>
        </StackPanel>
```

4. Create `Converters` folder in `Oponeo.WMS.WPFClient` project.

5. Add custom converter to make inversion of `BooleanToVisibility`. Name it as `InvertBooleanToVisibilityConverter`

```cs
  public sealed class InvertBooleanToVisibilityConverter : IValueConverter
    {
        public InvertBooleanToVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
                return booleanValue ? Visibility.Collapsed : Visibility.Visible;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Equals(value, Visibility.Collapsed))
                return true;
            return Visibility.Visible; 
        }
    }
```

6. Add it to resource in `AddDeliveryNote.xaml` and replace in the visibility binding in the `StackPanel`

```
xmlns:converters="clr-namespace:Oponeo.WMS.WPFClient.Converters"
```

```
 <UserControl.Resources>
        <ResourceDictionary>
            <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
            <converters:InvertBooleanToVisibilityConverter x:Key="InvertBooleanToVisibilityConverter"/>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
```
```
 <StackPanel Visibility="{Binding SelectedCustomer.IsActive, Converter={StaticResource InvertBooleanToVisibilityConverter}}" Grid.Row="6" Grid.ColumnSpan="2" Margin="40,30,40,0">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Button Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
                <Button Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button>
            </StackPanel>
</StackPanel>
```

7. Add another converter to check if the `DocumentDate` is in the past and assign it to enabling or disabling the textbox for `DocumentNumber`. Rememver about the trigger in `DatePicker` which may block the whole control. Correct it.

```cs
 public class DateTimeSmallerThanNowConverter : IValueConverter
    {
        public DateTimeSmallerThanNowConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTimeValue)
                return dateTimeValue < DateTime.Now;

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
  
```

```
  <TextBox IsEnabled="{Binding DocumentDate, Converter={StaticResource DateTimeSmallerThanNowConverter}}" Text="{Binding DocumentNumber}"
```

```
    <UserControl.Resources>
        <ResourceDictionary>
            <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
            <converters:InvertBooleanToVisibilityConverter x:Key="InvertBooleanToVisibilityConverter"/>
            <converters:DateTimeSmallerThanNowConverter x:Key="DateTimeSmallerThanNowConverter"/>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml"/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
```

8. Set a default date in `ctor` in corresponding viewmodel.

```cs
public AddDeliveryNoteViewModel()
        {
            this.Customers.Add(Customer.CreateFullDataCustomer("Oponeo", "125789214", "ul.Testowa 1, Bydgoszcz", true));
            this.Customers.Add(Customer.CreateFullDataCustomer("New customer", "DE56752121", "ul.Testowa 1, Berlin"));

            DocumentDate = DateTime.Now.AddDays(1);
        }
 ```
 
 9. Add `Behaviors` folder in `Oponeo.WMS.WPFClient` project.
 
 10. Create a behavior for focus on loading form. 
 
 11. Create a class, name it as `LoadOnFocusBehavior`, add inheritance from `Behavior<FrameworkElement>`. Install the necessary nuget package - `Microsoft.Xaml.Behaviors`.
 
 12. Write a class for behavior.
 
 ```cs
 public class LoadOnFocusBehavior : Behavior<FrameworkElement>
    {
        public LoadOnFocusBehavior()
        {
        }

        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += OnLoaded;
        }       

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Focus();
        }
    }
 ```
 
 12. Attach the new created behavior with the textbox for `Description`
 
 ```
   xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
   xmlns:behaviors="clr-namespace:Oponeo.WMS.WPFClient.Behaviors"
 ```
 
 ```
   <TextBox Style="{StaticResource DeliveryTextBox}" Text="{Binding Description}" Grid.Row="3" Grid.Column="1">
            <i:Interaction.Behaviors>
                <behaviors:LoadOnFocusBehavior/>
            </i:Interaction.Behaviors>
     </TextBox>
 ```
 
 
 13. If you have an error which indicates on `Microsoft.Windows.Design.Extensibility` issue do a step below.
 
 ```
 Right-Click your project -> Add Reference... -> Assemblies -> Search Assemblies: "Extensibility" -> Select "'Microsoft.Windows.Design.Extensibility" -> OK
 ```
