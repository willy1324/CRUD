   M S B A M L   `   `   `  ����?  ;crud, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:crudcrud  5   	       crud.insertOrders   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:crud     5   	     � Title$  Insertar Pedidos��5   	   $	��450��6"   $	��500��6/    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � ���#171336 � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $	��160 �6   6-   �� 5      6!   .+�5   
   �� $��20(�6   ���#cfe2ee$��0��63   $��Cliente��6@   $��Center=�6R   $��Center=�6o   6�   �� 5   
   $��20(�6   ���#cfe2ee$��1��63   $��Articulo��6@   $��Center=�6S   $��Center=�6p   6�   �� 5   
   $��20(�6   ���#cfe2ee$��2��63   $��Fecha pedido��6@   $��Center=�6W   $��Center=�6t   6�   �� 5   
   $��20(�6   ���#cfe2ee$��3��63   $��
Forma Pago��6@   $��Center=�6U   $��Center=�6r   6�   �� 5   
   $��20(�6   ���#cfe2ee$��4��63   $��Cantidad��6@   $��Center=�6S   $��Center=�6p   6�   �� 5   
   -   5        $��
customerCb��5      $��20q�6T   $��0��6`   $��1��6m   6   �� 5    
   -   5        $��	articleCb��5       $��20q�6R   $��1��6^   $��1��6k   6}   �� 5!   
   -   5        $��orderDateTb��5!      $��20q�6%   $��2��61   $��1��6>   6P   �� 5"   
   -   5        $��methodOfPayTb��5"      $��20q�6'   $��3��63   $��1��6@   6R   �� 5#   
   -   5        $��
quantityTb��5#      $��20q�6$   $��4��60   $��1��6=   6O   �� 5%   
   -   5        $��	addButton��5%   _   $��15(�6   ���#cfe2ee���#171336���#cfe2ee$��80,0,0,0q�6�   $��5��6�   $��2��6�   $��Agregar Pedido��6�   $��70��6�   $	��140��6�   $
��Left=�6�   6  �� 5&   
   -   5        $��15(�5&      ���#cfe2ee���#171336���#cfe2ee$��0,0,80,0q�6t   $��5��6�   $��2��6�   $��Cancelar��6�   $��70��6�   $	��140��6�   $��Right=�6�   6�   5'      5)      