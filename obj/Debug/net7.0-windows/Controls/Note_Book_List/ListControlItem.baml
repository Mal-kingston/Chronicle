   M S B A M L   `   `   `  ????D  @Chronicle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Chronicle	Chronicle  5          Chronicle.ListControlItem   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Chronicle     5        ? 	Resources  5	       ?? 
TargetType   ListItem ?? Property ?? Value ?? 
TargetType ?? Padding J? Opacity ? ColumnDefinitions  
WhiteBrush  FontAwesomeSolid ?? Padding	 ?? 	Converter!   Chronicle.IconTypeConverter
 ?? FallbackValue  JostFont ?? Triggers P? Property P? Value  	BlueBrush ?? 
TargetName??%V  &	        7  7  7  7  7  7  ?? 5   
   " ??6   .?5      ??  ? ?? 5      ?? 5      " ??6&   .R?5      ?? 
?????? $??0q?6:   $
 8, 2q?6N   $
 0.75Q?6]   ._?5      ? $??2q?6#    5   "   ?? 5   &   $
??Auto ?67   ?? 5   &   $??* ?67   .+?5   "   ?? $
??Icon??6e   $??0??6,   8??  8?? $??Center=?5   ,   $??10, 0, 10, 0q?6G   $ 0q?6]   ??5   ,   ?? *Icon+	   $
 Notes??5   ]   ?? 5   "   $
??Text??6=   $??1??6,   8?? 8?? $??Center=?5   ,   $??0q?6G   $ 0q?6R   $??WordEllipsis=?6^   $??NoWrap=?6z   ??5   ,   ?? *
FileName+5   z   5!      5#       5%      P? 5&       ?@J?IsMouseOver$
 True??6=   . ?5'   "   ?? 8  $
 Icon??6b    ? ???? 5(   "   8  $
 Text??6b    ? ??5)      5,      5.      50      52      .??54      ?? #??[  6   55      