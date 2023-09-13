using PasswordGenerator.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Repository
{
    internal class PasswordGenerateCommand
    {
        static Random random = new Random();

        internal static string GetPassword(float passwordLength, bool ChkIncludeLowerChar, bool ChkIncludeUpperChar,
            bool ChkIncludeNumbers, bool ChkIncludeSymbols, bool ChkExcludeSimilar, bool ChkExcludeAmbiguous)
        {
            StringBuilder Password = new StringBuilder();
            char[] array = new char[0];

            if (ChkIncludeLowerChar)
                array = array.Concat(Constans.lowerChars).ToArray();

            if (ChkIncludeUpperChar)
                array = array.Concat(Constans.upperChars).ToArray();

            if (ChkIncludeNumbers)
                array = array.Concat(Constans.numbers).ToArray();

            if (ChkIncludeSymbols)
                array = array.Concat(Constans.symbols).ToArray();

            if (!ChkExcludeSimilar)
            {
                if (ChkIncludeLowerChar)
                    array = array.Concat(Constans.similarsLower).ToArray();

                if (ChkIncludeUpperChar)
                    array = array.Concat(Constans.similarsUpper).ToArray();

                if (ChkIncludeNumbers)
                    array = array.Concat(Constans.similarsNumbers).ToArray();

                if (ChkIncludeSymbols)
                    array = array.Concat(Constans.similarsSymbols).ToArray();
            }

            if (!ChkExcludeAmbiguous && ChkIncludeSymbols)
                array = array.Concat(Constans.ambiguous).ToArray();

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
