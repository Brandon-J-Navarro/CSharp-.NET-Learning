using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Resources
{
    internal class Constants
    {
        public static char[] upperChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public static char[] lowerChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static char[] numbers = { '2', '3', '4', '5', '6', '7', '8', '9' };
        public static char[] symbols = { '!', '#', '$', '%', '&', '*', '+', '-', '?', '@' };
        public static char[] similarsLower = { 'i', 'l', 'o' };
        public static char[] similarsUpper = { 'I', 'L', 'O' };
        public static char[] similarsNumbers = { '1', '0' };
        public static char[] similarsSymbols = { '|' };
        public static char[] ambiguous = { '"', '\'', '(', ')', ',', '.', '/', ':', ';', '<', '=', '>', '[', '\\', ']', '^', '_', '`', '{', '}', '~' };
        public string StrengthStatus { get; private set; }
        public bool ChkIncludeLowerChar { get; private set; }
        public bool ChkIncludeUpperChar { get; private set; }
        public bool ChkIncludeNumbers { get; private set; }
        public bool ChkIncludeSymbols { get; private set; }
        public bool ChkExcludeAmbiguous { get; private set; }
        public bool ChkExcludeSimilar { get; private set; }
        public string PasswordLengthInput { get; private set; }
    }
}
