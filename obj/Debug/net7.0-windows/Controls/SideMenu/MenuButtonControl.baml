   M S B A M L   `   `   `  ????D  @Chronicle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Chronicle	Chronicle  5      !    Chronicle.MenuButtonControl   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Chronicle     5        ? 	Resources  5
         
MenuButton ?? 
TargetType ?? Property ?? Value  	GrayBrush 	 Small ?? 
TargetType ?? Padding ? ColumnDefinitions ??Name  FontAwesomeSolid ?? 	Converter!   Chronicle.IconTypeConverter  JostFont	 ?? Triggers
 P? Property P? Value  	BlueBrush??%?  &	        7  7  7  7  7  7  ?? 5   
   " ??6#   .?5      ??  ? ??
 ???? 6+   ?? 5       ? ??8   6+   ?? 5       ? ??8  6)   ?? 5       ? ??$ 40??6'   ?? 5       ? ??$	 270??6&   ?? 5       ? ?? 5      ?? 5      " ??6&   .R?5      ?? #??z??6!   $??0q?6K   $
 8, 2q?6_   ._?5      ?  5   "   ?? 5   &   $??45 ?67   ?? 5   &   $??* ?67   .+?5    "   ?? $
 Icon??5!   ,   $??0??5    ,   8?? $??Center=?5$   ,   $??50, 0, -50, 0q?6G   ??5"   ,   ?? *
MenuIcon+   5$   G   ?? 5&   "   $ Title??5'   ,   $??1??5&   ,   8?? $??Center=?5*   ,   $??50, 0, 0, 0q?6G   ??5(   ,   ?? *	MenuTitle+5*   G   5+      5-      	 5/      P? 51      
 ?@J?IsMouseOver$
 True??6=   . ?52   "   ?? 8   ? ??6?   ?? 53   "   8   ? ??6?   54      57      59      5:      5;      .??5=      ??  ?? Orientation$ Vertical=?6   .+?5>   
   ?? #??[  6    J? InputBindings 5?      d? 5@       d? MouseAction$ 	LeftClicke?6?    ?? Command 6   ?? *MenuCommand+6?   5B      5E      5G      