   M S B A M L   `   `   `  ����I  ETestWpfCommand, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TestWpfCommandTestWpfCommand  5          TestWpfCommand.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TestWpfCommand     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��525��5	      $	��350��5
       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$# local:MainWindow.CleanCommand��5      5   B   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $
��File��6   .@�5      m�  m� Command$	 New��6   $	��New��6)   m� 5      $
 Open��6   $
��Open��6*   m� 5      $
 Save��6   $
��Save��6*   �� 5      m� 5      $ Close��6   $
��Exit��6+   5       m� 5!      $
��Edit��6   .@�5"      m� $	 Cut��6   $	��Cut��6)   m� 5#      $
 Copy��6   $
��Copy��6*   m� 5$      $ Paste��6   $��Paste��6+   �� 5%      m� 5&      $# local:MainWindow.CleanCommand��6   $��Очистить поле��6C   5'      5(      �� 5*   
   -   5        $
��Text��5+      $��1��5,       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5.      5/      50      51      