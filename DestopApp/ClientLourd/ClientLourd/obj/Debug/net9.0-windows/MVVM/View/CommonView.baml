   M S B A M L   `   `   `  ����F  BClientLourd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ClientLourd.MVVM.ViewClientLourd.MVVM.View  5      &     ClientLourd.MVVM.View.CommonView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ClientLourd.MVVM.View     5        � DataContext  5	      �� *CommonViewModel+.��5
      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��200��6   ��6&   �� *SearchByNameText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $	��200��6   ��6&   �� *SearchBySiteText+$ PropertyChanged=��� 5      $	��200��6   ��6&   �� *SearchByServiceText+$ PropertyChanged=��� 5      -   5        $
��🔍��5      6&   5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �� ��6   �� *ListSalaries+��5      �� 5      .R�5      � $��Stretch=�6$   5      ��5       �� 5!      .R�5"      �� -   5        $��10q�5"   !   
������� �� CornerRadius$ 10��6D   $	��150��5#   !   $	��200��60   $	��200��6?   ._�5%      ��  �� Padding$ 20q�6%   
�������$��2q�6E   $ 10��6Y   ._�5&   "   �� $��Center=�6-   $��Center=�6J   .+�5'   &   �� $��Client:��60   $��20(�6?   $
��Bold"�6M   
���   �$��0 0 0 10q�6r   � 5)   &    � ColumnDefinitions 5*   *   �� 5+   .   $
��Auto �6?   �� 5,   .   $��10 �6?   �� 5-   .   $��* �6?   .+�50   *   �� $��0��65   .+�51   .   �� $��Nom client:��68   $��SemiBold"�6K   �� 52   .   $��Prénom client:��68   $��SemiBold"�6N   �� 53   .   $��Site:��68   $��SemiBold"�6E   �� 54   .   $��Service:��68   $��SemiBold"�6H   55   +   �� 57   *   $��2��65   .+�58   .   �� $��18(�6M   
���   ���68   �� *Nom+6[   �� 59   .   $��16(�6P   
���   ���68   �� *Prenom+6_   �� 5:   .   $��16(�6R   
���   ���68   �� *
siteName+6`   �� 5;   .   $��16(�6U   
���   ���68   �� *serviceName+6c   5<   +   5=   '   5>   #   5?      5@      5A      5C      5D      5E      5F      