   M S B A M L   `   `   `  ���� A  =DiaryU, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DiaryUDiaryU      DiaryU.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:DiaryU       � Title$  DairyU��$	��562��$	��737�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FF454E76��� $ 	#FF2C2C2C�� � Offset$ 1Q�.��� $��0,0,4,3q� � ColumnDefinitions 	 � RowDefinitions	 �� �� $��0* �.+�&   System.Windows.Controls.Calendar  $
��Left=�$	��Top=�$	��168��$	��194��$��0,27,0,0q����	#FF84A4CB$��2q��� -   $��/Source/ExitCross.png��$��710,8,8,536q�$��15��$��15��
 J� Opacity$	
 0.8Q� J� OpacityMask �	#FF3BAA64�  � Points) �   @��@���� @_���� @qn$	
 0.8Q����	#FF84A4CB$��2��$��	0,0,185,0q����	#FFAFB7FF�� -    ��Name$ TextBoxContent1��$
��Left=�$	��518��$��
199,31,0,0q�$	��Top=�$	��275�� �� TextWrapping$
 Wrap=����	#FFAFB7FF$��2q�.������  �� Color$ White�� �� Opacity$	 0.5Q�.���� $
��Left=�$	��491��$��
471,68,0,0q�$	��Top=�$	��262��.+��� -   $(��"Создать новую тему�� �� Left$ 10��$	��127��$��32��
���   ����	#FFAFB7FF���	#FF84A4CB$��2q��� -   $��Удалить тему��$	 174��$��83��$��32�����	#FFAFB7FF���	#FF84A4CB$��2q��� -    ��Name$ StackPanelUs��$	��438��$ 10��
 �� Top$ 46��$	��252������ $ 	#FFAC93FF��$	 0.2Q�.+��� $%��Общая информация��$��28�����	#FFAFB7FF���	#FF84A4CB$��2q��� -   $ StackPanelDaily��$
��Left=�$	��281��$��	0,268,0,0q�$	��Top=�$	��194������ $ 	#FFAC93FF��$	 0.2Q��� -   $��Тема на день��$
��Left=�$��21��$��	5,234,0,0q�$	��Top=�$��99�����	#FFAFB7FF���	#FF84A4CB$��2q��� -   $��Удалить��$
��Left=�$��133,234,0,0q�$	��Top=�$��61��$��21�����	#FFAFB7FF���	#FF84A4CB$��2q�(  "System.Windows.Controls.DatePicker  -	     Name$ DataPicker1��$
��Left=�$	��Top=�$��34��$	��189��$��	5,195,0,0q�   IsTodayHighlighted . ���� $ 0.5,0&�$ 0.5,1&�.��� $ 	#FFA3AEB9��$ 0Q�� $ 	#FF8399A9��$ 0.375Q�� $ 	#FF718597��$ 0.375Q�� $ 	#FF84A4CB��$ 1Q�