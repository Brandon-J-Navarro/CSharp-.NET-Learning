using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using PasswordGenerator.Resources;

namespace PasswordGenerator.Interactions
{
    internal class PasswordOptions
    {

        public void ChkIncludeLowerChar_Checked(object sender, RoutedEventArgs e, bool ChkIncludeLowerChar)
        {
            ChkIncludeLowerChar = true;
        }

        public void ChkIncludeLowerChar_Unchecked(object sender, RoutedEventArgs e, bool ChkIncludeLowerChar)
        {
            ChkIncludeLowerChar = false;
        }

        public void ChkIncludeUpperChar_Checked(object sender, RoutedEventArgs e, bool ChkIncludeUpperChar)
        {
            ChkIncludeUpperChar = true;
        }

        public void ChkIncludeUpperChar_Unchecked(object sender, RoutedEventArgs e, bool ChkIncludeUpperChar)
        {
            ChkIncludeUpperChar = false;
        }

        public void ChkIncludeNumbers_Checked(object sender, RoutedEventArgs e, bool ChkIncludeNumbers)
        {
            ChkIncludeNumbers = true;
        }

        public void ChkIncludeNumbers_Unchecked(object sender, RoutedEventArgs e, bool ChkIncludeNumbers)
        {
            ChkIncludeNumbers = false;
        }

        public void ChkIncludeSymbols_Checked(object sender, RoutedEventArgs e, bool ChkIncludeSymbols)
        {
            ChkIncludeSymbols = true;
        }

        public void ChkIncludeSymbols_Unchecked(object sender, RoutedEventArgs e, bool ChkIncludeSymbols)
        {
            ChkIncludeSymbols = false;
        }

        public void ChkExcludeAmbiguous_Checked(object sender, RoutedEventArgs e, bool ChkExcludeAmbiguous)
        {
            ChkExcludeAmbiguous = true;
        }

        public void ChkExcludeAmbiguous_Unchecked(object sender, RoutedEventArgs e, bool ChkExcludeAmbiguous)
        {
            ChkExcludeAmbiguous = false;
        }

        public void ChkExcludeSimilar_Checked(object sender, RoutedEventArgs e, bool ChkExcludeSimilar)
        {
            ChkExcludeSimilar = true;
        }

        public void ChkExcludeSimilar_Unchecked(object sender, RoutedEventArgs e, bool ChkExcludeSimilar)
        {
            ChkExcludeSimilar = false;
        }

        public void PasswordLengthInput_TextChanged(object sender, TextChangedEventArgs e, object PasswordLengthInput)
        {
            PasswordLengthInput = passwordLengthInput.Text;
        }
    }
}
