// <copyright file="SingleOperationKeyButton.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace On_Screen_Keyboard
{
   using System.Windows;
   using System.Windows.Controls;

   public class SingleOperationKeyButton : Button, IKeyBoardButton
   {
      public static readonly DependencyProperty KeyCodeProperty = DependencyProperty.Register(
        "KeyCode",
        typeof(string),
        typeof(SingleOperationKeyButton));

      public string KeyCode
      {
         get => (string)this.GetValue(KeyCodeProperty);
         set => this.SetValue(KeyCodeProperty, value);
      }

      public string GetKeyCode()
      {
         return this.KeyCode;
      }

      public void UpdateShiftKeyStatus(bool state)
      {
         return;
      }

      public void UpdateFunctionKeyStatus(bool state)
      {
         return;
      }

      public void UpdateCapsLockKeyStatus(bool state)
      {
         return;
      }
   }
}
