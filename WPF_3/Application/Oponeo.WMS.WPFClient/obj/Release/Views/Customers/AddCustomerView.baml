   M S B A M L   `   `   `  ���� O  KOponeo.WMS.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Oponeo.WMS.WPFClient.Views.Customers$Oponeo.WMS.WPFClient.Views.Customers  Q-clr-namespace:Oponeo.WMS.WPFClient.ConvertersOponeo.WMS.WPFClient.Converters  :    4Oponeo.WMS.WPFClient.Views.Customers.AddCustomerView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Dlocal2clr-namespace:Oponeo.WMS.WPFClient.Views.Customers     D
converters-clr-namespace:Oponeo.WMS.WPFClient.Converters       J� InputBindings  �� 
 �� Key$ S�� �� 	Modifiers$
 Ctrlf� �� CommandParameter$ Keyboard�� �� Command �� *SaveCommand+ � 	Resources <  6Oponeo.WMS.WPFClient.Converters.FullDataMultiConverter   FullDataMultiConverter �� MergedDictionaries �� Source��  �� $; 5/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml?�%   &	          .���  � ColumnDefinitions �� $��* ��� $��2* �	 � RowDefinitions	 �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��* �.+��� $��0��$��0��$��2��$��Center=�$��18(�$
��Bold"�$��Customer form���� $��0,10,0,0q�$��1��$��0��$��Customer Name���� $��0,10,0,0q�$��2��$��0��.��Tax identifier�� $��0,10,0,0q�$��3��$��0��$��Address���� $��0,10,0,0q�$��4��$��0��$��IsActive���� $��0,10,0,0q�$��5��$��0��$��
ActiveFrom���� $��0,10,0,0q�$��6��$��0��$��Full data customer���� $��0,10,0,0q�$��1��$��1������ *Name+
 �� UpdateSourceTrigger$
 PropertyChanged=��� $��0,10,0,0q�$��1��$��2������ *TaxIdentifier+$
 PropertyChanged=��� $��0,10,0,0q�$��1��$��3������ *	Address+$
 PropertyChanged=��� $��0,10,0,0q�$��1��$��4�� d� 	IsChecked �� *
IsActive+(  "System.Windows.Controls.DatePicker  $��0,10,0,0q�$��1��$��5��   SelectedDate �� *
ActiveFrom+�� $��0,10,0,0q�$��1��$��6��.����`�  `� 	Converter# [   `� UpdateSourceTrigger$ PropertyChanged=�.1���  �� Path$
 Name��� $ TaxIdentifier��� $ Address�.���� $��7��$��2��$��
40,30,40,0q�.+���  �� Orientation$ 
Horizontal=�$��Center=�.+��� $��Mouse��$
��Save������ *SaveCommand+�� $��20,0,0,0q�$��Set default������ *SetDefaultCommand+��   SecondButton#��[ $��20,0,0,0q�$��List of customer������  �� RelativeSource �� *FindAncestor+ �� AncestorType" �$% DataContext.ListCustomerCommand��� $��0,10,0,0q�$��Center=����� *Status+