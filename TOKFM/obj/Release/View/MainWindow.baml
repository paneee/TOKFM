   M S B A M L   `   `   `  ���� T  PMahApps.Metro, Version=1.4.3.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  @ <TOKFM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TOKFM.ViewModelTOKFM.ViewModel clr-namespace:TOKFMTOKFM    TOKFM.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,vmclr-namespace:TOKFM.ViewModel     %localclr-namespace:TOKFM       � Title$  TOK FM��$	��648��$	��441�� � 
ResizeMode$ CanMinimize=� � DataContext   TOKFM.ViewModel.VModel   � 	Resources "  TOKFM.CapitalLetterConverter   CapitalFirstLetter  TOKFM.TrimStringConverter  
TrimString  TOKFM.NegatingConverter  NegatingConverter"  TOKFM.BoolToVisibleConverter  VisibleConverter#  TOKFM.FloatToProcentConverter  FloatConverter  SliderRepeatButton �� 
TargetType �� Property �� Value �� 
TargetType  SliderRepeatButton1 J� SnapsToDevicePixels  SliderThumb  Play 
	 Slider	 � RowDefinitions
 ]�Name ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton 
 Horizontal_Slider �� Triggers P� Property P� Value��%�  &	        &	      &	 
     &	      &	      &	      &	 �     &	 �    &	 $    &		 �    7  7  7  &	
 h    7 	           �� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� $��1q�
���   �
���   �$��8���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " ��.R���  . 
������$��8���� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� �� " n�.R�A� $��12��$��12��
��� � ��� $^��XC:\Users\Admin\Documents\Visual Studio 2015\Projects\TOKFM\TOKFM\AllOther\Image\play.png��$��50��$��50���� " ��.R�� 	 �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�]� $
 
PART_Track��$��1�� �� 8��  $��Slider.DecreaseLarge�� n� 8��  �� 8�� $��Slider.IncreaseLarge���� " ��.���  � |� .  ��  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle .  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$ 21����  � ��$	 104����  � ��8   .��� .+��� $
��Left=�
�����p�$��2q� �� Padding$ 2q�$��4,4,4,4q� �� CornerRadius$ 4��$	��608��$	��Top=�y���  �� Path$ BorderVisibility�._�� .+��� 
�����p�$��2q�$ 2q�$��5,5,5,0q�$ 4��$	��120��$	��Top=�y��� $ BorderVisibility�._�� $��0,0,0,-4q� � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �	 �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+���  �� RadiusX$ 4�� �� RadiusY$ 4��$��0��$��0��$��3��$��2��$��2,2,2,2q�����  j� Stretch$ UniformToFill=� �� ImageSource �� $ SelectedItem.Image��� $��0��$��3��$��8��
����d�$��Center=�$��WordEllipsis=�$��Center=�$��16(�$
��Bold"�$��22������ $ SelectedItem.Title��� #��[
 $��4��$��11�� � Maximum$	 100Q� � Minimum$ 0Q�$��Center=�$��	10,1,10,1q� �� AutoToolTipPlacement$ BottomRight=� �� AutoToolTipPrecision$ 2�� � Value �� *StreamPlayer.SliderPosition+ �� Mode$ TwoWay=��� $��8��$��1��$��2��$��3��$��Center=�$��28(�$
��Bold"�
������$��42��$	��110������ $ StreamPlayer.ActualTime� �� UpdateSourceTrigger$ PropertyChanged=��� $��3��$��0��$��P��
�����p�$��2q�$��8(�$��Center=�$��10,10,10,-0.9q�$��Center=����� *PlayCommand+�� $��3��$��1��$��P��
�����p�$��2q�$��8(�$��Center=�$��1,1,1,1q�$��Center=�$��30��$��8������ *PauseCommand+�� $��2��$��2��$��S��
�����p�$��2q�$��8(�$��Center=�$��4,22,3,0q�$��Center=�$��30��$��14��$��2������ *StopCommand+�� $��2��$��0��$��P��
�����p�$��2q�$��8(�$��Center=�$��3,0,3,23q�$��Bottom=�$��30��$��14��$��2������ *PlayCommand+�� $��2��$��1��$��P��
�����p�$��2q�$��8(�$��Center=�$��1,1,1,1q�$��Center=�$��30��$��8������ *PauseCommand+�� $��2��$��2��$��S��
�����p�$��2q�$��8(�$��Center=�$��1,1,1,1q�$��Center=�$��30��$��8������ *StopCommand+�� #��[
 $��3��$��4��$��8��$	 1.0Q�$ 0Q�$��	10,1,10,1q�$ BottomRight=�$ 2�� �� *Volume+�� $��45��$��1��$��3��$
��Wrap=�$
��Left=�$��WordEllipsis=�$��Center=�$��12(�
������$��0,4,0,0q�$��16��$��2������ $ Volume�  �� 	Converter#  [ �� $��
-2,134,0,4q����� $ ListItemsRss.Items�! �� SelectedItem! �� $ SelectedItem�$ PropertyChanged=�$ TwoWay=����� " ��.���  � ��
 ���� ��  � �� �� " ��.R��� ��  � z� �� scaleTransform�� P�  �@��
IsSelected . " N� EnterActions" �� .���� .��W� # �� TargetProperty$# RenderTransform.ScaleX�	$ W� To$	$ 0.8X�% g� Duration$% 0:0:.3D�& g� AutoReverse& . P�  �@J�IsMouseOver . . ���  �@�Cursor$
 Hand������ .R��� $
��Left=�$	��Top=�
�����p�$��2q�$ 2q�$��6,2,2,2q�$ 4��._��  �� $	��120 ��� $��* ��� $��* �	 �� $��20 ��� $��40 ��� $��20 �.+��� $ 4��$ 4��$��0��$��0��$��3��$��1,1,1,1q����� $ UniformToFill=� �� $ Image��� $	��260��$��0��$��1��$��2��$��10,1,1,1q�
����d�$
��Left=�$��WordEllipsis=�$	��Top=�$��14(����� $ Title��� $	��260��$��1��$��1��$��2��$��10,1,1,1q�
�������$
��Wrap=�$
��Left=�$��WordEllipsis=�$��Center=�$��12(����� $ Summary��� $��2��$��1��$��10,1,1,1q�
������$��12(�$��Bottom=�' �� TextAlignment$
' Left=����� $ TimePublish�#  [  ( �� ConverterCulture$( pl-PL���� $��2��$��2��$��1,1,1,1q�
������$��12(�$��Bottom=�$' Right=����� $ Duration��� -   ) ��Name$) label��$
��Left=�$��
457,73,0,0q�$	��Top=�* J� RenderTransformOrigin$* 1.132,-0.731&����� $ ItemSelected.TimePublish�)   #MahApps.Metro.Controls.ProgressRing  y��� $ ListItemsRssTemp.IsLoaded�$ PropertyChanged=�  y��� $ ListItemsRss.IsLoaded�$ PropertyChanged=�