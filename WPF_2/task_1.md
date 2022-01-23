## Task 1

### Events, commands and interaction triggers





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

8. Modify `XAML` code and put button into `StackPanel` add `Label` and bind all new controls - `Command` property in `Button` to `SaveCommand` and `Content` in `Label` with
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
  <KeyBinding Key="S" Command="{Binding SaveCommand}"/>
```

12. Add `CommandParameter` to keyboard/mouse command binding. 

```
  <KeyBinding Key="S" Command="{Binding SaveCommand}" CommandParameter="Keyboard"/>
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
