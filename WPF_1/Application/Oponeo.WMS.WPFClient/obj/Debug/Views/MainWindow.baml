   M S B A M L   `   `   `  ����O  KOponeo.WMS.WPFClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Oponeo.WMS.WPFClientOponeo.WMS.WPFClient  5   	   K GOponeo.WMS.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM8clr-namespace:Oponeo.WMS.Model;assembly=Oponeo.WMS.ModelOponeo.WMS.Model 5   	   Q-clr-namespace:Oponeo.WMS.WPFClient.ViewModelsOponeo.WMS.WPFClient.ViewModels  5   	   Q-clr-namespace:Oponeo.WMS.WPFClient.DesignTimeOponeo.WMS.WPFClient.DesignTime  5	   	   +    %Oponeo.WMS.WPFClient.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Oponeo.WMS.WPFClient     5   	   Jmodel8clr-namespace:Oponeo.WMS.Model;assembly=Oponeo.WMS.Model     5   	   <vm-clr-namespace:Oponeo.WMS.WPFClient.ViewModels     5   	   D
designTime-clr-namespace:Oponeo.WMS.WPFClient.DesignTime     5	   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � DataContext 5      9   3Oponeo.WMS.WPFClient.ViewModels.MainWindowViewModel  5   
   .��5      � $��20q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5!   
   �� $��0��6   $��0��6   $��2��6-   $��Center=�6A   $��18(�6^   $
��Bold"�6l   $��Customer form��6~   �� 5#   
   $��1��6   $��0��6   $��Customer Name��6-   �� 5$   
   $��2��6   $��0��6   .��6-   Tax identifier6=   �� 5%   
   $��3��6   $��0��6   $��Address��5&   3   5'      �� 5)   
   $��1��6   $��1��6"   ��6/   �� *Name+6G   �� 5*   
   $��1��6   $��2��6"   ��6/   �� *TaxIdentifier+6P   �� 5+   
   $��1��6   $��3��6"   ��6/   �� *	Address+6J   �� 5-   
   -   5        $��
40,30,40,0q�5-   &   $��4��6;   $��2��6H   $
��Save��6\   6m   �� 5/   
   $��0,20,0,0q�6   $��5��6"   $��0��6/   $��2��6?   $��14(�6S   $
��Bold"�6a   ��6s   �� *FullCustomerData+6�   51      52      