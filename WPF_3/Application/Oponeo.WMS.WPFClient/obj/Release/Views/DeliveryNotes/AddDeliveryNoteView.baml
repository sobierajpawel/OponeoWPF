   M S B A M L   `   `   `  ���� O  KOponeo.WMS.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:Oponeo.WMS.WPFClient.Views.DeliveryNotes(Oponeo.WMS.WPFClient.Views.DeliveryNotes  Q-clr-namespace:Oponeo.WMS.WPFClient.ConvertersOponeo.WMS.WPFClient.Converters  M+clr-namespace:Oponeo.WMS.WPFClient.BehaviorOponeo.WMS.WPFClient.Behavior  B    <Oponeo.WMS.WPFClient.Views.DeliveryNotes.AddDeliveryNoteView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Hlocal6clr-namespace:Oponeo.WMS.WPFClient.Views.DeliveryNotes     D
converters-clr-namespace:Oponeo.WMS.WPFClient.Converters     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  ;	behaviors+clr-namespace:Oponeo.WMS.WPFClient.Behavior    � 	Resources      BooleanToVisibilityConverterH  BOponeo.WMS.WPFClient.Converters.InvertBooleanToVisibilityConverter & "InvertBooleanToVisibilityConverterA  ;Oponeo.WMS.WPFClient.Converters.DateSmallerThanNowConverter  DateSmallerThanNowConverter �� MergedDictionaries �� Source��  �� $; 5/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml?�%-   &	        &	      &	 
     ��     .���  � ColumnDefinitions �� $��* ��� $��2* � � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+��� $��0��$��0��$��2��$��Center=�$��18(�$
��Bold"�$��Add delivery form���� $��0,10,0,0q�$��1��$��0��$��Document number���� $��0,10,0,0q�$��2��$��0��.��Document date�� $��0,10,0,0q�$��3��$��0��.��Document description�� $��0,10,0,0q�$��4��$��0��$��Selected customer����   DeliveryTextBox#��[ $��0,10,0,0q�$��1��$��1��{��� *DocumentDate+ �� 	Converter# [ ���� *DocumentNumber+ �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�(  "System.Windows.Controls.DatePicker  $��0,10,0,0q�$��1��$��2��   SelectedDate �� *DocumentDate+���� 	 �� 
TargetType"	  .��� 
 �� Property
 � {� �� Value .   �� Triggers ^�  ^� 
Conditions ��  �� Binding �� *SelectedCustomer.IsActive+ �� Value True0��� 
 � {� . �� $��0,10,0,0q�$��1��$��3������ *Description+$ PropertyChanged=�.��*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 7  1Oponeo.WMS.WPFClient.Behavior.LoadOnFocusBehavior  .������ "	 �� :�  :� RoutedEvent$ GotFocus��.[��� .���� .����  �� TargetProperty$ Background.Color�	 �� To$ AntiqueWhiteX� g� Duration$ 0:0:0.85D�:� $ 	LostFocus��.[��� .���� .���� $ Background.Color�$ WhiteX�$ 0:0:0.85D�.���� $��0,10,0,0q� �� DisplayMemberPath$
 Name��$��1��$��4������ *	Customers+ �� SelectedItem �� *SelectedCustomer+�� $��5��$��2��$��
40,30,40,0q�y��� *IsActiveCustomer+# [  .+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Mouse��$
��Save������ *SaveCommand+�� $��20,0,0,0q�$��Set default������ *SetDefaultCommand+�� $��6��$��2��$��Center=�
���  ��$)��#The selected customer is not active��y��� *IsActiveCustomer+# [ 