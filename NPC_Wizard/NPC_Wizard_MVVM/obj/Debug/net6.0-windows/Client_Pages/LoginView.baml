   M S B A M L   `   `   `  ����J  FNPC_Wizard_MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:NPC_Wizard_MVVM.Client_PagesNPC_Wizard_MVVM.Client_Pages  5      G(clr-namespace:NPC_Wizard_MVVM.viewModelsNPC_Wizard_MVVM.viewModels  6@   ,    &NPC_Wizard_MVVM.Client_Pages.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:NPC_Wizard_MVVM.Client_Pages     5      ?
viewmodels(clr-namespace:NPC_Wizard_MVVM.viewModels     6@     � 	Resources  5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType ��Name	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName��%&  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $ border��6!   #��z��61   #��z��6[   #��z��6�   $
 true��6�   ._�5)      �� $	 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*      
 5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?    � �� �#7D6D506S   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?    � �� �#7D6D506S   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8   � ��6i   5;      5=      5?      5@      5A      .��5D      � ���#f2d49b K� ZIndex$ -1��6    $��Center=�62   $��Center=�6O   $��10,10q�6j   $	��518��6y   $	��908��6�    � RowDefinitions 5F   
   �� 5G      $��* �6   �� 5H      $
��auto �6   .+�5M   
   �� $	��158��6   $��295,105,295,0q�6   $	��Top=�64   $!��/Assets/NPC_Wizard_Logo.png��6L    J� RenderTransformOrigin$ 1.103,0.521&�6q   �� 5N   
   -   5         ��Name$ 
LogInInput��5N      $��36��6&   $��314,280,314,0q�62    �� TextWrapping$
 Wrap=�6I   $	��Top=�6^   $��24(�6v   $��Stretch=�6�   $��Normal"�6�    � Cursor$ Arrow��6�    �� MaxLines$ 1��6�   �� 5Q   
   -   5         ��Name$ LogIn��5Q   8   #��� 
 6   $��0q�6G   $��330,364,330,114q�6q   2   ,NPC_Wizard_MVVM.viewModels.MainMenuViewModel"�� 6  ��6[   Z�  � DataContext 6�   �� *DataContext+ �� RelativeSource ��  �� AncestorType" ���6�   �� *UpdateViewCommand+��5S      �� 5T      -   5         ��Name$ 
Log_In_Img��5T      $��/Assets/Button_LogIN.png��6,   5V      5Z      5[      