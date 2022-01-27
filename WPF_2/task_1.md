## Task 1

### Events, commands and interaction triggers

1. Open the project from WPF_1 application. If you write your own project and it works use it. 

2. Add `<Button>` and `<Label>` controls into `<StackPanel>`. You can set `Margin` in `StackPanel` to place elements correctly.

```
<StackPanel Grid.Row="4" Grid.ColumnSpan="2" Margin="40,30,40,0">
    <Button Click="Button_Click"  Content="Save"></Button>
    <Label Margin="0,20,0,0" Grid.Row="5" Grid.Column="0" Grid.ColumnSpan="2" FontSize="14" FontWeight="Bold" Content="{Binding FullCustomerData}"></Label>
</StackPanel>
 ```
3. Add event on `StackPanel` to handle click like below.

```
ButtonBase.Click="StackPanel_Click"
```

4. Place two breakpoints in code behind in the `Button_Click()` method and in the `StackPanel_Click()` method. Notice how bubbling behaves. Put two message boxes in these methods to find out what information will be shown in `RoutedEventArgs`.

```cs
MessageBox.Show($"Sender {sender}, OriginalSource: {e.OriginalSource}");
```

5. Check how tunneling works in WPF. You can check it on some `Preview` event. Add `PreviewKeyDown` event in Grid and in a particular `TextBox`. Place message boxes and breakpoints in code-behind methods. Then press a key (or do other action depending on choosen event) in a particular TextBox.

```
<Grid Margin="20" PreviewKeyDown="Grid_PreviewKeyDown">
```

```
<TextBox PreviewKeyDown="TextBox_PreviewKeyDown"  Grid.Column="1" Grid.Row="1" Text="{Binding Name}"></TextBox>
```

```cs
MessageBox.Show($"Sender {sender}, OriginalSource: {e.OriginalSource}");
```

6. Create a simple version of `RelayCommand` implementation. You can create `Commands` folder in `Oponeo.WMS.WPFClient` project. The example implementation is shown below. You can try create generic implementation. 

```cs
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
```

7. In `MainWindowViewModel.cs` add field status which will inform a user if the save operation is in progress or not.

```cs
private string _status;

public string Status
{
    get { return _status; }
    set { _status = value; OnPropertyChanged(); }
}
```

8. In `MainWindowViewModel.cs` add implementation to handle command interaction and create a fake save operation which takes a while.

```cs
public ICommand SaveCommand { get; set;}

...

private void InitializeCommand()
{
    SaveCommand = new RelayCommand(o => { Save(); });
}

private void Save()
{
     Status = "Saving...";
     Thread.Sleep(5000);
     Status = "Customer has been saved";
}
```

8. Modify `XAML` code to  bind all new controls - `Command` property in `Button` to `SaveCommand` and `Content` in `Label` with
the new created property.

```
<StackPanel Grid.Row="4" Grid.ColumnSpan="2" Margin="40,30,40,0">
    <Button Content="Save" Command="{Binding SaveCommand}"></Button>
    <Label Margin="0,20,0,0" Content="{Binding Status}" HorizontalAlignment="Center"/>
</StackPanel>
```

9. As you can notice the whole operation is not asynchrous. We need to make it asynchronysly. So place `Task.Run()` in action method in SaveCommand. Inspect how the application behaves
after clicking in `Save` button.

```cs
private void InitializeCommand()
{
    SaveCommand = new RelayCommand(o => { Task.Run(() =>Save()); });
}
```

10. Add extra `CanExecute` attribute. It might consist of all properties or some of them.

```cs
private void InitializeCommand()
{
    SaveCommand = new RelayCommand(o => { Task.Run(() =>Save()); }, x => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(TaxIdentifier));
}
```

11. Add `KeyBinding` to `MainWindow.xaml` and check if pressing `K` on a keyboard invokes `Save()` method.

```
<KeyBinding Command="{Binding SaveCommand}" Modifiers="Ctrl" Key="S"/>
```

12. Add `CommandParameter` to keyboard/mouse command binding. 

```
  <KeyBinding Key="S" Modifiers="Ctrl" Command="{Binding SaveCommand}" CommandParameter="Keyboard"/>
```

```
 <Button Content="Save" Command="{Binding SaveCommand}" CommandParameter="Mouse"></Button>
 ```
 
 13. Modify RelayCommand declaration and use the parameter in `Save(parameter)` method.

```cs
private void InitializeCommand()
{
   SaveCommand = new RelayCommand(o => 
   {
      string source = string.Empty;

      if (o is string parameter)
      {
         source = parameter;
      }

      Task.Run(() =>Save(source)); 
      },  x => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(TaxIdentifier));
}

private void Save(string source)
{
     Status = $"Saving... from {source}";
     Thread.Sleep(5000);
     Status = "Customer has been saved";
}
```
14. In the `Oponeo.WMS.WPFClientPrism` project place namespace for `InvokeCommandActions`.

```
xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
```

15. Add trigger for using right click mouse on button `Save`. Do it in XAML like here below (you can move the general construction with `StackPanel` from the standard MVVM project):

```
    <StackPanel Grid.Row="4" Grid.ColumnSpan="2" Margin="40,30,40,0">
            <Button Click="Button_Click" Content="Save">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseRightButtonUp">
                        <prism:InvokeCommandAction Command="{Binding SaveCommand}" CommandParameter="MousePrism"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
            </Button>

            <Label Margin="0,20,0,0" Content="{Binding Status}" HorizontalAlignment="Center"/>
        </StackPanel>
```

16. Add necessary code in ViewModel (add `Status` as a property, bind `SaveCommand`).

```cs
private string _status;

public string Status
{
    get { return _status; }
    et => SetProperty(ref _status, value);
}

public ICommand SaveCommand { get; set; }
```

```cs
...
SaveCommand = new DelegateCommand<string>(source => Task.Run(() =>  Save(source)));
...
```

```cs
private void Save(string source)
{
    Status = $"Saving... from {source}";
    Thread.Sleep(5000);
    Status = "Customer has been saved";
}
```
