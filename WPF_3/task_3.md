## Task 3

### WPF Data validation

1. Create a new style for displaying a validation error in `ToolTip`. Add it in the style file.

```
    <Style TargetType="{x:Type TextBox}" x:Key="ValidatedTextBox">
        <Setter Property="ToolTip" Value="{Binding RelativeSource={x:Static RelativeSource.Self}, Path=(Validation.Errors)[0].ErrorContent}"/>
    </Style>
```

2. Change the binding in the textbox for `DocumentNumber`

```
<TextBox IsEnabled="{Binding DocumentDate, Converter={StaticResource DateTimeSmallerThanNowConverter}}" 
        Text="{Binding DocumentNumber, ValidatesOnExceptions=True, UpdateSourceTrigger=PropertyChanged}" Grid.Row="1" Grid.Column="1">
```

3. Apply style from 1 to the textbox for `DocumentNumber`.

```
<TextBox IsEnabled="{Binding DocumentDate, Converter={StaticResource DateTimeSmallerThanNowConverter}}" 
                 Text="{Binding DocumentNumber, ValidatesOnExceptions=True, UpdateSourceTrigger=PropertyChanged}" Grid.Row="1" Grid.Column="1">
<TextBox.Style>
<Style BasedOn="{StaticResource ValidatedTextBox}" TargetType="{x:Type TextBox}">
```

4. Add validation by exception for `DocumentNumber` property.


```cs
 public string DocumentNumber
        {
            get { return _deliveryNote.DocumentNumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                    throw new ArgumentException("Document Number should be between 5 and 10");

                _deliveryNote.DocumentNumber = value;
                OnPropertyChanged();
            }
        }
```

5. Inspect if tooltip is shown correctly when you put characters in the textbox. Change `EventTrigger` for background colour to notice the border's behavior.

6. Substitute  `ValidatesOnExceptions` with `ValidatesOnDataError` property in the `Binding` section.

```
<TextBox IsEnabled="{Binding DocumentDate, Converter={StaticResource DateTimeSmallerThanNowConverter}}" 
        Text="{Binding DocumentNumber, ValidatesOnDataErrors=True, UpdateSourceTrigger=PropertyChanged}" Grid.Row="1" Grid.Column="1">
```

7. Implement `IDataErrorInfo` interface in the `AddDeliveryNoteViewModel` class. Remove exception throwing from setter in the `DocumentNumber` property.

8. Add simple implementation for validation the `DocumentNumber` like this one.

```cs
  public string Error => string.Empty;

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch(columnName)
                {
                    case "DocumentNumber":
                        {
                            if (string.IsNullOrWhiteSpace(DocumentNumber))
                                result = "DocumentNumber must be filled out";
                            else if (DocumentNumber.Length <= 10)
                                result = "DocumentNumber should have length greater than 10 characters";
                        }
                        break;

                }

                return result;
            }
        }
```

9. Replace style for the `Description` property to `ValidatedTextBox`.

```
  <TextBox Style="{StaticResource ValidatedTextBox}" Text="{Binding Description}" Grid.Row="3" Grid.Column="1">
            <i:Interaction.Behaviors>
                <behaviors:LoadOnFocusBehavior/>
            </i:Interaction.Behaviors>
        </TextBox>
```

10. Extend your code for validation with checking for the `Description` property.

```cs
  public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch(columnName)
                {
                    case "DocumentNumber":
                        {
                            if (string.IsNullOrWhiteSpace(DocumentNumber))
                                result = "DocumentNumber must be filled out";
                            else if (DocumentNumber.Length <= 10)
                                result = "DocumentNumber should have length greater than 10 characters";
                        }
                        break;
                    case "Description":
                        {
                            if (string.IsNullOrWhiteSpace(Description))
                                result = "Description must be filled out";
                        }
                        break;
                }

                return result;
            }
        }
```

11. Remember about adding proper properties for Text binding. Especially about `ValidatesOnDataErrors`. 

```
 Text="{Binding Description, ValidatesOnDataErrors=True, UpdateSourceTrigger=PropertyChanged}"
```

12. Run your application and inspect if the validation rules work correctly.

13. Remove `IDataErrorInfo` properties from `AddDeliveryNoteViewModel`. Remove the declaration of the interface.

14. Create folder `ValidationRules` in the `Oponeo.WMS.WPFClient` project.

15. Create class for document number validation process. Name it `DocumentNumberValidation`.

16. Add source code to validate your `DocumentNumber` like this one

```cs
  public class DocumentNumberValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string documentNumber)
            {
                if (string.IsNullOrWhiteSpace(documentNumber))
                    return new ValidationResult(false, "DocumentNumber must be filled out");
                else if (documentNumber.Length <= 10)
                    return new ValidationResult(false,"DocumentNumber should have length greater than 10 characters");

                return new ValidationResult(true, string.Empty);
            }

            return new ValidationResult(false, "Value is not a string");
        }
    }
```

17. Add a proper namespace for `AddDeliveryNoteView`.

```
 xmlns:validationRules="clr-namespace:Oponeo.WMS.WPFClient.ValidationRules"
```


18. Replace binding in the corresponding textbox like this.

```
  <TextBox IsEnabled="{Binding DocumentDate, Converter={StaticResource DateTimeSmallerThanNowConverter}}" 
                  Grid.Row="1" Grid.Column="1">
            <TextBox.Text>
                <Binding Path="DocumentNumber" UpdateSourceTrigger="PropertyChanged">
                    <Binding.ValidationRules>
                        <validationRules:DocumentNumberValidation />
                    </Binding.ValidationRules>
                </Binding>
            </TextBox.Text>
...
```
