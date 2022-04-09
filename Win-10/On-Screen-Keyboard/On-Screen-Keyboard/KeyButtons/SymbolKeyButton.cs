/*
This work is licensed under the Creative Commons Attribution 4.0 International License. 
To view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/ or 
send a letter to Creative Commons, PO Box 1866, Mountain View, CA 94042, USA.

Creator : Ajey Joshi (ajey.joshi@gmail.com) 
*/

namespace On_Screen_Keyboard
{
   using System.Windows;
   using System.Windows.Controls;

   public class SymbolKeyButton : Button, IKeyBoardButton
   {
      public static readonly DependencyProperty DefaultKeyProperty = DependencyProperty.Register(
        "DefaultKey",
        typeof(string),
        typeof(SymbolKeyButton));

      public static readonly DependencyProperty DefaultKeyCodeProperty = DependencyProperty.Register(
        "DefaultKeyCode",
        typeof(string),
        typeof(SymbolKeyButton));

      public static readonly DependencyProperty ShiftPressedKeyProperty = DependencyProperty.Register(
        "ShiftPressedKey",
        typeof(string),
        typeof(SymbolKeyButton));

      public static readonly DependencyProperty ShiftPressedKeyCodeProperty = DependencyProperty.Register(
        "ShiftPressedKeyCode",
        typeof(string),
        typeof(SymbolKeyButton));

      public static readonly DependencyProperty ShiftPressedProperty = DependencyProperty.Register(
        "ShiftPressed",
        typeof(bool),
        typeof(SymbolKeyButton));

      public string DefaultKey
      {
         get => (string)this.GetValue(DefaultKeyProperty);
         set => this.SetValue(DefaultKeyProperty, value);
      }

      public string DefaultKeyCode
      {
         get => (string)this.GetValue(DefaultKeyCodeProperty);
         set => this.SetValue(DefaultKeyCodeProperty, value);
      }

      public string ShiftPressedKey
      {
         get => (string)this.GetValue(ShiftPressedKeyProperty);
         set => this.SetValue(ShiftPressedKeyProperty, value);
      }

      public string ShiftPressedKeyCode
      {
         get => (string)this.GetValue(ShiftPressedKeyCodeProperty);
         set => this.SetValue(ShiftPressedKeyCodeProperty, value);
      }

      public bool ShiftPressed
      {
         get => (bool)this.GetValue(ShiftPressedProperty);
         set => this.SetValue(ShiftPressedProperty, value);
      }

      public string GetKeyCode()
      {
         if (this.ShiftPressed == true)
         {
            return this.DefaultKeyCode;
         }
         else
         {
            return this.ShiftPressedKeyCode;
         }
      }

      public void UpdateShiftKeyStatus(bool state)
      {
         this.ShiftPressed = state;
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
