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
