// <copyright file="IKeyBoardButton.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

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
