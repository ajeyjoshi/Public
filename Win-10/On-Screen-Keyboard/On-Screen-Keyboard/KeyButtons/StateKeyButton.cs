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
