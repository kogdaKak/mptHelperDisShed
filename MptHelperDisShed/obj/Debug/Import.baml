   M S B A M L   `   `   `  ����K  GMptHelperDisShed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MptHelperDisShedMptHelperDisShed  5   	   !    MptHelperDisShed.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a>design1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:MptHelperDisShed  5   	   -   5          � Title$#  Загрузка данных��5	   	    � WindowState$ 	Maximized=�6!   ���#90A4AE.��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      .  (MaterialDesignThemes.Wpf.ColorZoneAssist   
Background
 �   �6K   �� 5       
 �   �6K   �� 5!      
 �   �6K   �� 5"      
 �   �6K   �� 5#      
 �   �6K   �� 5$      
 �   �6K   .+�5&   
   �� -   5        $��txtFilePath��5&   s    �� 
IsReadOnly . $��0��6$   $��1��61   $��1��6A   $��10��6R   $��30��6g   $	��550��6�   
�������$��15(�6�    J� Opacity$ 1Q�6�   $	��Top=�6�   �� 5'   
   -   5        $��btRaspredelenie��5'   `   $	��150��6   $��0��6   $��12��6*   $��1��6;   $��2��6L   $ ��Распределение��6w   $��Center=�6�   $��Bottom=�6�   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IndicatorBackground
 ��  �+  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5(   H   6q   �� 5)      -   5        $��btImport��5)   d   $	��150��6   $��0��6!   $��12��6.   $��1��6?   $��2��6P   $��Загрузить��6t   $��Center=�6�   $	��Top=�6�   
 ��  �$ 10��5*   H   6q   &   System.Windows.Controls.DataGrid  5+   
   -   5        $��Employe��5+   �   	   AutoGenerateColumns	 . 
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$

 auto 6b      
IsReadOnly . $��2��6�   $��1��6�   $��7��6�   $��4��6�   6�     5,   
   -   5        $��Group��5,   �   	 . $

 auto 6`    . $��2��6�   $��5��6�   $��7��6�   $��2��6�   6�     5-   
   -   5        $��	Cabinetes��5-   �   	 . $

 auto 6d    . $��2��6�   $��7��6�   $��7��6�   $��2��6�   6�     5.   
   -   5        $��	Territory��5.   �   	 . $

 auto 6d    . $��2��6�   $��9��6�   $��7��6�   $��3��6�   6�   5/      50      