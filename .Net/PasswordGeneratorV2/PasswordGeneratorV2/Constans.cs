using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorV2
{
    internal class Constans
    {
        internal static char[] upperChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        internal static char[] lowerChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        internal static char[] numbers = { '2', '3', '4', '5', '6', '7', '8', '9' };
        internal static char[] symbols = { '!', '#', '$', '%', '&', '*', '+', '-', '?', '@' };
        internal static char[] similarsLower = { 'i', 'l', 'o' };
        internal static char[] similarsUpper = { 'I', 'L', 'O' };
        internal static char[] similarsNumbers = { '1', '0' };
        internal static char[] similarsSymbols = { '|' };
        internal static char[] ambiguous = { '"', '\'', '(', ')', ',', '.', '/', ':', ';', '<', '=', '>', '[', '\\', ']', '^', '_', '`', '{', '}', '~' };
        internal static string veryWeak = "Very Weak";
        internal static string veryUnsecure = "Very Unsecure";
        internal static string unsecure = "Unsecure";
        internal static string medium = "Medium";
        internal static string secure = "Secure";
        internal static string verySecure = "Very Secure";
        internal static string invalidInput = "Invalid input. Please enter a valid number.";
        internal static string error = "Error: Password length should be between 4 and 40.";
    }
}
