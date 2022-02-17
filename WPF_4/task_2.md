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
