   M S B A M L   `   `   `  ���� F  BMinesweeper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MinesweeperMinesweeper      Minesweeper.Leaderboard   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     +localclr-namespace:Minesweeper       � Title$  Leaderboard��$	��450��$	��600��.��� .+��� $��Center=�.+�]� $��10q�$��Center=�.+��� .��Select difficulty:�� -    ��Name$ DifficultyComboBox��$	��200��.@��� -   $��BeginnerOption��.��
Beginner�� -   $��IntermediateOption��.��Intermediate�� -   $��ExpertOption�� �� 
IsSelected . .��Expert�� -   $��OK��$��50��$��10, 0, 0, 0q�]� $	��500��$	��300��.+��� $��1q�
���   �$	��Top=�._�&   System.Windows.Controls.DataGrid  -     Name$ LeaderboardTable��   AutoGenerateColumns .  $	��300��$	��500��   
IsReadOnly .    AlternatingRowBackground
 �����   RowBackground
 �����$��0q�   CanUserResizeColumns .  	   CanUserResizeRows	 .  
   CanUserAddRows
 .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserSortColumns .     HeadersVisibility$ Column=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Place��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ Place�  $ Player��$ *  �� $
 Name�  $
 Time��$	 100  �� $
 Time� � 	Resources =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn �� 
TargetType �� Property �� Value��%{   '        7 �� 8   "  .���  � ��
 �������  � ��
 �   ���  � ��$ 1q���  � ��$ 30��