   M S B A M L   `   `   `  ����H  DStudyGuideApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:StudyGuideAppStudyGuideApp  5   	   (    "StudyGuideApp.ModuleCalendarWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:StudyGuideApp     5   	     � Title$  Module Calendar��5   	   $	��450��6!   $	��883��6.    � 
ResizeMode$ NoResize=�6:    � WindowStartupLocation$ CenterScreen=�6P   .��5
      � ��5   
   �� 5      -   5        backgroundImg�� �� ImageSource$- '/StudyGuideApp;component/Images/wp6.jpg��5   0   6i   .+�5   
   (� $��226,0,225,0q�6   .��5      &   System.Windows.Controls.Calendar  -   5          Name$ ModuleCalendar��5      ���	#FFDCB8B8���	#FFFFF2F2��5      �� 5      5      5      �� 5   
   -   5         ��Name$ returnButton��5      $��RETURN TO DASHBOARD��6'   $��17(�6E   $��Light"�6S   
���**��
�������$
��Left=�6�   $��	10,14,0,0q�6�   $	��Top=�6�   $��34��6�   $	��211��6�   �� 5   
   -   5         ��Name$ ModuleInfoTxtBox��5      
�������$��15(�6C   
���**��$
��Bold"�6d   $��Italic$�6v   $��30,53,643,37q�6�   . �5      /� .T�5      J� .*�6   5      5      5       �� 5"   
   -   5        $ weklyStdHrsTxtBox��5"      $��15(�61   
�������
���**��$
��Bold"�6e   $��Italic$�6w   $��644,114,23,50q�6�   . �5#      /� .T�5$      J�  �� 
LineHeight$ 16��6   .*�6,   5&      5'      5(      �� 5)   
   -   5        $ datesStudiedButton��5)      $��DAYS STUDIED LIST��6-   $��17(�6I   $��Light"�6W   
���**��
�������$
��Left=�6�   $��
658,24,0,0q�6�   $	��Top=�6�   $��34��6�   $	��164��6  �� 5*   
   -   5         ��Name$ textBox��5*      $
��Left=�6#   $��
658,58,0,0q�6>   	 �� TextWrapping$
	 Wrap=�6R   $��15(�6f   $y�Hidden=�6t   $	��Top=�6�   $	��184��6�   $	��310��6�   �� 5+   
   -   5        $ closeStudiedButton��5+      $��CLOSE STUDY LIST��6-   $��17(�6H   $��Light"�6V   $y�Hidden=�6i   
���**��
�������$
��Left=�6�   $��658,373,0,0q�6�   $	��Top=�6�   $��34��6  $	��164��6  5,      5-      