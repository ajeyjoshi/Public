// <copyright file="StateKeyButton.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace On_Screen_Keyboard
{
   using System.Windows;
   using System.Windows.Controls;

   public class StateKeyButton : Button, IKeyBoardButton
   {
      public static readonly DependencyProperty PressedProperty = DependencyProperty.Register(
        "Pressed",
        typeof(bool),
        typeof(StateKeyButton));

      public bool Pressed
      {
         get => (bool)this.GetValue(PressedProperty);
         set => this.SetValue(PressedProperty, value);
      }

      public string GetKeyCode()
      {
         return string.Empty;
      }

      public void UpdateCapsLockKeyStatus(bool state)
      {
         return;
      }

      public void UpdateFunctionKeyStatus(bool state)
      {
         return;
      }

      public void UpdateShiftKeyStatus(bool state)
      {
         return;
      }
   }
}
