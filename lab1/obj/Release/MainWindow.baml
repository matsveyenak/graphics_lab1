   M S B A M L   `   `   `  ���� ?  ;lab1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab1lab1      lab1.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:lab1       � Title$  Color Converter��$	��450��$
��1200��.��� .+�� $
��Auto�����#FFF$	��Top=�$��Stretch=�$��10q� � ColumnDefinitions �� $��* ��� $��* ��� $��* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$��1�� �� TextAlignment$ Center=�$��25(�$��Regular"�$��pick a color��
���   �#  Xceed.Wpf.Toolkit.ColorPicker  -     Name$ colorPicker��$��1��$��1��$��Center=�$	��200��$��	0 15 0 50q��� $��0��$��2��$��Center=�$��Center=�._�� $
��Auto�� �� $��* � �� $
��Auto ��� $��* �.+��� $��0��$��1��$ Center=�$��30(�$
��Bold"�$	��XYZ��
���   ��� -    ��Name$ warning_textbox��$��1��$��1��$��10(�$��Regular"�$y�Hidden=�$~��xВыход за пределы диапазона RGB может привести к неточным значениям��
��� E���� $��1��$��2��$��Center=�._��� $��30(�$
��Bold"�$	��LAB��
���   ��� $��2��$��2��$��Center=�._��� $��30(�$
��Bold"�$	��HLS��
���   ��� $��0��$��3��._�� $
��Auto�����#FFF$	��Top=�$��Stretch=�$��
25 10 25 0q� �� $	��10* ��� $	��55* ��� $	��30* � �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Center=�$��0��$��0��$��20(�$��X��
���   ��� -    ��Name$ x_slider��$��1��$��0��$��Center=� � Minimum$ 0Q� � Maximum$ 95.047Q�	 �� AutoToolTipPlacement$	 TopLeft=��� -   
 ��Name$
 	x_textbox��$��Center=�$��2��$��0��$��20(�
���   �$��15q��� $��Center=�$��0��$��1��$��20(�$��Y��
���   ��� -   $ y_slider��$��1��$��1��$��Center=�$ 0Q�$	 100Q�$	 TopLeft=��� -   $
 	y_textbox��$��Center=�$��2��$��1��$��20(�
���   �$��15q��� $��Center=�$��0��$��2��$��20(�$��Z��
���   ��� -   $ z_slider��$��1��$��2��$��Center=�$ 0Q�$ 108.883Q�$	 TopLeft=��� -   $
 	z_textbox��$��Center=�$��2��$��2��$��20(�
���   �$��15q��� $��1��$��3��._�� $
��Auto��$	��Top=�$��Stretch=�$��
25 10 25 0q� �� $	��10* ��� $	��55* ��� $	��30* � �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Center=�$��0��$��0��$��20(�$��L��
���   ��� -	   $ l_slider��$��1��$��0��$��Center=�$ 0Q�$	 100Q�$	 TopLeft=��� -
   $
 	l_textbox��$��Center=�$��2��$��0��$��20(�
���   �$��15q��� $��Center=�$��0��$��1��$��20(�$��A��
���   ��� -   $ a_slider��$��1��$��1��$��Center=�$
 -128Q�$	 128Q�$	 TopLeft=��� -   $
 	a_textbox��$��Center=�$��2��$��1��$��20(�
���   �$��15q��� $��Center=�$��0��$��2��$��20(�$��B��
���   ��� -   $ b_slider��$��1��$��2��$��Center=�$
 -128Q�$	 128Q�$	 TopLeft=��� -   $
 	b_textbox��$��Center=�$��2��$��2��$��20(�
���   �$��15q��� $��2��$��3��._�� $
��Auto�����#FFF$	��Top=�$��Stretch=�$��
25 10 25 0q� �� $	��10* ��� $	��55* ��� $	��30* � �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��Center=�$��0��$��0��$��20(�$��H��
���   ��� -   $ h_slider��$��1��$��0��$��Center=�$ 0Q�$	 360Q�$	 TopLeft=��� -   $
 	h_textbox��$��Center=�$��2��$��0��$��20(�
���   �$��15q��� $��Center=�$��0��$��1��$��20(�$��L��
���   ��� -   $ hls_l_slider��$��1��$��1��$��Center=�$ 0Q�$	 100Q�$	 TopLeft=��� -   $
 hls_l_textbox��$��Center=�$��2��$��1��$��20(�
���   �$��15q��� $��Center=�$��0��$��2��$��20(�$��S��
���   ��� -   $ s_slider��$��1��$��2��$��Center=�$ 0Q�$	 100Q�$	 TopLeft=��� -   $
 	s_textbox��$��Center=�$��2��$��2��$��20(�
���   �$��15q�