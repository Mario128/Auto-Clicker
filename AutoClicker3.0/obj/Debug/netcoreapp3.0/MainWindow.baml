   M S B A M L   `   `   `  ����I  EAutoClicker3.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:AutoClicker3._0AutoClicker3._0  5   	        AutoClicker3._0.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:AutoClicker3._0     5   	   -   5          �Name$  MainWindow1��5   	    � Title$ 
MainWindow��5   	   ���	#FF77C2E4$��Center=�6N   $��Center=�6k   $	��350��6�   $	��145��6�   .��5	      � $	��350��6   $��Stretch=�6    � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $	��61* �6   �� 5      $
��170* �6   �� 5      $
��119* �6   �� 5      $��0* �6   �� 5      $��0* �6   .+�5   
   �� $	��Top=�6   $��27��6-   $��
10,36,10,0q�69    J� RenderTransformOrigin$ 0.371,-1.252&�6M    �� Orientation$ 
Horizontal=�6r   $��5��6�   .+�5      �� -   5         ��Name$ Min_Value_Label��5      $��	Min Value��6-   $��29��6A   �� 5      -   5         ��Name$ Min_Value_TextBox��5       �� TextWrapping$
 Wrap=�61   $��40��6E   �� 5      -   5        $ Max_Value_Label��5      $��	Max Value��6-   $��66��6A   �� 5      -   5        $ Max_Value_TextBox��5      $
 Wrap=�61   $��40��6E   �� 5      -   5         ��Name$ Accept_Button��5      $��Accept Input��6,   $��40,0,0,0q�6_   5      �� 5   
   -   5        $ Interval_Label��5      $#��Click Interval (Milliseconds)��6(   $
��Left=�6P   $	��Top=�6k   $	��350��6�   $��26��6�   $��0,10,0,0q�6�   $��2��6�   $��4��6�   �� 5   
   -   5        $ Activation_Info_Label��5      $4��.AC Left: F6 || AC Right: F8 || Cancel Both: F7��6/   $
��Left=�6h   $��0,77,0,0q�6�   $	��Top=�6�   $	��350��6�   $��6��6�   5      5      