   M S B A M L   `   `   `  ����J  FShopping system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Shopping_system.ViewShopping_system.View  5      E'clr-namespace:Shopping_system.ConverterShopping_system.Converter  5          Shopping_system.View.Menu   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Shopping_system.View     5      :local1'clr-namespace:Shopping_system.Converter     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ��5
      �� 5   
     �� Opacity$	  0.3Q�6    �� ImageSource$ /Images/background.jpg��6#    � 	Resources 5      .   (Shopping_system.Converter.MultiConverter   multiConverter  elipseStyle �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  
manageCart	 �� 
TargetType'  !MaterialDesignThemes.Wpf.PackIcon
   Kind  associationRules 
 Filter  recommenderCart��%�  &	        &	      &	 9    7  &	 R    7  &	 k    7  &	 ~    7    5   
   6    �� 5   
   " A�6$   .�5      ��  � ��$	 180��6&   �� 5       � ��$	 180��6&   �� 5       � ��
 �   �6'   �� 5       � ��$ 2��60    5      P� 5       �@J�IsMouseOver . . �5      ��  �@�Cursor$
 Hand��6/   5      5      �� 5   
   "	 ��6-   .R�5      � .+�5      A� 8��  ��5      �� 5      $	  0.1Q�6%   $ /images/Menu1.jpg��63   6U   5!        5"      $
 ShoppingCart=�6*   
���   �$	��130��6Q   $	��130��6]   $��Center=�6j   $��Center=�6�   5#      5$      �� 5&   
   "	 ��63   .R�5'      � .+�5(      A� 8��  ��5)      �� 5*      $	  0.1Q�6%   $ /images/Menu2.jpg��63   6U   5,        5-      $
 ArrowForward=�6*   
���   �$	��130��6Q   $	��130��6]   $��Center=�6j   $��Center=�6�   5.      5/      �� 51   
   "	 ��6)   .R�52      � .+�53      A� 8��  ��54      �� 55      $	  0.1Q�6%   $ /images/Menu3.jpg��63   6U   57        58      $
 Filter=�6*   
���   �$	��130��6K   $	��130��6W   $��Center=�6d   $��Center=�6�   59      5:      �� 5<   
   "	 ��62   .R�5=      � .+�5>      A� 8��  ��5?      �� 5@      $	  0.1Q�6%   $ /images/Menu4.jpg��63   6U   5B        5C      $
 
ListStatus=�6*   
���   �$	��130��6O   $	��130��6[   $��Center=�6h   $��Center=�6�   5D      5E      5F      .��5H      ��  �� Orientation$ 
Horizontal=�6   .+�5I   
   � ���#C1F5E9$	��180��6$    � RowDefinitions 5J      �� 5K      $
��2.6* �6    �� 5L      $��6* �6    �� 5M      $
��0.5* �6    �� 5N      $��1* �6    .+�5Q      �� $��0��6   ._�5R      � .+�5S      �� $��0,0,0,0q�6   $��2��6-     icon#��[ 6=   $��80��6^   $��80��6i   6w   �� 5T      $��	0,115,0,0q�6    $��2��63   $
��Sbuy��6G   $��Center=�6S   $��Center=�6p   $��18(�6�   $
��Bold"�6�   �� 5U      $��	0,160,0,0q�6    $��2��63   $��Your smartest buy��6G   $��Center=�6`   $��Center=�6}   $��15(�6�   5V      5W      �� 5Y      $��2��6   ._�5Z      �� $ 
Horizontal=�6   $��LeftToRight=�66   $��Center=�6R   $��Center=�6o   .+�5[      �� $
��Hi, ��6    $��20(�6,   �� 5\      $��20(�6|   ��6    ��  �� Path$$ currents.CurrentUser.firstName� �� Current �� Source# Z 6|   �� 5]      $�� ��6    $��20(�6)   �� 5^      $��20(�6{   ��6    �� $# currents.CurrentUser.lastName�# Z 6{   5_      5`      �� 5b      $��3��6   ._�5c      �  � ColumnDefinitions 5d      �� 5e      $��* �6+   �� 5f      $��* �6+   .+�5h        $��1��6.   $
 Logout=�6>   $��Center=�6L   $��Center=�6i   �� 5i      $��0��6   $��2��6-   $��log out��6A   $��Center=�6S   $��Center=�6�    # roundedCornersButtonTransparent#��[ 6�   ��6p   �� *DisplayLoginView+6�   5j      5k      5l      �� 5n   
   $ Vertical=�6   .+�5o      �� $��	0,45,60,5q�6    	 close#��[ 6C    	 buttonStyle#��[	 6e   ��6(   �� *GoBack+6�   �� 5q      $ 
Horizontal=�6   .+�5r      �� $��160,177,25,0q�6   .+�5s      �� $	��180��6   #��[ 6Q   ��6*   �� *DisplayAllPurchase+5t      �� 5u      $��Manage Purchases��6    $��15(�68   $��0,10,0,0q�6F   $��Center=�6X   $��Bottom=�6u   6�   5v      �� 5x      $��25,177,25,0q�6   .+�5y      �� $	��180��6   #��[ 6X   ��6,   �� *DisplayAssociationRules+5z      �� 5{      $��Association Rules��6    $��15(�69   $��0,0,0,0q�6G   $��Center=�6X   $��Bottom=�6u   6�   5|      �� 5~      $��25,177,25,0q�6   .+�5      �� $	��180��6   #��[ 6U   ��6*   �� *DisplayFilterSelection+.��5�      �� $.��(תצוגה גרפית וויזואלית��6$   ��5�      `� 5�       `� 	Converter# [  6+   .1�5�   "   ��  �� ElementName$ mailTB��6*   �� 5�   "   $ 
passwordTB��6*   5�      5�      �� 5�      $��Filter and Chart��6    $��15(�68   $��0,10,0,0q�6F   $��Center=�6X   $��Bottom=�6u   6�   5�      �� 5�      $��25,177,200,0q�6   .+�5�      �� $	��180��6   #��[ 6J   ��6*   �� *DisplayList+.��5�      �� $��רשימת קניות��6$   5�      �� 5�      $��Recommended shopping list��6    $��15(�6A   $��0,10,0,0q�6O   $��Center=�6a   $��Bottom=�6~   6�   5�      5�      5�      5�      5�      