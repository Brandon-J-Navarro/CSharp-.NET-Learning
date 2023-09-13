using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PasswordGenerator.Interactions;
using PasswordGenerator.Resources;
using PasswordGenerator.Workers;


namespace PasswordGenerator
{
    public partial class MainWindow : Window
    {
        public string StrengthStatus { get; private set; }
        public string Password { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            GeneratePassword_Click(this.GeneratePassword, new RoutedEventArgs());
        }


        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(PasswordLengthInput, out float passwordLength))
            {
                if (passwordLength < 4 || passwordLength > 40)
                {
                    chkPasswordStrength.Content = "Error: Password length should be between 4 and 40.";
                }
                else
                {
                    string Password = PasswordBuilder.GetPassword(passwordLength, ChkIncludeLowerChar, ChkIncludeUpperChar,
                        ChkIncludeNumbers, ChkIncludeSymbols, ChkExcludeSimilar, ChkExcludeAmbiguous);
                    passwordBox.Text = Password;
                    StrengthStatus = GetPasswordStrength(Password);
                    chkPasswordStrength.Content = StrengthStatus;
                }
            }
            else
            {
                chkPasswordStrength.Content = "Invalid input. Please enter a valid number.";
            }

            if (chkPasswordStrength.Content == "Error: Password length should be between 4 and 40.")
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 12;
            }
            if (chkPasswordStrength.Content == "Invalid input. Please enter a valid number.")
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 12;
            }
            if (chkPasswordStrength.Content == "Very Weak")
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == "Very Unsecure")
            {
                chkPasswordStrength.Foreground = Brushes.Red;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == "Unsecure")
            {
                chkPasswordStrength.Foreground = Brushes.Orange;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == "Medium")
            {
                chkPasswordStrength.Foreground = Brushes.LightGreen;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == "Secure")
            {
                chkPasswordStrength.Foreground = Brushes.Green;
                chkPasswordStrength.FontSize = 16;
            }
            if (chkPasswordStrength.Content == "Very Secure")
            {
                chkPasswordStrength.Foreground = Brushes.DarkGreen;
                chkPasswordStrength.FontSize = 16;
            }
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(passwordBox.Text);
        }


        private void OnKeyInputLength(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && passwordLengthInput.Text != "")
            {
                GeneratePassword_Click(this.GeneratePassword, new RoutedEventArgs());
            }
        }
    }
}
