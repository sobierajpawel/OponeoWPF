   M S B A M L   `   `   `  ����O  KOponeo.WMS.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Oponeo.WMS.WPFClient.Views.DeliveryNotes(Oponeo.WMS.WPFClient.Views.DeliveryNotes  5      Q-clr-namespace:Oponeo.WMS.WPFClient.ConvertersOponeo.WMS.WPFClient.Converters  5      [2clr-namespace:Oponeo.WMS.WPFClient.ValidationRules$Oponeo.WMS.WPFClient.ValidationRules  5      M+clr-namespace:Oponeo.WMS.WPFClient.BehaviorOponeo.WMS.WPFClient.Behavior  5
      B    <Oponeo.WMS.WPFClient.Views.DeliveryNotes.AddDeliveryNoteView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:Oponeo.WMS.WPFClient.Views.DeliveryNotes     5      D
converters-clr-namespace:Oponeo.WMS.WPFClient.Converters     5      NvalidationRules2clr-namespace:Oponeo.WMS.WPFClient.ValidationRules     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5	      ;	behaviors+clr-namespace:Oponeo.WMS.WPFClient.Behavior  5
        � 	Resources  5          BooleanToVisibilityConverterH  BOponeo.WMS.WPFClient.Converters.InvertBooleanToVisibilityConverter & "InvertBooleanToVisibilityConverterA  ;Oponeo.WMS.WPFClient.Converters.DateSmallerThanNowConverter  DateSmallerThanNowConverter �� MergedDictionaries �� Source�� 5   
    5      �� 5      $; 5/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml?�6%   %W   &	        &	      &	 &     �� 5      6+     5      6<     5      65   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   .+�5'   
   �� $��0��6   $��0��6   $��2��6-   $��Center=�6A   $��18(�6^   $
��Bold"�6l   $��Add delivery form��6~   �� 5)   
   $��0,10,0,0q�6   $��1��6"   $��0��6/   $��Document number��6?   �� 5*   
   $��0,10,0,0q�6   $��2��6"   $��0��6/   .��6?   Document date6N   �� 5+   
   $��0,10,0,0q�6   $��3��6"   $��0��6/   .��6?   Document description6U   �� 5,   
   $��0,10,0,0q�6   $��4��6"   $��0��6/   $��Selected customer��5-   =   5.      �� 50   
     ValidatedTextBox#��[ 6   $��0,10,0,0q�6<   $��1��6O   $��1��6_   {�51      �� *DocumentDate+ �� 	Converter# [ .��6m   ��52      �� 53       �� Path$ DocumentNumber�6    �� UpdateSourceTrigger$ PropertyChanged=�60    �� ValidatesOnDataErrors . 	 �� ValidationRules	 54      B  <Oponeo.WMS.WPFClient.ValidationRules.DocumentNumberValidator  55      57      .��58      59      (  "System.Windows.Controls.DatePicker  5:   
   $��0,10,0,0q�6   $��1��6(   $��2��68   
   SelectedDate
 6E   �� *DocumentDate+��5;      �� 5<       �� 
TargetType"  6   .�5=      ��  �� Property � {� �� Value .  62    �� Triggers 5>      ^� 5?       ^� 
Conditions 5@      �� 5A   "    �� Binding 6,   �� *SelectedCustomer.IsActive+ �� Value True6Z   0�5D      �� 5E   "    � {� . 6>   5G      5L      5N      �� 5O   
   $��0,10,0,0q�6   $��1��6%   $��3��65   ��6B   �� *Description+ . $ PropertyChanged=�.��6�   *  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5P      7  1Oponeo.WMS.WPFClient.Behavior.LoadOnFocusBehavior  5Q      .��5R   '   ��5S      �� 5T       �� BasedOn# [ 6   " ��6D    5U      :� 5V       :� RoutedEvent$ GotFocus��6'   .[�5W      �� .��5X   "   �� .��5Y   &   ��  �� TargetProperty$ Background.Color�65   	 �� To$ AntiqueWhiteX�6b    g� Duration$ 0:0:0.85D�6t   5Z   #   5[      5\      :� 5]      $ 	LostFocus��6'   .[�5^      �� .��5_   "   �� .��5`   &   �� $ Background.Color�65   $ WhiteX�6b   $ 0:0:0.85D�6m   5a   #   5b      5c      5e      .��5f      5g      �� 5h   
   $��0,10,0,0q�6    �� DisplayMemberPath$
 Name��6%   $��1��6?   $��4��6O   ��6\   �� *	Customers+ �� SelectedItem 6~   �� *SelectedCustomer+�� 5j   
   $��5��6v   $��2��6�   $��
40,30,40,0q�6�   y�6   �� *IsActiveCustomer+# [  .+�5k      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5l      �� $��Mouse��69   $
��Save��6R   ��6   �� *SaveCommand+6c   �� 5m      $��20,0,0,0q�6   $��Set default��6Q   ��6+   �� *SetDefaultCommand+6i   5n      5o      �� 5q   
   $��6��6   $��2��6   $��Center=�61   
���  ��$)��#The selected customer is not active��5r      y�6?   �� *IsActiveCustomer+# [ 5t      5u      