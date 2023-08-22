using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using PasswordGenerator.Resources;

namespace PasswordGenerator.Workers
{
    internal class StrengthChecker
    {
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
            if (Contains(Password, Constants.lowerChars))
            {
                strengthScore = strengthScore + 1;
            }
            if (Contains(Password, Constants.similarsLower))
            {
                strengthScore = strengthScore + 1;
            }
            if (Contains(Password, Constants.upperChars))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constants.similarsUpper))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constants.numbers) || Contains(Password, Constants.similarsNumbers))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constants.symbols))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constants.similarsSymbols))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constants.ambiguous))
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

        private void PasswordStrength(object sender, RoutedEventArgs e, string strengthStatus)
        {
            var label = sender as TextBox;

            label.Text = strengthStatus;
        }
    }
}
