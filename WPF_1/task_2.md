## Task 2 ##

### Simple binding to window itself, a class model

1. Modify the form from task 1 that it should have a title header above all controls on the first row. The declaration should look like this one:
(you can also highlight label by using different font size and weight depending on your own preferences).

```
 <Label Grid.Row="0" Grid.ColumnSpan="2" FontSize="16" FontWeight="Bold" HorizontalAlignment="Center">Customer form</Label>
```

2. Add one row to Grid.RowDeclarations and modify all rows' indexes. Run application and check if it looks fine (or/and check it on design form).

3. Inspect in code behind the DataContext property and assign property to ```this``` as a window itself.

```cs
public MainWindow()
{
    InitializeComponent();
    this.DataContext = this;
}
```

4. Modify the header's label into this. Notice the ```Content``` property and ```Binding``` keyword.

```
  <Label Grid.Row="0" Grid.ColumnSpan="2" FontSize="16" FontWeight="Bold" HorizontalAlignment="Center" Content="{Binding Title}"/>
```

5. Run application and check how it works.

6. Add at the end of the content of constructor 

```cs  
this.Title = "Customer form";
```

then add similar a piece of code but with changed name after ```MessageBox.Show``` in click button method.

```cs
this.Title = "Customer form - saved";
```

7. Run application and inspect.

8. Remove bindings for Label and get back to the header label as it was in the first point. As below.

```
 <Label Grid.Row="0" Grid.ColumnSpan="2" FontSize="16" FontWeight="Bold" HorizontalAlignment="Center">Customer form</Label>
```

9. In VS create a new project and put in into this solution as a class library. You can: right-click solution -> Add -> New Project->Class library. Name it as **Oponeo.WMS.Model**

10. Add class and name it as **Customer**.

11. Put three properties.

```cs
public class Customer
{
    public string Name { get; set; }
    public string TaxIdentifier { get; set; }
    public string Address { get; set; }
}
```

12. Create simple method to create new ```Customer``` and override ```ToString()``` method like this.

```cs
public static Customer CreateSimpleCustomer()
{
  return new Customer();
}

public override string ToString()
{
  return $"CustomerName:{Name}, TaxIdentifier:{TaxIdentifier}, Address: { Address}";
}
```

13. Change binding in textboxes to User properties.

```
<TextBox x:Name="CustomerTextBox" Grid.Column="1" Grid.Row="1" Text="{Binding Name}"></TextBox>
<TextBox x:Name="TaxIdentifierTextBox" Grid.Column="1" Grid.Row="2" Text="{Binding TaxIdentifier}"></TextBox>
<TextBox x:Name="AddressTextBox" Grid.Column="1" Grid.Row="3" Text="{Binding Address}"></TextBox>
```

14. Change code behind in MainWindow.xaml. Assign Customer into ```DataContext``` and after click a button change the message into ```ToString()``` of assigned customer.

```cs
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = Customer.CreateSimpleCustomer();
        
        this.Title = "Customer form";
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is Customer customer)
        {
            MessageBox.Show(customer.ToString());
        }             
    }
}
```
15. Inspect if application works fine and correct message is shown after clicking in Save button.
