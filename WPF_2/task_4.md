## Task 4

### Creating style for controls

1. Add style for buttons in `AddCustomerView` and inspect if the style is applied. Check it in the design-mode.

```
    <UserControl.Resources>
        <Style TargetType="{x:Type Button}">
            <Setter Property="FontSize" Value="16"/>
            <Setter Property="Background" Value="LightBlue"/>
            <Setter Property="BorderThickness" Value="2"/>
        </Style>
    </UserControl.Resources>
```

2. Add `x:Key`in this style and inspect if now it is applied in the application.

```
 x:Key="MainButton"
```

3. Add the `Style` property to a one of buttons and inspect if it visible.
 
```
 Style="{StaticResource MainButton}"
```

4. Remove `x:Key` property and properties in point 3. 

5. Add inheritance of styles with a new style. Use `BasedOn` property.

```
  <UserControl.Resources>
        <Style TargetType="{x:Type Button}">
            <Setter Property="FontSize" Value="16"/>
            <Setter Property="Background" Value="LightBlue"/>
            <Setter Property="BorderThickness" Value="2"/>
        </Style>
        <Style x:Key="NewFabulousButtonStyle" TargetType="{x:Type Button}" BasedOn="{StaticResource {x:Type Button}}">
            <Setter Property="Background" Value="LightCoral"/>
        </Style>
    </UserControl.Resources>
```

6. Assign new style to a one of available buttons by using the `Style` property.

```
Style="{StaticResource NewFabulousButtonStyle}"
```

7. Add Resources folder in the project `Oponeo.WMS.WPFClient`.

8. Add file `Styles.xaml` as `ResourceDictionary` type.

9. Move styles from `AddCustomerView` into `Styles.xaml`.

```
<ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
    <Style TargetType="{x:Type Button}">
        <Setter Property="FontSize" Value="16"/>
        <Setter Property="Background" Value="LightBlue"/>
        <Setter Property="BorderThickness" Value="2"/>
    </Style>
    <Style x:Key="NewFabulousButtonStyle" TargetType="{x:Type Button}" BasedOn="{StaticResource {x:Type Button}}">
        <Setter Property="Background" Value="LightCoral"/>
    </Style>
</ResourceDictionary>
```

10. Add your style's file into `Resources` to UserControl.

```
  <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml"></ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </UserControl.Resources>
```

11. Inspect if the styles are applied correctly, exactly the same like they were directly placed in `AddCustomerView`.

12. Create your own styles for available controls. Modify the layout of your application to customize it.
