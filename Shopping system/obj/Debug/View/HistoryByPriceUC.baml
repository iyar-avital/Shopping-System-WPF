   M S B A M L   `   `   `  ����J  FShopping system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Shopping_system.ConverterShopping_system.Converter  5      +    %Shopping_system.View.HistoryByPriceUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3local'clr-namespace:Shopping_system.Converter  5        � 	Resources  5
      .   (Shopping_system.Converter.MultiConverter   multiConverter��%   &	          5   
   6   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $��0.25* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5      �� $��	Filter by��6    $��Center=�61   $��40(�6N   $��
30,30,12,0q�6\   �� 5      $��Price��6    $��Center=�6-   $��40(�6J   $
��Bold"�6X   $��0,30,0,0q�6j   '  !MaterialDesignThemes.Wpf.PackIcon  5      $��2��6.      Kind$ AttachMoney=�6>   $
��Bold"�6Q   $��Center=�6d   $��Center=�6�   $��50��6�   $��50��6�   $��0,0,0,12q�6�   5      � 5      .+�5      ��  	 close#��[ 68     buttonStyle#��[ 6Z    J� RenderTransformOrigin$ 0.593,-0.969&�6   ��6   �� *GoBack+6�   �� 5      $
��Left=�6   $	��120��68   $	��120��6D   
������ 
������ $��	0,10,20,0q�6�   ��6�   �� *ChartCommand+.��5      �� $��/Images/chart.png��6    ��5      `� 5       `� 	Converter# [  6+   .1�5   "   ��  �� ElementName$ startTB��6*   �� 5    "   $ endTB��6*   5!      5#      5$      5%      �� 5'      $��1��6   $ Vertical=�6&   ��5(      u� 5)       u� Left$ 30Q�6    
 u� Top$ 0Q�6*   	 u� Bottom$	 0Q�62   .+�5,      �� $ 
Horizontal=�6   .+�5-      �� $��Day:                  ��6   $��Normal"�6=   �� 5.      -   5        
 ��Name$
 dayCombobox��5.      $	��102��64   $��3q�6@   ��6K   �� *Days+�� 5/      $��Minimum Price: ��6   $��Normal"�66   ��50      u� 51      $ 50Q�6(   53      �� 54      -   5         ��Name$ start��54       � Minimum$ 0Q�6,    � Maximum$	 100Q�68   ���#fffa96
���   �$	��0.5q�6o   $	��200��6�   $��20��6�   �� 55      -   5         ��Name$ startTB��55      $��Right=�6�    �� TextAlignment$ Right=�6�   $
��auto��6�   $��3q�6�   $��0q�6�   ��6/   �� $ start�� �� Path$ Value� �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� �� StringFormat$ 	{0:#,0.0}��6�   56      �� 57      $ 
Horizontal=�6   .+�58      �� $��Month:             ��6   $��Normal"�6:   �� 59      -   5        $
 monthCombobox��59      $	��102��66   $��3q�6B   ��6M   �� *Months+�� 5:      $��Maximum Price: ��6   $��Normal"�66   ��5;      u� 5<      $ 50Q�6(   5>      �� 5?      -   5        $	 end��5?      $ 0Q�6*   $	 100Q�66   ���#fffa96
���   �$	��0.5q�6m   $	��200��6�   $��20��6�   �� 5@      -   5        $ endTB��5@      $��Right=�6�   $ Right=�6�   $
��auto��6�   $��3q�6�   $��0q�6�   ��6-   �� $	 end��$ Value�$ PropertyChanged=�$ TwoWay=�$ 	{0:#,0.0}��6�   5A      �� 5C      -   5         ��Name$ filterButton��5C   V   $
��Left=�6;   
���   �$��filter��6�   
���   �$��10(�6�   
�������$��10q�6�   $	��170��6�   $��25��6�   ��6   �� *FilterCommand+��5D      `� 5E      # [  6'   .1�5F      �� $ startTB��6&   �� 5G      $ endTB��6&   �� 5H      $ dayCombobox��6&   �� 5I      $ monthCombobox��6&   5J      5L      5M      �� 5O      $��2��6   $
��Auto=�6(   .��5P      �� ��6   �� *shoppingVMs+��5Q      �� 5R      .R�5S      �� $��30q�6%    �� Padding$ 10q�61    �� CornerRadius$ 5��6>   ���#B9D7EA
��� ���$	��1.5q�6z    J� Opacity$	 0.7Q�6�   ._�5T   "   �� .+�5U   &   �� $��Center=�6K   $
��Bold"�6h   $��16(�6z   ��60   �� *	storeName+6z   �� 5V   &   $��Center=�6F   $��DemiBold"�6c   $��15(�6y    �� Padding$ 3q�6�   ��60   �� *city+6�   �� 5W   &   $��13(�6g   $ 3q�6u   ��60   �� *date+$ Date: {0:dd/MM/yy}��6u   �� 5X   &   $��13(�6p   $ 3q�6~   ��60   �� *numProducts+$ Products amount: {0}��6~   �� 5Y   &   $��13(�6g   $ 3q�6u   ��60   �� *price+$ Total Price: {0}$��6u   �� 5Z   &   
������ 
������ $��0q�6`   .��5[   &     $
 Cart=�6>   
���   �$
��Bold"�6]   $��Center=�6p   $��Center=�6�   5\   #   5]   #   5^      5_      ��5a      �� 5b      .R�5c      � 5d      5f      5g      5h      5i      