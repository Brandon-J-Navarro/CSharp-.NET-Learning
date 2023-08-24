using PasswordGenerator.Model;
using PasswordGenerator.Repository;
using PasswordGenerator.Resources;
using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        private static PasswordGeneratorModel passwordGeneratorModel = new PasswordGeneratorModel();

        public MainWindow()
        {
            InitializeComponent();
            GeneratePassword_Click(this.GeneratePassword, new RoutedEventArgs());
        }

        private void ChkIncludeLowerChar_Checked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeLowerChar = true;
        }

        private void ChkIncludeLowerChar_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeLowerChar = false;
        }

        private void ChkIncludeUpperChar_Checked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeUpperChar = true;
        }

        private void ChkIncludeUpperChar_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeUpperChar = false;
        }

        private void ChkIncludeNumbers_Checked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeNumbers = true;
        }

        private void ChkIncludeNumbers_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeNumbers = false;
        }

        private void ChkIncludeSymbols_Checked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeSymbols = true;
        }

        private void ChkIncludeSymbols_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkIncludeSymbols = false;
        }

        private void ChkExcludeAmbiguous_Checked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkExcludeAmbiguous = true;
        }

        private void ChkExcludeAmbiguous_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkExcludeAmbiguous = false;
        }

        private void ChkExcludeSimilar_Checked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkExcludeSimilar = true;
        }

        private void ChkExcludeSimilar_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordGeneratorModel.ChkExcludeSimilar = false;
        }

        private void PasswordLengthInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            passwordGeneratorModel.PasswordLengthInput = passwordLengthInput.Text;
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(passwordGeneratorModel.PasswordLengthInput, out float passwordLength))
            {
                if (passwordLength < 4 || passwordLength > 40)
                {
                    chkPasswordStrength.Content = Constans.error;
                }
                else
                {
                    string Password = PasswordGenerateCommand.GetPassword(passwordLength, passwordGeneratorModel.ChkIncludeLowerChar, passwordGeneratorModel.ChkIncludeUpperChar,
                        passwordGeneratorModel.ChkIncludeNumbers, passwordGeneratorModel.ChkIncludeSymbols, passwordGeneratorModel.ChkExcludeSimilar, passwordGeneratorModel.ChkExcludeAmbiguous);
                    passwordBox.Text = Password;
                    passwordGeneratorModel.StrengthStatus = PasswordStrengthCommand.GetPasswordStrength(Password);
                    chkPasswordStrength.Content = passwordGeneratorModel.StrengthStatus;
                }
            }
            else
            {
                chkPasswordStrength.Content = Constans.invalidInput;
            }
            if (chkPasswordStrength.Content == Constans.error)
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 12;
            }
            if (chkPasswordStrength.Content == Constans.invalidInput)
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 12;
            }
            if (chkPasswordStrength.Content == Constans.veryWeak)
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == Constans.veryUnsecure)
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == Constans.unsecure)
            {
                chkPasswordStrength.Foreground = Brushes.Orange;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == Constans.medium)
            {
                chkPasswordStrength.Foreground = Brushes.LightGreen;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == Constans.secure)
            {
                chkPasswordStrength.Foreground = Brushes.Green;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == Constans.verySecure)
            {
                chkPasswordStrength.Foreground = Brushes.DarkGreen;
                chkPasswordStrength.FontSize = 16;
            }
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(passwordBox.Text);
        }

        private void PasswordStrength(object sender, RoutedEventArgs e)
        {
            var label = sender as TextBox;
            label.Text = passwordGeneratorModel.StrengthStatus;
        }

        private void OnKeyInputLength(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && passwordLengthInput.Text != string.Empty)
            {
                GeneratePassword_Click(this.GeneratePassword, new RoutedEventArgs());
            }
        }
    }
}
