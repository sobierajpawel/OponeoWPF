## Task 3

### Application localization

1. Install ResXManager extension for Visual Studio.

https://marketplace.visualstudio.com/items?itemName=TomEnglert.ResXManager

1. In `Oponeo.WMS.WPFClient` in `Properties` find file `Resources.resx`.

2. Open it and add 3 key-values pairs.

Key                Values
Add_customer	     Add customer	
Add_delivery_note	 Add delivery note	
Customers	         Customers	

3. Create new file Resources.pl-PL.resx file. Remember about using Resource template from VS.

4. Add key-value pairs. Important! Keys must be excatly the same like in previous file.

Key                Values
Add_customer	     Dodaj kontrahenta	
Add_delivery_note	 Dodaj WZ	
Customers	         Kontrahenci	

5. In `MainWindow` view add using for `Properties`.

```
 xmlns:p = "clr-namespace:Oponeo.WMS.WPFClient.Properties"
```

6. Change access modifiers in resource files into `public`.

7. Replace menu textboxes in navigation buttons.

```
        <StackPanel Grid.Column="0">
            <Button Command="{Binding AddCustomerCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Fill="Black" Stretch="Uniform" Width="40" Height="40"
                         Data="M15,14C12.33,14 7,15.33 7,18V20H23V18C23,15.33 17.67,14 15,14M6,10V7H4V10H1V12H4V15H6V12H9V10M15,12A4,4 0 0,0 19,8A4,4 0 0,0 15,4A4,4 0 0,0 11,8A4,4 0 0,0 15,12Z"/>
                        <TextBlock Text="{x:Static p:Resources.Add_customer}"  FontSize="14"/>
                    </StackPanel>
                </Button.Content>
            </Button>
            <Button Command="{Binding ListCustomerCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Fill="Black" Stretch="Uniform" Width="40" Height="40"
                         Data="M16 17V19H2V17S2 13 9 13 16 17 16 17M12.5 7.5A3.5 3.5 0 1 0 9 11A3.5 3.5 0 0 0 12.5 7.5M15.94 13A5.32 5.32 0 0 1 18 17V19H22V17S22 13.37 15.94 13M15 4A3.39 3.39 0 0 0 13.07 4.59A5 5 0 0 1 13.07 10.41A3.39 3.39 0 0 0 15 11A3.5 3.5 0 0 0 15 4Z"/>
                        <TextBlock Text="{x:Static p:Resources.Customers}" FontSize="14"/>
                    </StackPanel>
                </Button.Content>
            </Button>
            <Button Command="{Binding AddDeliveryNoteCommand}">
                <Button.Content>
                    <StackPanel>
                        <Path Fill="Black" Stretch="Uniform" Width="40" Height="40"
                         Data="M3 5V19H20V5H3M7 7V9H5V7H7M5 13V11H7V13H5M5 15H7V17H5V15M18 17H9V15H18V17M18 13H9V11H18V13M18 9H9V7H18V9Z"/>
                        <TextBlock Text="{x:Static p:Resources.Add_delivery_note}" FontSize="14"/>
                    </StackPanel>
                </Button.Content>
            </Button>
        </StackPanel>
```

8. Inspect if default language - English is set and the default resource file.

9. In `App.xaml.cs` add constructor and check if language is changed as well in application.

```cs
    public partial class App : Application
    {
        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");
        }
    }
```

10. Inspect Tools->ResXManager and check how it works.
