## Task 2 

### Creating simple navigation in the application

1. Firstly create Customers folder for both Views and ViewModels folder in `Oponeo.WMS.WPFClient` project. Create in these folders `AddCustomerView.xaml` (in Views) and 
`AddCustomerViewModel.cs` (in ViewModels). **Important!!** Create AddCustomerView.xaml as a user control. 

```
Oponeo.WMS.WPFClient
│   ....
│
└───ViewModels
│   │   └───Customers
│   |   AddCustomerViewModel.cs
│   │   
│   MainWindowViewModel.cs      
│   
└───Views
│   │   └───Customers
│   |    AddCustomerView.xaml
│   │   
│   MainWindowView.xaml    
```

2. Move the content between `<Grid>` and `</Grid>` markups into the new created user control. Do the same with the corresponding view model class. Resolve all using issues, change 
the constructor's name, add inheritance from `BaseViewModel`, resolve an issue with design time view model which is connected with `MainWindowViewModel`.

3. Run and inspect if application starts correctly. If not check errors and try to resolve them.

4. In `Customers` folders create `ListCustomerView.xaml` as a user control and a corresponding viewmodel, name it as `ListCustomerViewModel.cs`. Add inheritance to `BaseViewModel`.

5. Create data templates for these two created views and viewmodels in `MainWindow.xaml`. 

```
 </Window.DataContext>
    <Window.Resources>
        <DataTemplate DataType="{x:Type vm_customers:AddCustomerViewModel}">
            <v_customers:AddCustomerView/>
        </DataTemplate>
        <DataTemplate DataType="{x:Type vm_customers:ListCustomerViewModel}">
            <v_customers:ListCustomerView/>
        </DataTemplate>
    </Window.Resources>
```

Remember about adding proper namespaces.

```
...
xmlns:vm_customers="clr-namespace:Oponeo.WMS.WPFClient.ViewModels.Customers"
xmlns:v_customers="clr-namespace:Oponeo.WMS.WPFClient.Views.Customers"
...
```

6. Add property which points to current view model selected by a user. So put this into `MainWindowViewModel` class.

```cs
  private BaseViewModel _currentViewModel;

  public BaseViewModel CurrentViewModel
  {
      get { return _currentViewModel; }
      set { _currentViewModel = value; OnPropertyChanged(); }
  }
```

7. Create a layout prepared for navigation and dynamically display of content.

```
 <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="150"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
   
        <ContentControl Grid.Column="1" Content="{Binding CurrentViewModel}"/>
</Grid>
```

8. Add two simple buttons and place them into `StackPanel` in MainWindow.xaml. As a result there should be a simple navigation menu on a view side as below. Create bindings for Commands.

```
 <StackPanel Grid.Column="0">
    <Button Content="Add customer" Command="{Binding AddCustomerCommand}"/>
    <Button Content="List customers" Command="{Binding ListCustomerCommand}"/>
 </StackPanel>      
```

9. Add implementation of command which might be similar to below.

```cs
private void InitializeCommand()
{
   AddCustomerCommand = new RelayCommand(o =>
   {
      SetViewModelAsCurrent(typeof(AddCustomerViewModel));
   });
   ListCustomerCommand = new RelayCommand(o =>
   {
      SetViewModelAsCurrent(typeof(ListCustomerViewModel));
   });
}

private void SetViewModelAsCurrent(Type type)
{
   if (type.IsSubclassOf(typeof(BaseViewModel)))
   {
      CurrentViewModel = (BaseViewModel)Activator.CreateInstance(type);
   }  
}
```

10. Run and notice if when you the user view switches between two view and viewmodels. Put necessary breakpoints in both constructors to notice if it works correctly.

11. As you can see `AddCustomerView` and the corresponding view model is always renew when tyou click `Add customer` button. We want to create a view model and a view only when it is necessary and keep all references in a collection. Let's do that.

12. Create a collection in `MainWindowViewModel` class. it might be a list.

```cs
private List<BaseViewModel> _viewModels = new List<BaseViewModel>();
```

13. Replace `SetViewModelAsCurrent()` method to place logic of creating viewmodel when a collection does not have it. It should be like this.

```cs
private void SetViewModelAsCurrent(Type type)
{
   if (type.IsSubclassOf(typeof(BaseViewModel)))
   {
      if (_viewModels.Any(x => x.GetType() == type))
      {
         CurrentViewModel = (BaseViewModel)_viewModels.Where(x => x.GetType() == type).FirstOrDefault();
      }
      else
      {
         CurrentViewModel = (BaseViewModel)Activator.CreateInstance(type);
          _viewModels.Add(CurrentViewModel);
      }
   }
}
```

14. Inspect if an instance is created only once if a user clicks a button.
