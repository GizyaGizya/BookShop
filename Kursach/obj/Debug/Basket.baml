   M S B A M L   `   `   `  ����B  >Kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:KursachKursach  5   	       Kursach.Basket   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Kursach     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Корзина��5
   	   $	��450��6   $	��800��6&   .��5      � ���	#FFDCD27D.+�5   
   �� $��Корзина��6   $��Center=�6"   $��54��6?   $��176,10,176,0q�6K   $	��Top=�6a   $	��440��6y   $��35(�6�   $��Center=�6�   ���	#FFD6D2D26�   �� 5   
   -   5         ��Name$ B_cat��5      $$��Назад к каталогу��6    $
��Left=�6;   $��33��6V   $��
10,376,0,0q�6b   $	��Top=�6v   $	��104��6�   ���	#FFD764646�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
BasketGrid��5         
IsReadOnly .    AutoGenerateColumns .  $
��Left=�6V   $	��275��6q   $��0,82,0,0q�6~   $	��Top=�6�   $	��793��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 61   �� *id+  5      $ Название��6%   	 67   �� *name+  5      $ 
Автор��6%   	 64   �� *author+  5      $ Количество��6%   	 69   �� *count+  5      $ Цена��6%   	 63   �� *price+5      �� 5   
   -   5        $ Checkout��5      $��Оплатить��6#   $
��Left=�66   $��33��6Q   $��670,376,0,0q�6]   $	��Top=�6r   $	��104��6�   ���	#FFD764646�   �� 5   
   -   5        $ DeleteOrderButton��5      $!��ОТМЕНИТЬ ЗАКАЗ��6,   $
��Left=�6E   $��53��6`   $��	10,11,0,0q�6l   $	��Top=�6   $	��122��6�   ���	#FFD764646�   5      5      