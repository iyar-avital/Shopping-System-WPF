   M S B A M L   `   `   `  ����J  FShopping system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Shopping_system.ViewShopping_system.View  5      '    !Shopping_system.View.ForYouListUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .local"clr-namespace:Shopping_system.View  5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��0.3* �6   �� 5      $��1* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $��Recommended��6   $��Center=�6/   $��40(�6L   $��
30,30,12,0q�6Z   �� 5      $��for you��6   $��Center=�6+   $��40(�6H   $
��Bold"�6V   $��0,30,0,0q�6h   '  !MaterialDesignThemes.Wpf.PackIcon  5      $��2��6*      Kind$
 Star=�6:   $
��Bold"�6F   $��Center=�6X   $��Center=�6u   $��50��6�   $��50��6�   $��	10,7,0,44q�6�   5      � 5      .+�5      ��  	  close#��[  64     buttonStyle#��[ 6V    J� RenderTransformOrigin$ 0.593,-0.969&�6{   ��6   �� *GoBack+6�   �� 5      $
��Left=�6   $	��120��64   $	��120��6@   
������ 
������ $��	0,10,20,0q�6�   ��6�   �� *	CreatePdf+��6�   ��  �� ElementName$ productCombobox��.��5        $��2��6.   $ FilePdf=�6>   ���#e50000$
��Bold"�6b   $��Center=�6t   $��Center=�6�   $��60��6�   $��60��6�   $��0,7,0,44q�6�   5      5      5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� ��6   �� *
ProductVMs+��5      �� 5       .R�5!      �� $��30q�6!    �� Padding$ 10q�6-    �� CornerRadius$ 20��6:   $	��1.5q�6L   ���#FFFDD6
���   �$	��170��6�   $	��180��6�   ._�5"      �� .+�5#   "   �� $��Center=�6I   $��DemiBold"�6f   $��20(�6|    �� Padding$ 3q�6�   ��6,   �� *productName+6�   �� 5$   "   $��13(�6I   $��Center=�6W   $ 3q�6t   ��6,   �� *description+6t   �� 5%   "   $��80��6E   $��80��6P   ��6(   �� *	imagePath+6^   5&      5'      5(      ��5*      �� 5+      .R�5,      � 5-      5/      50      51      52      