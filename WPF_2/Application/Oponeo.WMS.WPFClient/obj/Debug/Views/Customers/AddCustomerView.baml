   M S B A M L   `   `   `  ����O  KOponeo.WMS.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Oponeo.WMS.WPFClient.Views.Customers$Oponeo.WMS.WPFClient.Views.Customers  5      :    4Oponeo.WMS.WPFClient.Views.Customers.AddCustomerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Oponeo.WMS.WPFClient.Views.Customers     5        J� InputBindings  5	      �� 5
   
   
 �� Key$ S��65    �� 	Modifiers$
 Ctrlf�6=    �� CommandParameter$ Keyboard��6N    �� Command 6   �� *SaveCommand+6N    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $; 5/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   	 � RowDefinitions	 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $��* �6   .+�5$   
   �� $��0��6   $��0��6   $��2��6-   $��Center=�6A   $��18(�6^   $
��Bold"�6l   $��Customer form��6~   �� 5&   
   $��0,10,0,0q�6   $��1��6"   $��0��6/   $��Customer Name��6?   �� 5'   
   $��0,10,0,0q�6   $��2��6"   $��0��6/   .��6?   Tax identifier6O   �� 5(   
   $��0,10,0,0q�6   $��3��6"   $��0��6/   $��Address��5)   3   5*      �� 5+   
   $��0,10,0,0q�6   $��4��6"   $��0��6/   $��IsActive��6?   �� 5,   
   $��0,10,0,0q�6   $��5��6"   $��0��6/   $��
ActiveFrom��6?   �� 5.   
   $��0,10,0,0q�6   $��1��6$   $��1��64   ��6A   �� *Name+
 �� UpdateSourceTrigger$
 PropertyChanged=�6~   �� 5/   
   $��0,10,0,0q�6   $��1��6$   $��2��64   ��6A   �� *TaxIdentifier+$
 PropertyChanged=�6�   �� 50   
   $��0,10,0,0q�6   $��1��6$   $��3��64   ��6A   �� *	Address+$
 PropertyChanged=�6�   �� 51   
   $��0,10,0,0q�6   $��1��6%   $��4��65    d� 	IsChecked 6B   �� *
IsActive+(  "System.Windows.Controls.DatePicker  52   
   $��0,10,0,0q�6   $��1��6'   $��5��67      SelectedDate 6D   �� *
ActiveFrom+�� 54   
   $��6��6   $��2��6"   $��
40,30,40,0q�66   .+�55      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�56      �� $��Mouse��69   $
��Save��6R   ��6   �� *SaveCommand+6c   �� 57      $��20,0,0,0q�6   $��Set default��6Q   ��6+   �� *SetDefaultCommand+6i   �� 58         SecondButton#��[  6   $��20,0,0,0q�6?   $��List of customer��59   [   ��58   Q   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" � �� Path$% DataContext.ListCustomerCommand�59   x   5:      �� 5<      $��0,10,0,0q�6/   $��Center=�6A   ��6   �� *Status+6`   5=      5@      5A      