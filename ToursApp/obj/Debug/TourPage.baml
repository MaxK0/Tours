   M S B A M L   `   `   `  ����C  ?ToursApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ToursAppToursApp  5          ToursApp.TourPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:ToursApp     5        N� Title$  TourPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��103* �6   �� 5      $	��97* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $��* �6   6*   .+�5   
   �  � Orientation$ 
Horizontal=�6   $
��Left=�6-   $��2��6H   $��0,0,0,18q�6\   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $9��3Введите название для поиска��6   $	��175��6?    �� TextAlignment$ Right=�6K   6c   �� 5      -   5        $��
TBoxSearch��5   &   $	��225��6   6_   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Выберите тип��6   $	��175��61   $ Right=�6=   6V   �� 5      -   5        $��	ComboType��5   '   $	��225��6    �� DisplayMemberPath$
 Name��6f   6�   5      �� 5      -   5         ��Name$ CheckActual��5      $E��?Показывать только актуальные туры��6k   $��Center=�6�   6�   5      �� 5   
   -   5        $��
LViewTours��5      $��Disabled=�6%   $��Center=�6[   $��2��6   $��0,37,0,0q�6�   $��2��6�   ��5       �� 5!      .R�5"      � $ 
Horizontal=�6    $��center=�69   5$      5%      ��5)      �� 5*      .R�5+      � $��20q�6   $	��400��6'    5,      �� 5-      $��70 �6,   6:   �� 5.      $	��310 �6,   6;   �� 5/      $
��auto �6,   6<   �� 50      $
��auto �6,   6<   .+�52      �� $	��400��6    $��1��6,   $��UniformToFill=�69   $��Center=�6Q   $��5q�6n   ��53      �� 54   "    �� Path$ ImagePreview�6*   	 �� TargetNullValue	 55   &   ��56   *   Resources/picture.png��6M   59   #   5;      �� 5<      $��Center=�6$   $ Center=�6?   $	��390��6V   $
��Wrap=�5=   $   $��Center=�68   $	��5 5q�6U   $��26(�6b   $��0��6p   6   �� 5>      $��2��6V   $��5 5 5 15q�6c   $��Center=�6u   $��26(�6�   $
��Bold"�6�   ��6$   �� *Price+
 �� StringFormat$
 {0:N2} РУБ��6�   �� 5?      $��3��6g   $��Right=�6t   $��14(�6�   ��6$   �� *TicketCount+$*
 $Билетов осталось: {0}��6�   �� 5@      $��3��6@   $
��Left=�6M   $��14(�6h   ��6$   �� *
ActualText+6x   5D      5E      5G      5I      5J      