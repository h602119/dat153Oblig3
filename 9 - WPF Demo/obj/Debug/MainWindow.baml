   M S B A M L   `   `   `  ����G  C8 - WPF Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:_8___WPF_Demo_8___WPF_Demo  5   	       _8___WPF_Demo.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:_8___WPF_Demo     5   	     � Title$  Student Side��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� -   5        $��studentList��5
      $��	0,66,10,0q�6>   ��6&   ��  �� View 5      �� 5      P�5      �� 5       �� Width$	 100��6)   $��Student��65    �� DisplayMemberBinding 6F   ��  �� Path$ studentname�6z   �� 5      $	 100��6)   $��ID��65    6A   �� $ id�6l   �� 5      $	 100��6)   $	��Age��65    6B   �� $ 
studentage�6u   �� 5      $	 100��6)   $��Course��65    6E   �� $ 
tempCourse�6x   �� 5      $	 100��6)   $��Grade��65    6D   �� $ 	tempGrade�6v   5      5      �� 5   
   -   5        $��SearchField��5      $
��Left=�6%   $��23��6@   $��
118,21,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   -   5        $��SearchButton��5      $��Search��6%   $
��Left=�66   $��
255,23,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $��AddStudButton��5      $��Edit Student��6&   $
��Left=�6=   $��7,6,0,0q�6X   $	��Top=�6i   $��75��6�   6�   �� 5   
   -   5        $��FailedButton��5      $��Failed Students��6%   $
��Left=�6?   $��
693,19,0,0q�6Z   $	��Top=�6n   $��88��6�   6�   �� 5   
   -   5        $��EditCourseButton��5      $��Edit Course��6)   $
��Left=�6?   $��7,38,0,0q�6Z   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $��
courseList��5      $
��Left=�6f   $��
383,30,0,0q�6�   $	��Top=�6�   $	��120��6�   ��6%   ��  �� SelectedItem 6=   �� $ 
coursename�6�   �� 5   
   -   5        $��	gradeList��5      $
��Left=�6b   $��
535,29,0,0q�6}   $	��Top=�6�   $	��120��6�   ��6$   ��  6<   �� $ grade1�6�   �� 5    
   $
��Left=�6   $��	384,9,0,0q�6/   $
��Wrap=�6B   $��Course:��6V   $	��Top=�6e   $��43��6}   �� 5!   
   $
��Left=�6   $��	536,8,0,0q�6/   $
��Wrap=�6B   $��Grade:��6V   $	��Top=�6d   5#      5$      