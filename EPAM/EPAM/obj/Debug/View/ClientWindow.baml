   M S B A M L   `   `   `  ����  EPAM.WPF_Client    EPAM.View.ClientWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  window��5   	    � Title$ ClientWindow��5   	   $	��350��6   $	��550��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��
10 10 10 5q�6"    �� Orientation$ 
Horizontal=�66    � 	Resources 5       �� 
TargetType 
  tgBase �� BasedOn��%0   'd�       7   �� 5      " d�6   8   62   5      .+�5      d� -   5        $
��Jobs��5       d� 	IsChecked 6>   �� *IsJobs+d� 5      -   5        $��Freelancers��5       6E   �� *IsFreelancers+d� 5      -   5        $��Talks��5       6?   �� *	IsTalks+d� 5      -   5        $��Profile��5       6A   �� *	IsProfile+5      �� 5   
   $��1��6   $��
10 5 10 10q�6$   $
��Auto=�68   ��6[   �� *	CurrentUC+5      5      