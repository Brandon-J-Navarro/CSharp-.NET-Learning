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
        static char[] upperChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static char[] lowerChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        static char[] numbers = { '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] symbols = { '!', '#', '$', '%', '&', '*', '+', '-', '?', '@' };
        static char[] similarsLower = { 'i', 'l', 'o' };
        static char[] similarsUpper = { 'I', 'L', 'O' };
        static char[] similarsNumbers = { '1', '0' };
        static char[] similarsSymbols = { '|' };
        static char[] ambiguous = { '"', '\'', '(', ')', ',', '.', '/', ':', ';', '<', '=', '>', '[', '\\', ']', '^', '_', '`', '{', '}', '~' };
        static Random random = new Random();
        public bool ChkIncludeLowerChar { get; private set; }
        public bool ChkIncludeUpperChar { get; private set; }
        public bool ChkIncludeNumbers { get; private set; }
        public bool ChkIncludeSymbols { get; private set; }
        public bool ChkExcludeAmbiguous { get; private set; }
        public bool ChkExcludeSimilar { get; private set; }
        public string StrengthStatus { get; private set; }
        public string PasswordLengthInput { get; private set; }
        public string Password { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            GeneratePassword_Click(this.GeneratePassword, new RoutedEventArgs());
        }

        private void ChkIncludeLowerChar_Checked(object sender, RoutedEventArgs e)
        {
            ChkIncludeLowerChar = true;
        }

        private void ChkIncludeLowerChar_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkIncludeLowerChar = false;
        }

        private void ChkIncludeUpperChar_Checked(object sender, RoutedEventArgs e)
        {
            ChkIncludeUpperChar = true;
        }

        private void ChkIncludeUpperChar_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkIncludeUpperChar = false;
        }

        private void ChkIncludeNumbers_Checked(object sender, RoutedEventArgs e)
        {
            ChkIncludeNumbers = true;
        }

        private void ChkIncludeNumbers_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkIncludeNumbers = false;
        }

        private void ChkIncludeSymbols_Checked(object sender, RoutedEventArgs e)
        {
            ChkIncludeSymbols = true;
        }

        private void ChkIncludeSymbols_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkIncludeSymbols = false;
        }

        private void ChkExcludeAmbiguous_Checked(object sender, RoutedEventArgs e)
        {
            ChkExcludeAmbiguous = true;
        }

        private void ChkExcludeAmbiguous_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkExcludeAmbiguous = false;
        }

        private void ChkExcludeSimilar_Checked(object sender, RoutedEventArgs e)
        {
            ChkExcludeSimilar = true;
        }

        private void ChkExcludeSimilar_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkExcludeSimilar = false;
        }

        private void PasswordLengthInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasswordLengthInput = passwordLengthInput.Text;
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
                    string Password = GetPassword(passwordLength, ChkIncludeLowerChar, ChkIncludeUpperChar,
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

        static string GetPassword(float passwordLength, bool ChkIncludeLowerChar, bool ChkIncludeUpperChar,
            bool ChkIncludeNumbers, bool ChkIncludeSymbols, bool ChkExcludeSimilar, bool ChkExcludeAmbiguous)
        {

            StringBuilder Password = new StringBuilder();
            char[] array = new char[0];

            if (ChkIncludeLowerChar)
                array = array.Concat(lowerChars).ToArray();

            if (ChkIncludeUpperChar)
                array = array.Concat(upperChars).ToArray();

            if (ChkIncludeNumbers)
                array = array.Concat(numbers).ToArray();

            if (ChkIncludeSymbols)
                array = array.Concat(symbols).ToArray();

            if (!ChkExcludeSimilar)
            {
                if (ChkIncludeLowerChar)
                    array = array.Concat(similarsLower).ToArray();

                if (ChkIncludeUpperChar)
                    array = array.Concat(similarsUpper).ToArray();

                if (ChkIncludeNumbers)
                    array = array.Concat(similarsNumbers).ToArray();

                if (ChkIncludeSymbols)
                    array = array.Concat(similarsSymbols).ToArray();
            }

            if (!ChkExcludeAmbiguous && ChkIncludeSymbols)
                array = array.Concat(ambiguous).ToArray();

            if (array.Length > 1)
            {
                for (int i = 0; i < passwordLength; i++)
                {
                    int randomIndex = random.Next(array.Length);
                    Password.Append(array[randomIndex]);
                }
            }

            return Password.ToString();
        }

        static string GetPasswordStrength(string Password)
        {
            int strengthScore = 0;
            string StrengthStatus = "Very Weak";

            if (Password.Length > 40)
            {
                strengthScore = strengthScore + 11;
            }
            else if (Password.Length > 25)
            {
                strengthScore = strengthScore + 10;
            }
            else if (Password.Length > 20)
            {
                strengthScore = strengthScore + 9;
            }
            else if (Password.Length > 18)
            {
                strengthScore = strengthScore + 8;
            }
            else if (Password.Length > 16)
            {
                strengthScore = strengthScore + 7;
            }
            else if (Password.Length > 15)
            {
                strengthScore = strengthScore + 6;
            }
            else if (Password.Length > 14)
            {
                strengthScore = strengthScore + 5;
            }
            else if (Password.Length > 13)
            {
                strengthScore = strengthScore + 4;
            }
            else if (Password.Length > 12)
            {
                strengthScore = strengthScore + 3;
            }
            else if (Password.Length > 10)
            {
                strengthScore = strengthScore + 2;
            }
            else if (Password.Length > 8)
            {
                strengthScore = strengthScore + 1;
            }
            if (Password.Length < 3)
            {
                strengthScore = strengthScore - 15;
            }
            else if (Password.Length < 5)
            {
                strengthScore = strengthScore - 13;
            }
            else if (Password.Length < 8)
            {
                strengthScore = strengthScore - 10;
            }
            if (Contains(Password, lowerChars))
            {
                strengthScore = strengthScore + 1;
            }
            if (Contains(Password, similarsLower))
            {
                strengthScore = strengthScore + 1;
            }
            if (Contains(Password, upperChars))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, similarsUpper))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, numbers) || Contains(Password, similarsNumbers))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, symbols))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, similarsSymbols))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, ambiguous))
            {
                strengthScore = strengthScore + 2;
            }

            int uniqueCharactersCount = CountUniqueCharacters(Password);

            if (uniqueCharactersCount < 3)
            {
                strengthScore = strengthScore - 7;
            }
            else if (uniqueCharactersCount < 4)
            {
                strengthScore = strengthScore - 6;
            }
            else if (uniqueCharactersCount < 5)
            {
                strengthScore = strengthScore - 5;
            }
            else if (uniqueCharactersCount < 6)
            {
                strengthScore = strengthScore - 4;
            }
            else if (uniqueCharactersCount < 7)
            {
                strengthScore = strengthScore - 3;
            }
            else if (uniqueCharactersCount < 8)
            {
                strengthScore = strengthScore - 2;
            }
            if (uniqueCharactersCount > 14)
            {
                strengthScore = strengthScore + 4;
            }
            else if (uniqueCharactersCount > 13)
            {
                strengthScore = strengthScore + 3;
            }
            else if (uniqueCharactersCount > 12)
            {
                strengthScore = strengthScore + 2;
            }
            else if (uniqueCharactersCount > 10)
            {
                strengthScore = strengthScore + 1;
            }
            if (strengthScore <= 3)
            {
                StrengthStatus = "Very Unsecure";
            }
            else if (strengthScore <= 5)
            {
                StrengthStatus = "Unsecure";
            }
            else if (strengthScore <= 7)
            {
                StrengthStatus = "Medium";
            }
            else if (strengthScore <= 9)
            {
                StrengthStatus = "Secure";
            }
            else
            {
                if (Password.Length >= 9)
                {
                    StrengthStatus = "Very Secure";
                }
                else if (Password.Length >= 7)
                {
                    StrengthStatus = "Secure";
                }
                else
                {
                    StrengthStatus = "Medium";
                }
            }
            return StrengthStatus;
        }

        static bool Contains(string str, char[] array)
        {
            return array.Any(c => str.Contains(c));
        }

        static int CountUniqueCharacters(string str)
        {
            string uniqueCharacters = new string(str.Distinct().ToArray());
            return uniqueCharacters.Length;
        }

        private void PasswordStrength(object sender, RoutedEventArgs e)
        {
            var label = sender as TextBox;

            label.Text = StrengthStatus;
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
