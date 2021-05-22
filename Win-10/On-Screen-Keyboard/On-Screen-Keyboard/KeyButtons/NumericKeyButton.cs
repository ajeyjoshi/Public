// <copyright file="NumericKeyButton.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace On_Screen_Keyboard
{
   using System.Windows;
   using System.Windows.Controls;

   public class NumericKeyButton : Button, IKeyBoardButton
   {
      public static readonly DependencyProperty NumberKeyProperty = DependencyProperty.Register(
        "NumberKey",
        typeof(string),
        typeof(NumericKeyButton));

      public static readonly DependencyProperty SpecialSymbolProperty = DependencyProperty.Register(
        "SpecialSymbol",
        typeof(string),
        typeof(NumericKeyButton));

      public static readonly DependencyProperty NumberKeyCodeProperty = DependencyProperty.Register(
        "NumberKeyCode",
        typeof(string),
        typeof(NumericKeyButton));

      public static readonly DependencyProperty SpecialSymbolCodeProperty = DependencyProperty.Register(
        "SpecialSymbolCode",
        typeof(string),
        typeof(NumericKeyButton));

      public static readonly DependencyProperty FunctionKeyProperty = DependencyProperty.Register(
       "FunctionKey",
       typeof(string),
       typeof(NumericKeyButton));

      public static readonly DependencyProperty FunctionKeyCodeProperty = DependencyProperty.Register(
        "FunctionKeyCode",
        typeof(string),
        typeof(NumericKeyButton));

      public static readonly DependencyProperty ShiftPressedProperty = DependencyProperty.Register(
        "ShiftPressed",
        typeof(bool),
        typeof(NumericKeyButton));

      public static readonly DependencyProperty FnKeyPressedProperty = DependencyProperty.Register(
        "FnKeyPressed",
        typeof(bool),
        typeof(NumericKeyButton));

      public string NumberKey
      {
         get => (string)this.GetValue(NumberKeyProperty);
         set => this.SetValue(NumberKeyProperty, value);
      }

      public string NumberKeyCode
      {
         get => (string)this.GetValue(NumberKeyCodeProperty);
         set => this.SetValue(NumberKeyCodeProperty, value);
      }

      public string SpecialSymbol
      {
         get => (string)this.GetValue(SpecialSymbolProperty);
         set => this.SetValue(SpecialSymbolProperty, value);
      }

      public string SpecialSymbolCode
      {
         get => (string)this.GetValue(SpecialSymbolCodeProperty);
         set => this.SetValue(SpecialSymbolCodeProperty, value);
      }

      public string FunctionKey
      {
         get => (string)this.GetValue(FunctionKeyProperty);
         set => this.SetValue(FunctionKeyProperty, value);
      }

      public string FunctionKeyCode
      {
         get => (string)this.GetValue(FunctionKeyCodeProperty);
         set => this.SetValue(FunctionKeyCodeProperty, value);
      }

      public bool ShiftPressed
      {
         get => (bool)this.GetValue(ShiftPressedProperty);
         set => this.SetValue(ShiftPressedProperty, value);
      }

      public bool FnKeyPressed
      {
         get => (bool)this.GetValue(FnKeyPressedProperty);
         set => this.SetValue(FnKeyPressedProperty, value);
      }

      public string GetKeyCode()
      {
         if (this.FnKeyPressed == true)
         {
            return this.FunctionKeyCode;
         }
         else
         {
            if (this.ShiftPressed == true)
            {
               return this.SpecialSymbolCode;
            }
            else
            {
               return this.NumberKeyCode;
            }
         }
      }

      public void UpdateShiftKeyStatus(bool state)
      {
         this.ShiftPressed = state;
      }

      public void UpdateFunctionKeyStatus(bool state)
      {
         this.FnKeyPressed = state;
      }

      public void UpdateCapsLockKeyStatus(bool state)
      {
         return;
      }
   }
}
