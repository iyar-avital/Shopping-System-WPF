   M S B A M L   `   `   `  ����J  FShopping system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Shopping_system.ConverterShopping_system.Converter  5      -    'Shopping_system.View.HistoryByProductUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:Shopping_system.Converter     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � 	Resources  5	      .   (Shopping_system.Converter.MultiConverter   multiConverter��%   &	          5
   
   6   5      .��5      �  � RowDefinitions 5      �� 5      $
��0.3* �6    �� 5      $
��0.3* �6    �� 5      $��1* �6    .+�5      � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� $��	Filter by��6$   $��Center=�65   $��40(�6R   $��
30,30,12,0q�6`   �� 5      $��Product��6$   $��Center=�63   $��40(�6P   $
��Bold"�6^   $��0,30,0,0q�6p   '  !MaterialDesignThemes.Wpf.PackIcon  5      $��2��6.      Kind$ 	LocalMall=�6>   $
��Bold"�6O   $��Center=�6b   $��Center=�6   $��50��6�   $��50��6�   $��	0,36,0,44q�6�   5      � 5      .+�5      ��  	 close#��[ 68     buttonStyle#��[ 6Z    J� RenderTransformOrigin$ 0.593,-0.969&�6   ��6   �� *GoBack+6�   �� 5      $
��Left=�6   $	��120��68   $	��120��6D   
������ 
������ $��	0,10,20,0q�6�   ��6�   �� *ChartCommand+��6�   ��  �� ElementName$ productCombobox��.��5      �� $��/Images/chart.png��6    5      5      5      �� 5       $��1��6   $ Vertical=�6&   ��5!      u� 5"       u� Left$ 30Q�6    
 u� Top$ 0Q�6*    u� Bottom$ 0Q�62   .+�5$      �� $ 
Horizontal=�6   .+�5%      �� $��Product Name: ��6   $��Normal"�65   �� 5&      -   5        	 ��Name$	 productCombobox��5&      $	��102��64   $��3q�6@   ��6K   �� *
Products+
 �� SelectedValue
 6l   �� *ProductName+ �� Mode$ TwoWay=�5'      �� 5(      $ 
Horizontal=�6   .+�5)      �� $��Day:                  ��6   $��Normal"�6=   �� 5*      -   5        $	 dayCombobox��5*      $	��102��64   $��3q�6@   ��6K   �� *Days+5+      �� 5,      $ 
Horizontal=�6   .+�5-      �� $��Month:             ��6   $��Normal"�6:   �� 5.      -   5        $	 monthCombobox��5.      $	��102��66   $��3q�6B   ��6M   �� *Months+5/      �� 50      -   5         ��Name$ filterButton��50   V   $
��Left=�6;   
���   �$��filter��6�   
���   �$��10(�6�   
�������$��10q�6�   $	��170��6�   $��25��6�   ��6   �� *FilterCommand+��51      `� 52       `� 	Converter# [  6'   .1�53      �� $ productCombobox��6&   �� 54      $ dayCombobox��6&   �� 55      $ monthCombobox��6&   56      58      59      �� 5;   
   $��2��6   $
��Auto=�6$   .��5<      �� ��6   �� *shoppingVMs+��5=      �� 5>      .R�5?      �� $��30q�6!    �� Padding$ 10q�6-    �� CornerRadius$ 5��6:   ���#B9D7EA
��� ���$	��1.5q�6u    J� Opacity$	 0.7Q�6�   ._�5@      �� .+�5A   "   �� $��Center=�6G   $
��Bold"�6d   $��16(�6v   ��6,   �� *	storeName+6v   �� 5B   "   $��Center=�6B   $��DemiBold"�6_   $��15(�6u    �� Padding$ 3q�6�   ��6,   �� *city+6�   �� 5C   "   $��13(�6e   $ 3q�6s   ��6,   �� *date+ �� StringFormat$ Date: {0:dd/MM/yy}��6s   �� 5D   "   $��13(�6n   $ 3q�6|   ��6,   �� *numProducts+$ Products amount: {0}��6|   �� 5E   "   $��13(�6e   $ 3q�6s   ��6,   �� *price+$ Total Price: {0}$��6s   �� 5F   "   
������ 
������ $��0q�6\   .��5G   &     $
 Cart=�6>   
���   �$
��Bold"�6]   $��Center=�6p   $��Center=�6�   5H   #   5I      5J      5K      ��5M      �� 5N      .R�5O      � 5P      5R      5S      5T      5U      