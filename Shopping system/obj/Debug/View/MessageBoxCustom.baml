   M S B A M L   `   `   `  ����J  FShopping system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Shopping_system.ViewShopping_system.View  5   	   +    %Shopping_system.View.MessageBoxCustom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Shopping_system.View     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  MessageBoxWindow��5   	   $	��240��6"   $	��520��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � WindowStyle$
 None=�6.   
������� � 
ResizeMode$ 	CanResize=�5
   	    � Topmost .  � ShowInTaskbar .     MaterialDesignBody#���   5   	   $��Regular"�5   	   $��10(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��197* �6   �� 5      $
��295* �6   	 � RowDefinitions	 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  -   5        
  Name$
 
cardHeader��5      $��0��62   $��10q�6?   $��0q�6L   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�6W   $y�Visible=�6�   $��2��6�   ��6�   �� *
BackGround+.��5      �� .+�5      �� -   5         ��Name$ txtTitle��5      $��Center=�6h   $��Stretch=�6�      MaterialDesignTitleTextBlock#���  6�   $��30(�6�   ��6*   �� *Header+��6E   �� *
Foreground+6�   5      5      � 5    
   $��1��6   $��2��6   .+�5!      � $��20q�6   	 5"      �� 5#      $
��auto �6$   �� 5$      $
��auto �6$   �� 5%      $��* �6$   .+�5(      � $��0��6   	 5)      �� 5*      $
��auto �6(   �� 5+      $��* �6(   .+�5.      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffects 5/      ;  5MaterialDesignThemes.Wpf.Transitions.TransitionEffect  50         Kind$ FadeIn=�6>     51      $ SlideInFromBottom=�6>   .��53      �� -   5        $ 
txtMessage��53       $��Center=�6P   $��0��6n   $��5q�6{   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  ��6�   $��15(�6�     MaterialDesignLabel#��[ 6�   ��64   �� *	Message+6�   54      56      � 57      $��1��6   $��0,20,0,5q�6$    58      �� 59      $��* �6+   �� 5:      $
��auto �6+   �� 5;      $
��auto �6+   �� 5<      $��* �6+   .+�5?      �� -   5         ��Name$ btnOK��5?      $��1��6@     roundedCornersButton#��[ 6P   
���   �$��5q�6�   $	��100��6�   $��OK��6�    � ToolTip$ 
Ok, got it��6�   5@      5B      5C      5D      5E      