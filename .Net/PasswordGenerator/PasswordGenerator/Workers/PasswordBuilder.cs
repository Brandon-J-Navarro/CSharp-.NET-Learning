using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerator.Resources;

namespace PasswordGenerator.Workers
{
    internal class PasswordBuilder
    {
        static Random random = new Random();
        
        public static string GetPassword(float passwordLength, bool ChkIncludeLowerChar, bool ChkIncludeUpperChar,
            bool ChkIncludeNumbers, bool ChkIncludeSymbols, bool ChkExcludeSimilar, bool ChkExcludeAmbiguous)
        {

            StringBuilder Password = new StringBuilder();
            char[] array = new char[0];

            if (ChkIncludeLowerChar)
                array = array.Concat(Constants.lowerChars).ToArray();

            if (ChkIncludeUpperChar)
                array = array.Concat(Constants.upperChars).ToArray();

            if (ChkIncludeNumbers)
                array = array.Concat(Constants.numbers).ToArray();

            if (ChkIncludeSymbols)
                array = array.Concat(Constants.symbols).ToArray();

            if (!ChkExcludeSimilar)
            {
                if (ChkIncludeLowerChar)
                    array = array.Concat(Constants.similarsLower).ToArray();

                if (ChkIncludeUpperChar)
                    array = array.Concat(Constants.similarsUpper).ToArray();

                if (ChkIncludeNumbers)
                    array = array.Concat(Constants.similarsNumbers).ToArray();

                if (ChkIncludeSymbols)
                    array = array.Concat(Constants.similarsSymbols).ToArray();
            }

            if (!ChkExcludeAmbiguous && ChkIncludeSymbols)
                array = array.Concat(Constants.ambiguous).ToArray();

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
    }
}
