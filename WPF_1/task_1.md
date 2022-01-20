## Task 1

### Creating simple Customer form and say hello world after click a button! ###

1. Create a new solution in VS. Depending on .NET version you can create a .NET framework project (4.7.2 if possible). If you use VS 2022 you can download .NET 6 framework and create project WPF project in this framework.

2. Name project as **Oponeo.WMS.WPFClient**. The name of solution ought to be **Oponeo.WMS**

3. Create folders - **View** and **ViewModel** in **Oponeo.WMS.WPFClient** project.

4. Move MainWindow.xaml into View folder, change namespace in xaml file and .cs code behind file in MainWindow.

```
x:Class="Oponeo.WMS.WPFClient.Views.MainWindow"
```
```cs
namespace Oponeo.WMS.WPFClient.Views
```
5. Change StartupUri in App.xaml for new namespace.

```
 StartupUri="Views/MainWindow.xaml"
```

6. Inspect if the application is working. If not please check points from 3 to 5. 

7. Prepare layout for a simple form like these below. 

```
<Grid Margin="10">
        
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        
</Grid>
```

8. Try to create a simple form. Check what will happen if you put these two lines between ``</Grid.ColumnDefinitions>`` and ``</Grid>`` markup.

```
</Grid.ColumnDefinitions>
...
<Label Grid.Row="0">Customer Name</Label>
<Label Grid.Row="1">Tax identifier</Label>
...
</Grid>
```

9. Inspect what will happen if you put this line of code.

```
<Label Grid.Row="2">Address</Label>
```

10. As you can notice we need to modify the grid's layout. Then modify rows defintion part into this.

```
 <Grid.RowDefinitions>
    <RowDefinition Height="*" />
    <RowDefinition Height="*" />
    <RowDefinition Height="*" />
    <RowDefinition Height="*" />
</Grid.RowDefinitions>
```

11. It would be great to have a save button. Add button on 4th row.

```
 <Button Grid.Row="3">Save</Button>
```
 
 12. Inspect form and change row definitions into this one:
 
```
 <Grid.RowDefinitions>
    <RowDefinition Height="auto" />
    <RowDefinition Height="auto" />
    <RowDefinition Height="auto" />
    <RowDefinition Height="auto" />
</Grid.RowDefinitions>
```

13. Add textboxes into second column like these:

 ```
<TextBox x:Name="CustomerTextBox" Grid.Column="1" Grid.Row="0" ></TextBox>
<TextBox x:Name="TaxIdentifierTextBox" Grid.Column="1" Grid.Row="1"></TextBox>
<TextBox x:Name="AddressTextBox" Grid.Column="1" Grid.Row="2"></TextBox>
 ```
 
14. Modify the button's declaration to this and check what will happen

```
  <Button Grid.Row="3" Margin="20" Grid.ColumnSpan="2">Save</Button>
```

15. Great! Our form is ready, add event in button Click="Button_Click".

```
 <Button Click="Button_Click" Grid.Row="3" Margin="20" Grid.ColumnSpan="2">Save</Button>
```

16. Try to show Hello World in the method in code-behind. It should look like this:

```cs
   public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello world!");
        }
    }
```

17. You can create your own message, based on user data provided into textboxes. Try modify it on your own. Below find an example:

```cs
private void Button_Click(object sender, RoutedEventArgs e)
{
    var customerName = CustomerTextBox.Text;
    var taxIdentifier = TaxIdentifierTextBox.Text;

    var messageText = $"Hello {customerName}, your tax identifier: {taxIdentifier}";
    MessageBox.Show(messageText);
}
```
