## Task 2

### Markup extensions, static and dynamic resource, dependency property.

1. In project `Oponeo.WMS.WPFClient` create a folder and name it as `Extensions`.

2. Create a new class as `MarkupExtension` for displaying current date and time.

```cs
  internal class GetCurrentDateAndTimeMarkupExtensions : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return DateTime.Now;
        }
    }
```

3. Add `RowDefinitions` into `MainWindow`'s Grid.

```
  <Grid.RowDefinitions>
            <RowDefinition Height="*"/>
            <RowDefinition Height="40"/>
   </Grid.RowDefinitions>
```

4. Use created `MarkupExtension` in the footer of the application

```
<Label Grid.Row="1"  Content="{extension:GetCurrentDateAndTimeMarkupExtensions}"/>
```

Remember about correct namespace.
```
xmlns:extension = "clr-namespace:Oponeo.WMS.WPFClient.Extensions"
```

5. Add another `MarkupExtension` in `Extensions` folder. This time use parameters in this class.

```cs
public class ValuesJoinMarkupExtension : MarkupExtension
    {
        public ValuesJoinMarkupExtension() { }
        public String FirstValue { get; set; }
        public String SecondValue { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return FirstValue + " " + SecondValue;
        }
    }
```

6. Add in `MainWindow.xaml` a footer with simple joined values like this.


7. Run and inspect how application works.

8. In the `Styles.xaml` file add `SolidBrushColor` definition.

```
<SolidColorBrush x:Key="RedColorBrush" Color="Red"></SolidColorBrush>
```

9. In `AddDeliveryNoteView.xaml` change background of buttons to this color brush. Use interchangeably `DynamicResource` and `StaticResource` like below.

```
           <StackPanel Orientation="Horizontal" HorizontalAlignment="Center">
                <Button Background="{StaticResource RedColorBrush}" Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
                <Button Background="{DynamicResource RedColorBrush}"  Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button>             
            </StackPanel>
```

10. Add extra button in the `StackPanel` to change resource dynamically in code behind.

```
  <Button Click="Button_Click"  Content="Change button styles"></Button>
```

11. Add proper code behind button handler's method.

```cs
private void Button_Click(object sender, RoutedEventArgs e)
{
    this.Resources["RedColorBrush"] = new SolidColorBrush(Colors.Green);
}
```

12. Inspect how application works.

13. In `Views/Customers` add new user control. Name it `CustomerAddressControl`. 

14. Add xaml code in new user control like here.

```
    <Grid>
        <Border BorderBrush="Black" BorderThickness="2" Margin="20">
            <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition></ColumnDefinition>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <Label Content="Zipcode" />
            <TextBlock Grid.Column="1" Margin="0,10,0,0" x:Name="ZipCode"></TextBlock>
            <Label Grid.Row="1" Content="Address" />
            <TextBlock Grid.Row="1" Grid.Column="1" Margin="0,10,0,0" x:Name="Address"></TextBlock>
        </Grid>
    </Border>
    </Grid>
```

15. Use this user control in `AddCustomerView`. Add row to grid if necessary.

```
<local:CustomerAddressControl Grid.Row="7" Grid.Column="1"></local:CustomerAddressControl>
```

16. Add two dependency properties in code behind of the new created user control.

```cs
        public static readonly DependencyProperty CustomerAddressProperty = DependencyProperty.Register(
           "CustomerAddress", typeof(string),
           typeof(CustomerAddressControl),
           new PropertyMetadata((obj, args) =>
           {
               if (args.NewValue == null)
                   return;

               CustomerAddressControl control = (CustomerAddressControl)obj;

               if (Regex.IsMatch(args.NewValue.ToString(), @"\d{2}-\d{3}"))
               {
                   var zipCode = Regex.Match(args.NewValue.ToString(), @"\d{2}-\d{3}").Value;
                   control.ZipCode.Text = zipCode;
                   control.Address.Text = args.NewValue.ToString().Replace(zipCode, String.Empty);
               }
           }));

        public static readonly DependencyProperty ZipCodeVisibleProperty = DependencyProperty.Register(
            "ZipCodeVisible", typeof(bool),
            typeof(CustomerAddressControl),
             new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public CustomerAddressControl()
        {
            InitializeComponent();
        }

        public string CustomerAddress
        {
            get => (string)GetValue(CustomerAddressProperty);
            set => SetValue(CustomerAddressProperty, value);
        }

        public bool ZipCodeVisible
        {
            get => (bool)GetValue(ZipCodeVisibleProperty);
            set => SetValue(ZipCodeVisibleProperty, value);
        }
```

17. Add bindings to local dependency properties in XAML file in `CustomerAddressControl`.

```
                <Label Content="Zipcode" Visibility="{Binding Path=ZipCodeVisible, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl},Converter={StaticResource BooleanToVisibilityConverter}}" />
                <TextBlock Grid.Column="1" Margin="0,10,0,0" x:Name="ZipCode" Visibility="{Binding Path=ZipCodeVisible, RelativeSource={RelativeSource FindAncestor, AncestorType=UserControl},Converter={StaticResource BooleanToVisibilityConverter}}"></TextBlock>
```

Remember about adding `BooleanToVisibilityConverter` in resources.

```
<BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
```

18. Add bindings to new dependency properties and check.

```
<local:CustomerAddressControl Grid.Row="7" Grid.Column="1" CustomerAddress="{Binding Address}" ZipCodeVisible="{Binding IsActive}" />
```
