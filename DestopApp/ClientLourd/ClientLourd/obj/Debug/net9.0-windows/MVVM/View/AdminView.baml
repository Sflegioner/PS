   M S B A M L   `   `   `  ����F  BClientLourd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ClientLourd.MVVM.ViewClientLourd.MVVM.View  5      %    ClientLourd.MVVM.View.AdminView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:ClientLourd.MVVM.View     5      .��5	      � .+�5
   
   �   � RowDefinitions  5      �� 5      $��70 �6    �� 5      $��* �6    .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��200��6   ��6&   �� *SearchByNameText+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $	��200��6   ��6&   �� *SearchBySiteText+$ PropertyChanged=��� 5      $	��200��6   ��6&   �� *SearchByServiceText+$ PropertyChanged=��� 5      $
��🔍��6   �� 5      $��Create Salarie��6   ��62   �� *CreateSalarieCommand+�� 5      $��Create Site��6   ��6/   �� *CreateSiteCommand+�� 5      $��Create Service��6   ��62   �� *CreateServiceCommand+5      �� 5      $��1��6   $
��Auto=�6(   $��0 10  300 0q�6K   $	��590��6`   ���#8e9aaf.��5      �� ��6   �� *ListSalaries+��5      �� 5      .R�5      � $��Stretch=�6(   5      ��5!      �� 5"      .R�5#      �� $��10q�6%   
������� �� CornerRadius$ 10��6D   $	��200��6V   $	��320��6e   $	��140��6t   ���#D1D5DB$��2q�5$   ;      DropShadowEffect J� Effect# �   5%   %   ._�5&   "   �� $��Center=�6-   $��Center=�6J   .+�5(   &   �� $��20(�6D   $
��Bold"�6R   
����  � �� TextAlignment$ Center=�6z   ��60   �� *Id+6z   �� 5*   &   $��16(�6E   $��SemiBold"�6S   ���#374151��60   �� *Nom+6i   �� 5+   &   $��14(�6H   ���#4B5563��60   �� *Prenom+6V   �� 5,   &   $��14(�6J   ���#6B7280��60   �� *
siteName+6X   �� 5-   &   $��14(�6M   ���#6B7280��60   �� *serviceName+6[   �� 5/   &   $ 
Horizontal=�61   $��Center=�6J   $��5 0 0 5q�6h   .+�50   *   �� $��Delete��61   
�������$��80��6U   $��30��6`   ��52   1   �� *" DataContext.DeleteSalarieCommand+ �� RelativeSource ��  �� AncestorType UserControl��53   1   �� �� 55   *   $��Update��61   
�������$��80��6U   $��30��6`   ��56   1   �� *" DataContext.UpdateSalarieCommand+ ��  UserControl��57   1   �� 58   '   59   #   5:      5;      5=      5>      5?      �� 5A   
   $	��300��6   $	��870��6#   $
��Auto=�5B      $��Disabled=�5C      $��
600,80,0,0q�5D      .��5E      �� 
���   �.+�5F   
   �� $��Create Salarie��6   
�������6*   �� 5G   
   ��6   �� *Salarie.Nom+$ PropertyChanged=��� 5H   
   ��6   �� *Salarie.Prenom+$ PropertyChanged=��� 5I   
   ��6   �� *Salarie.TelephoneFixe+$ PropertyChanged=��� 5J   
   ��6   �� *Salarie.TelephonePortable+$ PropertyChanged=��� 5K   
   ��6   �� *Salarie.Email+$ PropertyChanged=��� 5M   
    �� DisplayMemberPath$ SiteName��5O      	 �� SelectedValuePath$	 Id��5P      ��5M      �� *Sites+
 �� SelectedValue
 5N      �� *Salarie.siteId+$ PropertyChanged=�5P      �� 5R   
   $ ServiceName��5T      $	 Id��5U      ��5R      �� *
Services+
 5S      �� *Salarie.serviceId+$ PropertyChanged=�5U      �� 5W   
   $��Create��6:   ��6   �� *CreateSalarieCommand+6:   �� 5Y   
   $��5q�6   �� 5Z   
   $��Create Site��6   
�������6'   �� 5[   
   $��5q�6   �� 5]   
   $��5,0,5,0q�6V   ��6   �� *Site.SiteName+$ PropertyChanged=�6V   �� 5^   
   $��5,0,5,0q�67   $��Create��6H   ��6   �� *CreateSiteCommand+6H   �� 5_   
   $��5,0,5,0q�67   $��Delete��6H   ��6   �� *DeleteSiteCommand+6H   �� 5`   
   $��Old Site Name:��6   
�������$��5,0,5,0q�6=   �� 5a   
   $��5q�6T   ��6   �� *OldSiteName+$ PropertyChanged=�6T   �� 5b   
   $��New Site Name:��6   
�������$��5,0,5,0q�6=   �� 5c   
   $��5q�6T   ��6   �� *NewSiteName+$ PropertyChanged=�6T   �� 5d   
   $��Update��67   $��5q�6H   ��6   �� *UpdateSiteCommand+6H   �� 5f   
   $��Create Service��6   
�������6*   �� 5g   
   $��5q�6\   ��6   �� *Service.ServiceName+$ PropertyChanged=�6\   �� 5h   
   $��5q�6:   $��Create��6E   ��6   �� *CreateServiceCommand+6E   �� 5i   
   $��5q�6:   $��Delete��6E   ��6   �� *DeleteServiceCommand+6E   �� 5j   
   $��Update Service��6   
�������$��5q�6=   �� 5k   
   $��Old Service Name:��6   
�������$��5,0,5,0q�6@   �� 5l   
   $��5q�6W   ��6   �� *OldServiceName+$ PropertyChanged=�6W   �� 5m   
   $��New Service Name:��6   
�������$��5,0,5,0q�6@   �� 5n   
   $��5q�6W   ��6   �� *NewServiceName+$ PropertyChanged=�6W   �� 5o   
   $��Update��6:   $��5q�6K   ��6   �� *UpdateServiceCommand+6K   5p      5q      5s      5t      