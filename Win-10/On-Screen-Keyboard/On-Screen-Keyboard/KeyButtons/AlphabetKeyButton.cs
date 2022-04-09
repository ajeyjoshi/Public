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

   public class AlphabetKeyButton : Button, IKeyBoardButton
   {
      public static readonly DependencyProperty LowercaseProperty = DependencyProperty.Register(
        "Lowercase",
        typeof(string),
        typeof(AlphabetKeyButton));

      public static readonly DependencyProperty UppercaseProperty = DependencyProperty.Register(
        "Uppercase",
        typeof(string),
        typeof(AlphabetKeyButton));

      public static readonly DependencyProperty KeyLetterToShowProperty = DependencyProperty.Register(
        "KeyLetterToShow",
        typeof(string),
        typeof(AlphabetKeyButton));

      private bool shiftPressed;
      private bool capsLockOn;

      public string Lowercase
      {
         get => (string)this.GetValue(LowercaseProperty);
         set => this.SetValue(LowercaseProperty, value);
      }

      public string Uppercase
      {
         get => (string)this.GetValue(UppercaseProperty);
         set => this.SetValue(UppercaseProperty, value);
      }

      public string KeyLetterToShow
      {
         get => (string)this.GetValue(KeyLetterToShowProperty);
         set => this.SetValue(KeyLetterToShowProperty, value);
      }

      public bool ShiftPressed
      {
         get => this.shiftPressed;

         set
         {
            this.shiftPressed = value;
            this.UpdateKeyLetterToShow();
         }
      }

      public bool CapsLockOn
      {
         get => this.capsLockOn;

         set
         {
            this.capsLockOn = value;
            this.UpdateKeyLetterToShow();
         }
      }

      public string GetKeyCode()
      {
         if (this.CapsLockOn)
         {
            return this.Uppercase;
         }

         return this.Lowercase;
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
         this.CapsLockOn = state;
      }

      private void UpdateKeyLetterToShow()
      {
         if ((this.CapsLockOn && this.ShiftPressed) || (!this.CapsLockOn && !this.ShiftPressed))
         {
            this.KeyLetterToShow = this.Lowercase;
         }
         else
         {
            this.KeyLetterToShow = this.Uppercase;
         }
      }
   }
}
