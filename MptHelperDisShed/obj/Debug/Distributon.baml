   M S B A M L   `   `   `  ����K  GMptHelperDisShed, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MptHelperDisShedMptHelperDisShed  5   	   "    MptHelperDisShed.Distributon   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962a>design1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   *localclr-namespace:MptHelperDisShed  5   	   -   5        $��Window��5	   q     � Title$7  1Распределение сотрудников��6	    � WindowState$ 	Maximized=�6B   ���#90A4AE.��5
      �  � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!   �� 5       6!   �� 5!      6!   �� 5"      6!   .+�5%   
   &   System.Windows.Controls.DataGrid  -   5        $��dgDistribution��5%   �   $��0��6   $��3��6!   $��7��61   $��9��6B      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6V      
IsReadOnly .    AutoGenerateColumns . $
��Left=�6�   $	��Top=�6�   6�   �� 5&   
   -   5         ��Name$ btInsert��5&   }   $��0��6   $��0��6   $��1��6.   $��2��6?   $��Добавить��6j   $	��120��6�   $��Center=�6�   $��Center=�6�   3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IndicatorBackground
 ��  �+  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 10��5'   H   6q   �� 5(   
   -   5        $ btUpdate��5(   ~   $��1��6   $��0��6   $��1��6.   $��2��6?   $��Изменитть��6j   $	��120��6�   $��Center=�6�   $��Center=�6�   
 ��  �$	 10��5)   F   6o   �� 5*   
   -   5        $ btDelete��5*   |   $��2��6   $��0��6   $��1��6.   $��2��6?   $��Удалить��6j   $	��120��6�   $��Center=�6�   $��Center=�6�   
 ��  �$	 10��5+   H   6q   �� 5-   
   -   5        
 ��Name$
 cbOne��5-   �   $��3��6   $��0��6    $��1��60   $��3��6A   
�������$y�Visible=�6l   $��Center=�6�   $��Center=�6�   $	��150��5.      �� 5/   
   -   5        $��	chbFilter��5/      $��Фильтрация��6$   $��4��69   $��0��6F   $��1��6V   $��Center=�6g   $
��Left=�6�   $��3��6�   �� 50   
   -   5        $

 cbTy��50   �   $��5��6   $��0��6    $��1��60   $��3��6A   $y�Visible=�6U   $��Center=�6�   $��Center=�6�   $	��150��51      
�������6   �� 52   
   -	   5         ��Name$ tbText��52   i   $��6��6   $��0��6   $��1��6/   $��3��6@   $y�Visible=�6T    �� 	MaxLength$ 10��6y   $'��!Введите приоритет��6�   $	��150��53      $��Center=�6   $	��Top=�6<   
�������6T   �� 54   
   $��Bottom=�6   $
��Left=�6/   $��6��6J   $��0��6W   $��1��6g   $��4��6x   �� 55      -
   5        
���   �.�55   C   =;Оцените наш программный продукт6d   56      �� 57   
   -   5        $��7��57      $��0��6   $��1��6/   $��3��6@   $��Выгрузить��6T   $��Center=�6i   $��Center=�6�   $	��120��6�   
 ��  �$	 10��58   I   6r   59      5:      