// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

// ref: https://stackoverflow.com/questions/15292175/c-sharp-using-sendkey-function-to-send-a-key-to-another-application
// REF : https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=net-5.0
// ref : https://social.msdn.microsoft.com/Forums/vstudio/en-US/46df5e47-539c-443f-852e-8cef2d5ad740/wpf-send-keycode-to-active-application?forum=wpf
// ref : https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.sendkeys.send?view=net-5.0
namespace On_Screen_Keyboard
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows;

    public partial class MainWindow : Window, System.ComponentModel.INotifyPropertyChanged
    {
      public static readonly DependencyProperty WinKeyPressedProperty = DependencyProperty.Register(
        "WinKeyPressed",
        typeof(bool),
        typeof(MainWindow));

      public static readonly DependencyProperty ShiftPressedProperty = DependencyProperty.Register(
        "ShiftPressed",
        typeof(bool),
        typeof(MainWindow));

      public static readonly DependencyProperty CapsLockPressedProperty = DependencyProperty.Register(
        "CapsLockPressed",
        typeof(bool),
        typeof(MainWindow));

      public static readonly DependencyProperty CtrlPressedProperty = DependencyProperty.Register(
        "CtrlPressed",
        typeof(bool),
        typeof(MainWindow));

      public static readonly DependencyProperty AltPressedProperty = DependencyProperty.Register(
        "AltPressed",
        typeof(bool),
        typeof(MainWindow));

      public static readonly DependencyProperty FnPressedProperty = DependencyProperty.Register(
        "FnPressed",
        typeof(bool),
        typeof(MainWindow));

      private readonly List<IKeyBoardButton> buttonKeys = new List<IKeyBoardButton>();

      private Process process = null;

      public MainWindow()
      {
         this.InitializeComponent();

         this.buttonKeys.Add(this.ContextKeyButton);
         this.buttonKeys.Add(this.RightArrowButton);
         this.buttonKeys.Add(this.DownArrowButton);
         this.buttonKeys.Add(this.LeftArrowButton);
         this.buttonKeys.Add(this.UpArrowButton);
         this.buttonKeys.Add(this.SpaceKeyButton);
         this.buttonKeys.Add(this.EnterKeyButton);
         this.buttonKeys.Add(this.DelKeyButton);
         this.buttonKeys.Add(this.TabKeyButton);
         this.buttonKeys.Add(this.EscKeyButton);
         this.buttonKeys.Add(this.BackKeyButton);

         this.buttonKeys.Add(this.BtnNumberKey_1);
         this.buttonKeys.Add(this.BtnNumberKey_2);
         this.buttonKeys.Add(this.BtnNumberKey_3);
         this.buttonKeys.Add(this.BtnNumberKey_4);
         this.buttonKeys.Add(this.BtnNumberKey_5);
         this.buttonKeys.Add(this.BtnNumberKey_6);
         this.buttonKeys.Add(this.BtnNumberKey_7);
         this.buttonKeys.Add(this.BtnNumberKey_8);
         this.buttonKeys.Add(this.BtnNumberKey_9);
         this.buttonKeys.Add(this.BtnNumberKey_0);
         this.buttonKeys.Add(this.BtnNumberKey_dash);
         this.buttonKeys.Add(this.BtnNumberKey_plus);

         this.buttonKeys.Add(this.ButtonKey2s_tilde);

         this.buttonKeys.Add(this.ButtonKey2s_sqBracketOpen);
         this.buttonKeys.Add(this.ButtonKey2s_sqBracketClose);
         this.buttonKeys.Add(this.ButtonKey2s_backwardSlash);
         this.buttonKeys.Add(this.ButtonKey2s_semiColon);
         this.buttonKeys.Add(this.ButtonKey2s_singleQuote);
         this.buttonKeys.Add(this.ButtonKey2s_comma);
         this.buttonKeys.Add(this.ButtonKey2s_dot);
         this.buttonKeys.Add(this.ButtonKey2s_forwardSlash);

         this.buttonKeys.Add(this.ButtonAlphabetKey_q);
         this.buttonKeys.Add(this.ButtonAlphabetKey_w);
         this.buttonKeys.Add(this.ButtonAlphabetKey_e);
         this.buttonKeys.Add(this.ButtonAlphabetKey_r);
         this.buttonKeys.Add(this.ButtonAlphabetKey_t);
         this.buttonKeys.Add(this.ButtonAlphabetKey_y);
         this.buttonKeys.Add(this.ButtonAlphabetKey_u);
         this.buttonKeys.Add(this.ButtonAlphabetKey_i);
         this.buttonKeys.Add(this.ButtonAlphabetKey_o);
         this.buttonKeys.Add(this.ButtonAlphabetKey_p);
         this.buttonKeys.Add(this.ButtonAlphabetKey_a);
         this.buttonKeys.Add(this.ButtonAlphabetKey_s);
         this.buttonKeys.Add(this.ButtonAlphabetKey_d);
         this.buttonKeys.Add(this.ButtonAlphabetKey_f);
         this.buttonKeys.Add(this.ButtonAlphabetKey_g);
         this.buttonKeys.Add(this.ButtonAlphabetKey_h);
         this.buttonKeys.Add(this.ButtonAlphabetKey_j);
         this.buttonKeys.Add(this.ButtonAlphabetKey_k);
         this.buttonKeys.Add(this.ButtonAlphabetKey_l);
         this.buttonKeys.Add(this.ButtonAlphabetKey_z);
         this.buttonKeys.Add(this.ButtonAlphabetKey_x);
         this.buttonKeys.Add(this.ButtonAlphabetKey_c);
         this.buttonKeys.Add(this.ButtonAlphabetKey_v);
         this.buttonKeys.Add(this.ButtonAlphabetKey_b);
         this.buttonKeys.Add(this.ButtonAlphabetKey_n);
         this.buttonKeys.Add(this.ButtonAlphabetKey_m);

         foreach (IKeyBoardButton ch in this.buttonKeys)
         {
            ch.Click += this.Key_Click;
         }

         this.ResetSpecialKey();
      }

      public event PropertyChangedEventHandler PropertyChanged;

      public bool WinKeyPressed
      {
         get => (bool)this.GetValue(WinKeyPressedProperty);
         set
         {
            this.SetValue(WinKeyPressedProperty, value);
            this.OnPropertyChanged(nameof(this.WinKeyPressed));
         }
      }

      public bool ShiftPressed
      {
         get => (bool)this.GetValue(ShiftPressedProperty);
         set
         {
            this.SetValue(ShiftPressedProperty, value);
            this.OnPropertyChanged(nameof(this.ShiftPressed));
         }
      }

      public bool CapsLockPressed
      {
         get => (bool)this.GetValue(CapsLockPressedProperty);
         set => this.SetValue(CapsLockPressedProperty, value);
      }

      public bool CtrlPressed
      {
         get => (bool)this.GetValue(CtrlPressedProperty);
         set
         {
            this.SetValue(CtrlPressedProperty, value);
            this.OnPropertyChanged(nameof(this.CtrlPressed));
         }
      }

      public bool AltPressed
      {
         get => (bool)this.GetValue(AltPressedProperty);
         set
         {
            this.SetValue(AltPressedProperty, value);
            this.OnPropertyChanged(nameof(this.AltPressed));
         }
      }

      public bool FnPressed
      {
         get => (bool)this.GetValue(FnPressedProperty);
         set
         {
            this.SetValue(FnPressedProperty, value);
            this.OnPropertyChanged(nameof(this.FnPressed));
         }
      }

      protected void OnPropertyChanged(string name = null)
      {
         this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }

      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool SetForegroundWindow(System.IntPtr hWnd);

      private void Key_Click(object sender, RoutedEventArgs e)
      {
         IKeyBoardButton key = sender as IKeyBoardButton;
         string ch = key.GetKeyCode();

         string modifiderKeys = string.Empty;
         if (this.ShiftPressed)
         {
            modifiderKeys += "+";
         }

         if (this.AltPressed)
         {
            modifiderKeys += "%";
         }

         if (this.CtrlPressed)
         {
            modifiderKeys += "^";
         }

         System.Diagnostics.Debug.WriteLine($"Send key stroke {modifiderKeys} {ch}");

         if (this.process == null)
         {
            this.process = Process.Start("notepad.exe");
            this.process.WaitForInputIdle();
         }

         System.IntPtr h = this.process.MainWindowHandle;
         SetForegroundWindow(h);
         System.Windows.Forms.SendKeys.SendWait(modifiderKeys + ch);

         this.ResetSpecialKey();
      }

      private void ResetSpecialKey()
      {
         this.ShiftPressed = false;
         this.ShiftKeyStateChanged();

         this.FnPressed = false;
         this.FnKeyStateChanged();

         this.CtrlPressed = false;
         this.CtrlKeyStateChanged();

         this.AltPressed = false;
         this.AltButtonStateChanged();

         this.WinKeyPressed = false;
         this.WindowsButton.Pressed = this.WinKeyPressed;
      }

      private void Shift_Button_Click(object sender, RoutedEventArgs e)
      {
         this.ShiftPressed = !this.ShiftPressed;
         this.ShiftKeyStateChanged();
      }

      private void ShiftKeyStateChanged()
      {
         this.ShiftLeftButton.Pressed = this.ShiftPressed;
         this.ShiftRightButton.Pressed = this.ShiftPressed;

         foreach (IKeyBoardButton ch in this.buttonKeys)
         {
            ch.UpdateShiftKeyStatus(this.ShiftPressed);
         }
      }

      private void FnKey_Button_Click(object sender, RoutedEventArgs e)
      {
         this.FnPressed = !this.FnPressed;
         this.FnKeyStateChanged();
      }

      private void FnKeyStateChanged()
      {
         this.FnButton.Pressed = this.FnPressed;

         foreach (IKeyBoardButton ch in this.buttonKeys)
         {
            ch.UpdateFunctionKeyStatus(this.FnPressed);
         }
      }

      private void CapsLock_Button_Click(object sender, RoutedEventArgs e)
      {
         this.CapsLockPressed = !this.CapsLockPressed;
         this.CapsLockKeyStateChanged();
      }

      private void CapsLockKeyStateChanged()
      {
         this.ButtonCapsLock.Pressed = this.CapsLockPressed;

         foreach (IKeyBoardButton ch in this.buttonKeys)
         {
            ch.UpdateCapsLockKeyStatus(this.CapsLockPressed);
         }
      }

      private void Ctrl_Button_Click(object sender, RoutedEventArgs e)
      {
         this.CtrlPressed = !this.CtrlPressed;
         this.CtrlKeyStateChanged();
      }

      private void CtrlKeyStateChanged()
      {
         this.CtrlLeftButton.Pressed = this.CtrlPressed;
         this.CtrlRightButton.Pressed = this.CtrlPressed;
      }

      private void Alt_Button_Click(object sender, RoutedEventArgs e)
      {
         this.AltPressed = !this.AltPressed;
         this.AltButtonStateChanged();
      }

      private void AltButtonStateChanged()
      {
         this.AltLeftButton.Pressed = this.AltPressed;
         this.AltRightButton.Pressed = this.AltPressed;
      }

      private void WinKey_Button_Click(object sender, RoutedEventArgs e)
      {
         this.WinKeyPressed = !this.WinKeyPressed;
         this.WindowsButton.Pressed = this.WinKeyPressed;
      }

      private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
      {
         Debug.WriteLine(e.Key);
      }
   }
}
