## Task 1

### Control template and data template

1. Open `Styles.xaml` and remove these two lines in the style of the button.

```
    <Setter Property="Width" Value="120"/>
    <Setter Property="Height" Value="30"/>
```

2. Set new control template for buttons. Change the content of control according to your point of view. Below is an example.

```
<Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid>
                        <Ellipse x:Name = "ButtonEllipse" Height = "40" Width = "100" Stroke="Black" Fill="{TemplateBinding Background}">
                        </Ellipse>
                        <ContentPresenter Content = "{TemplateBinding Content}" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
```

3. Run application and inspect how buttons change in application or check it on the designer mode in VS.

4. Add a `<ControlTemplate.Trigger>` and change `Background` property when `IsMouseOver` is set as `True`. 

```
  <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid>
                        <Ellipse x:Name = "ButtonEllipse" Height = "40" Width = "100" Stroke="Black" Fill="{TemplateBinding Background}">
                        </Ellipse>
                        <ContentPresenter Content = "{TemplateBinding Content}" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="LightSeaGreen"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
```

5. Run application and inspect how buttons change in application or check it on the designer mode in VS.

6. Set an extra trigger to change buttons when they are disabled.

```
 <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid>
                        <Ellipse x:Name = "ButtonEllipse" Height = "40" Width = "100" Stroke="Black" Fill="{TemplateBinding Background}">
                        </Ellipse>
                        <ContentPresenter Content = "{TemplateBinding Content}" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="LightSeaGreen"/>
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="False">
                            <Setter Property="Background" Value="LightGray"/>
                            <Setter Property="Foreground" Value="Gray"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
```

7. Move this style into a new one and name it as `TemplateButton`. Remember about inheritance from base.

```
 <Style x:Key="TemplateButton" BasedOn="{StaticResource {x:Type Button}}" TargetType="{x:Type Button}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type Button}">
                    <Grid>
                        <Ellipse x:Name = "ButtonEllipse" Height = "40" Width = "100" Stroke="Black" Fill="{TemplateBinding Background}">
                        </Ellipse>
                        <ContentPresenter Content = "{TemplateBinding Content}" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Background" Value="LightSeaGreen"/>
                        </Trigger>
                          <Trigger Property="IsEnabled" Value="False">
                            <Setter Property="Background" Value="LightGray"/>
                            <Setter Property="Foreground" Value="Gray"/>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
```

8. Change the buttons' style in `AddCustomerView` to new `TemplatButton` style.

```
<Button Style="{StaticResource TemplateButton}" Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
<Button Style="{StaticResource TemplateButton}"  Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button>
<Button Style="{StaticResource SecondButton}" Margin="20,0,0,0" Command="{Binding RelativeSource={RelativeSource FindAncestor,
                    AncestorType={x:Type Window}}, Path=DataContext.ListCustomerCommand}" Content="List of customer"></Button>
```

9. Extract `ContentControl` into a separate in styles and declare it next to other styles.

```
  <ControlTemplate x:Key="TemplateButton" TargetType="{x:Type Button}">
        <Grid>
            <Ellipse x:Name = "ButtonEllipse" Height = "40" Width = "100" Stroke="Black" Fill="{TemplateBinding Background}">
            </Ellipse>
            <ContentPresenter Content = "{TemplateBinding Content}" HorizontalAlignment = "Center" VerticalAlignment = "Center" />
        </Grid>
        <ControlTemplate.Triggers>
            <Trigger Property="IsMouseOver" Value="True">
                <Setter Property="Background" Value="LightSeaGreen"/>
            </Trigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
```

10. Mix both `Template` and `Style` in `AddCustomerView` like below.

```
<Button Template="{StaticResource TemplateButton}" Command="{Binding SaveCommand}" CommandParameter="Mouse" Content="Save"></Button>
<Button Template="{StaticResource TemplateButton}"  Margin="20,0,0,0" Command="{Binding SetDefaultCommand}" Content="Set default"></Button> <Button Template="{StaticResource TemplateButton}" Style="{StaticResource SecondButton}" Margin="20,0,0,0" Command="{Binding RelativeSource={RelativeSource FindAncestor,
                    AncestorType={x:Type Window}}, Path=DataContext.ListCustomerCommand}" Content="List of customer"></Button>
```

11. In `ListCustomerView` remove `ItemSource` control as well as `DockPanel` container.

12. Set `ListBox` on full available `Width` in `UniformGrid` like below.

```
 <UniformGrid Columns="1" Rows="2">
        <ListBox Grid.Row="0" DisplayMemberPath="Name" ItemsSource="{Binding Customers}"  DockPanel.Dock="Right"/>
        <DataGrid Grid.Row="1" ItemsSource="{Binding Customers}" CanUserAddRows="False" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="Tax identifier" Binding="{Binding TaxIdentifier}"/>
                <DataGridCheckBoxColumn Header="Is active" Binding="{Binding IsActive}"/>
            </DataGrid.Columns>
        </DataGrid>
    </UniformGrid>
```

13. Add simple `DataTemplate` to the `ListBox` and create a simple layout for `Customer's` data.

```
 <ListBox ItemsSource="{Binding Customers}"  DockPanel.Dock="Right">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Path=Name}" FontSize="16" FontWeight="Bold">
                        </TextBlock>
                        <TextBlock Text="{Binding Path=TaxIdentifier}" />
                        <TextBlock Text="{Binding Path=Address}" />
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
```

14. Add `StringFormat` in binded properties to inform your users what excatly a particular property means.

```
<ListBox ItemsSource="{Binding Customers}"  DockPanel.Dock="Right">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding Path=Name}" FontSize="16" FontWeight="Bold">
                        </TextBlock>
                        <TextBlock Text="{Binding Path=TaxIdentifier, StringFormat=TaxIdentifier {0}}" />
                        <TextBlock Text="{Binding Path=Address, StringFormat=Adress {0}}" />
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
</ListBox>
```

15. Add extra textbox in the `DataTemplate` to indicate inactive records like here.

```
             <TextBlock Text="Inactive" Foreground="Red">
                        <TextBlock.Style>
                            <Style TargetType="{x:Type TextBlock}">
                                <Setter Property="Visibility" Value="Collapsed"/>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding IsActive}" Value="False">
                                        <Setter Property="Visibility" Value="Visible"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </TextBlock.Style>
                    </TextBlock>
```
16. Modify `UniformGrid` declaration by changing row number to fit a new control

```
  <UniformGrid Columns="1" Rows="3">
```

17. Add `TreeView` contrl in new available row

```
 <TreeView Grid.Row="2" ItemsSource="{Binding Customers}"/>
 ```

18. Add template to `TreeView` use `HierarchicalDataTemplate`.

```
   <TreeView Grid.Row="2" ItemsSource="{Binding Customers}" >
            <TreeView.ItemTemplate>
                <HierarchicalDataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <CheckBox IsChecked="{Binding Path=IsActive}" />
                        <Label Content="{Binding Path=Name}"/>
                    </StackPanel>
                </HierarchicalDataTemplate>
            </TreeView.ItemTemplate>
        </TreeView>
```
