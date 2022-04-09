﻿/*
This work is licensed under the Creative Commons Attribution 4.0 International License. 
To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/ or 
send a letter to Creative Commons, PO Box 1866, Mountain View, CA 94042, USA.

Creator : Ajey Joshi (ajey.joshi@gmail.com) 
*/

namespace On_Screen_Keyboard
{
   using System.Windows;

   internal interface IKeyBoardButton
   {
      event RoutedEventHandler Click;

      string GetKeyCode();

      void UpdateShiftKeyStatus(bool state);

      void UpdateFunctionKeyStatus(bool state);

      void UpdateCapsLockKeyStatus(bool state);
   }
}
