   M S B A M L   `   `   `  ����O  KOponeo.WMS.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Oponeo.WMS.WPFClient.Views.Customers$Oponeo.WMS.WPFClient.Views.Customers  5      Q-clr-namespace:Oponeo.WMS.WPFClient.ConvertersOponeo.WMS.WPFClient.Converters  5      :    4Oponeo.WMS.WPFClient.Views.Customers.AddCustomerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Oponeo.WMS.WPFClient.Views.Customers     5      D
converters-clr-namespace:Oponeo.WMS.WPFClient.Converters     5        J� InputBindings  5
      �� 5   
   
 �� Key$ S��65    �� 	Modifiers$
 Ctrlf�6=    �� CommandParameter$ Keyboard��6N    �� Command 6   �� *SaveCommand+6N    � 	Resources 5      <  6Oponeo.WMS.WPFClient.Converters.FullDataMultiConverter   FullDataMultiConverter �� MergedDictionaries �� Source�� 5   
    5      �� 5      $; 5/Oponeo.WMS.WPFClient;component/Resources/Styles.xaml?�6%   %   &	          5      60   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   	 � RowDefinitions	 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $��* �6   .+�5'   
   �� $��0��6   $��0��6   $��2��6-   $��Center=�6A   $��18(�6^   $
��Bold"�6l   $��Customer form��6~   �� 5)   
   $��0,10,0,0q�6   $��1��6"   $��0��6/   $��Customer Name��6?   �� 5*   
   $��0,10,0,0q�6   $��2��6"   $��0��6/   .��6?   Tax identifier6O   �� 5+   
   $��0,10,0,0q�6   $��3��6"   $��0��6/   $��Address��5,   3   5-      �� 5.   
   $��0,10,0,0q�6   $��4��6"   $��0��6/   $��IsActive��6?   �� 5/   
   $��0,10,0,0q�6   $��5��6"   $��0��6/   $��
ActiveFrom��6?   �� 50   
   $��0,10,0,0q�6   $��6��6"   $��0��6/   $��Full data customer��6?   �� 52   
   $��0,10,0,0q�6   $��1��6$   $��1��64   ��6A   �� *Name+
 �� UpdateSourceTrigger$
 PropertyChanged=�6~   �� 53   
   $��0,10,0,0q�6   $��1��6$   $��2��64   ��6A   �� *TaxIdentifier+$
 PropertyChanged=�6�   �� 54   
   $��0,10,0,0q�6   $��1��6$   $��3��64   ��6A   �� *	Address+$
 PropertyChanged=�6�   �� 55   
   $��0,10,0,0q�6   $��1��6%   $��4��65    d� 	IsChecked 6B   �� *
IsActive+(  "System.Windows.Controls.DatePicker  56   
   $��0,10,0,0q�6   $��1��6'   $��5��67      SelectedDate 6D   �� *
ActiveFrom+�� 58   
   $��0,10,0,0q�6   $��1��6$   $��6��64   .��6A   ��59      `� 5:       `� 	Converter# [  6    `� UpdateSourceTrigger$ PropertyChanged=�6S   .1�5;      ��  �� Path$
 Name�6   6,   �� 5<      $ TaxIdentifier�6   65   �� 5=      $ Address�6   6/   5>      .��5?      5@      �� 5B   
   $��7��6   $��2��6"   $��
40,30,40,0q�66   .+�5C      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5D      �� $��Mouse��69   $
��Save��6R   ��6   �� *SaveCommand+6c   �� 5E      $��20,0,0,0q�6   $��Set default��6Q   ��6+   �� *SetDefaultCommand+6i   �� 5F        SecondButton#��[ 6   $��20,0,0,0q�6?   $��List of customer��5G   [   ��5F   Q   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �$% DataContext.ListCustomerCommand�5G   x   5H      �� 5J      $��0,10,0,0q�6/   $��Center=�6A   ��6   �� *Status+6`   5K      5N      5O      