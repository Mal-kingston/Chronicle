   M S B A M L   `   `   `  ????D  @Chronicle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Chronicle	Chronicle  5   	       Chronicle.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Chronicle     5   	   -   5          ?Name$
  Main??5	   	   $	??800??5
   	   $
??1082??6    ? Icon$) #.resources/icons/chronicle_icon.ico??5   	   ??5   	   ?? *MinimumHeight+??5   	   ?? *MinimumWidth+.??5      ?    LightDarkBrush#??[  6    ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6     	GrayBrush#??[ 5      $??
0, 0, 1, 0q?6:     	DarkBrush#??[ 5      ._?5      ?  ? RowDefinitions 5       ?? 5"      $	??100 ?6$   ?? 5$      $
??Auto ?6$   .+?5.      ? -   5         ?Name$ AppTitle??5/      $??0??5.      .+?50      ?? $??Center=?6    $??Center=?6=     
WhiteBrush#??[ 51       $??-20, 5, 5, 5q?6I    J? Effect 52      3  -System.Windows.Media.Effects.DropShadowEffect  53         
BlurRadius$ 25Q?6/     Blue   Color# [ 6?      ShadowDepth$ 0Q?6]   ?? 55        	PlaneIcon#?[ 6     FontAwesomeSolid#??[ 6@    	 Large#??[ 6o    ?? 56      $?
 Chronicle??6     JostFont#??[ 60    
	 XLarge#??[	 6W   57      58      ? 5;      -   5        $ SideMenu??5<      $??1??5;      .+?5=      '   !Chronicle.MenuButtonParentControl  5>      5@      5A      ? 5D   
   $??1??6    5E      ?? 5F      $
??Auto ?6    ?? 5G      $??* ?6    .+?5K      ?? $??0??6   $??20, 0q?6&   	 ?? Orientation$	 
Horizontal=?5L      $??Right=?62   .+?5O      ?? #??[ 6   $	??600??6A   $??30??6M   $??30, 30, 0, 0q?6Y   ._?5P      ? $??20, 4q?6   .+?5R      ?? $??Search??6$   #??[ 62   $
??Left=?6Z   $??Center=?6u    	
 Small#??[
 5S   !   #??[ 6C   ?? 5T        SearchButtonIcon#??[ 6$   $??Right=?6M   $??Center=?6i   #??[ 5U   !   #??[ 6I   5V      5W      ?? 5Z      #??[ 6   $??30??6A   $??30??6L   $??20, 30, 0, 0q?6X   ._?5\      ??   NotificationButtonIcon#??[ 6    $??Center=?6O   $??Center=?6l   #??[ 5]   !   #??[ 6I   5^      ?? 5a      #??[ 6   $	??100??5b      $??30??6!   $??20, 30, 0, 0q?6-   ._?5d      ? $
??6, 0q?6   .+?5f      ?? $??Heather??6$   #??[ 63   $
??Left=?6[   $??Center=?6v   #??[
 5g   !   #??[ 6C   ?? 5i        UserButtonIcon#??[ 6$   $??Right=?6K   $??Center=?6g   #??[
 6?   #??[ 5j   !   #??[ 6I   5l      5n      5p      ?? 5s      $??1??6   $??0, 15, 0, 0q?6"   ._?5t       ? ?   ?Chronicle.BaseAttachedProperty`2[[Chronicle.NoFrameHistoryAttachedProperty, Chronicle, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null],[System.Boolean, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]
   Value$

 True??6   ??5u      ?? *Application.CurrentPage+    Chronicle.ViewModelLocator   Instance ?? Source# Z  ?? 	Converter "   Chronicle.PageValueConverter  5v      5x      5y      5z      