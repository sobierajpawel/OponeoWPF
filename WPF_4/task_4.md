## Task 4

### Refactorization

1. Change `BaseViewModel.cs` implementation with added `SetField` method.

```cs
 public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName]string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) 
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
```

2. Use `SetField` method in `AddCustomerViewModel` instead of `OnPropertyChanged()`

```cs
  private string _status;

        public string Status
        {
            get { return _status; }
            set { SetField(ref _status, value); }
        }
```

3. Add `ActionCommand` in `Commands` folder.

```cs
 public class ActionCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged;

        public ActionCommand(Action<object> execute, Func<object, bool> canExecute = null)
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

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
```

4. Add AlwaysEnabledCommand in `Commands`

```cs
 class AlwaysEnabledCommand : ICommand
    {
        private readonly Action<object> _execute;


        public AlwaysEnabledCommand(Action<object> execute)
        {
            this._execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
```

5. In `AddCustomerViewModel` try to use both commands instead of `RelayCommand`

```cs
    private void InitializeCommands()
        {
            SetDefaultCommand = new AlwaysEnabledCommand(o =>
            {
                SetDefaultValues();
            });

            SaveCommand = new ActionCommand(o =>
            {
                if (o is string parameter)
                {
                    Task.Run(() => SaveData(parameter));
                }
            },x => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(TaxIdentifier) && !string.IsNullOrWhiteSpace(Address));
        }

        private void RefreshSaveCommandStatus()
        {
            SaveCommand?.RaiseCanExecuteChanged();
        }
```

6. Remember accroding to `CanExecute` policy we need to fire `RefreshSaveCommandStatus` in all corresponding sets' methods.

```cs
  public string Name
        {
            get { return _customer.Name; }
            set
            {
                _customer.Name = value;
                OnPropertyChanged();
                RefreshSaveCommandStatus();
            }
        }

        public string TaxIdentifier
        {
            get { return _customer.TaxIdentifier; }
            set
            {
                _customer.TaxIdentifier = value;
                OnPropertyChanged();
                RefreshSaveCommandStatus();
            }
        }

        public string Address
        {
            get { return _customer.Address; }
            set
            {
                _customer.Address = value;
                OnPropertyChanged();
                RefreshSaveCommandStatus();
            }
        }
```

7. Find other important elements in code to improve!
