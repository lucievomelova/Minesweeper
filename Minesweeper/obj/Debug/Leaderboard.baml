   M S B A M L   `   `   `  ����F  BMinesweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MinesweeperMinesweeper  5   	       Minesweeper.Leaderboard   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   +localclr-namespace:Minesweeper     5   	     � Title$  Leaderboard��5   	   $	��450��6   $	��600��6*   .��5	      � .+�5
   
   �� $��Center=�6   .+�5      ]� $��10q�6   $��Center=�6$   .+�5      �� .��6   Select difficulty:6-   �� 5      -   5         ��Name$ DifficultyComboBox��5      $	��200��67   .@�5      �� -   5        $��BeginnerOption��5   #   .��69   
Beginner6C   �� 5      -   5        $��IntermediateOption��5   #   .��6=   Intermediate6K   �� 5      -   5        $��ExpertOption��5   #    �� 
IsSelected . .��6J   Expert6R   5      �� 5      -   5        $��OK��5      $��50��6?   $��10, 0, 0, 0q�5      60   5      ]� 5      $	��500��6   $	��300��6$   .+�5      �� $��1q�6   
���   �$	��Top=�6A   ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ LeaderboardTable��5         AutoGenerateColumns .  $	��300��6U   $	��500��6b      
IsReadOnly .    AlternatingRowBackground
 �����   RowBackground
 �����$��0q�5         CanUserResizeColumns .  	   CanUserResizeRows	 .  
   CanUserAddRows
 .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserSortColumns .     HeadersVisibility$ Column=�5   :      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Place��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   ��  �� Path$ Place�  5      $ Player��61   $ * 6A    6K   �� $
 Name�  5      $
 Time��61   $	 100 6?    6K   �� $
 Time� � 	Resources 5!      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%�   '        7 �� 5"      8   "  5#       .�5$   "   ��  � ��
 �����6N   �� 5%   "    � ��
 �   �6P   �� 5&   "    � ��$ 1q�6D   6P   �� 5'   "    � ��$ 30��6;   6H   5)      5*      5+      5,      5-      5.      5/      50      