   M S B A M L   `   `   `  ����B  >Kursach, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:KursachKursach  5   	       Kursach.Books   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Kursach     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ 
Книги��5
   	   $	��450��6   $	��800��6$   .��5      � ���	#FFDCD27D � ColumnDefinitions 5   
   �� 5      $
��790* �6   �� 5      $��3* �6   .+�5   
   �� $��
Книги��6   $��Center=�6    $��54��6=   $��175,10,175.303,0q�6I   $	��Top=�6c   $	��440��6{   $��35(�6�   $��Center=�6�   ���	#FFD6D2D26�   �� 5   
   -   5         ��Name$ B_cat��5      $$��Назад к каталогу��6    $
��Left=�6;   $��33��6V   $��	10,10,0,0q�6b   $	��Top=�6u   $	��104��6�   ���	#FFD764646�   �� 5   
   -   5         ��Name$ 
SortingBox��5      $��637,52,0,336.667q�6'   .@�5      �� -   5         ��Name$ c1��5      " Цена (По убыванию)68   �� 5      -   5        $ c2��5      (&Цена (По возрастанию)6<   �� 5      -   5        $ c3��5      
Автор6,   �� 5      -   5        $ c4��5      Название6/   5      � 5   
   $��0,89,0,-0.333q�6   .+�5      �� -   5         ��Name$ CatalogItems��5      $��0,10,0,0q�6-    %� 
ScrollUnit$ Pixel=�6?   ��5      �� 5      .R�5      � 	 � RowDefinitions	 5      �� 5   "   62   �� 5   "   62   �� 5    "   62   �� 5!   "   62   �� 5"   "   62   �� 5#   "   62    5%      �� 5&   "   65   �� 5'   "   65   .+�5)      �� 
 ��Name$
 	BookCover��6$   $	��100��6P   $	��100��6]   $
��Left=�6i   $��Center=�6�   $��6��6�   $��0��6�   ��67   �� *cover+6�   �� 5*      $��2��6>   $��0��6K   $��6(�6[   $
��Bold"�6h   
�������$��Italic$�6�   $
��Wrap=�6�   $��60��6�   $��Center=�6�   $��Center=�6�   $��0,0,30,0q�6�   ��6(   �� *Name+6�   �� 5+      $��0��6>   $��1��6K   ��6(   �� *Name+6K   �� 5,      $��1��6C   $��1��6P   ��6(   �� *
category+6P   �� 5-      $��2��6@   $��1��6M   ��6(   �� *Author+6M   �� 5.      $��3��6D   $��1��6Q   ��6(   �� *
Age_rating+6Q   �� 5/      $��4��6@   $��1��6M   ��6(   �� *Price+6M   50      51      53      54      �� 56   
   -   5         ��Name$ 	SearchBar��56      $
��Left=�6%   $��23��6@   $��
637,24,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��145��6�   6�   �� 57   
   $&�� Введите название:��6   $
��Left=�6,   $��24��6G   $��	637,0,0,0q�6S   $	��Top=�6f   $	��145��6~   �� 58   
   -	   5        $ BasketButton��58      $��Корзина��6'   $
��Left=�69   $��33��6T   $��	10,52,0,0q�6`   $	��Top=�6s   $	��104��6�   ���	#FFD764646�   59      5:      