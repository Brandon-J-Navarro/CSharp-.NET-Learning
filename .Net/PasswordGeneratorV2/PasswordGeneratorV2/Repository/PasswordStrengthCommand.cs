using System.Linq;

namespace PasswordGeneratorV2.Repository
{
    internal class PasswordStrengthCommand
    {
        internal static string GetPasswordStrength(string Password)
        {
            int strengthScore = 0;
            string StrengthStatus = Constans.veryWeak;
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
            if (Contains(Password, Constans.lowerChars))
            {
                strengthScore = strengthScore + 1;
            }
            if (Contains(Password, Constans.similarsLower))
            {
                strengthScore = strengthScore + 1;
            }
            if (Contains(Password, Constans.upperChars))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constans.similarsUpper))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constans.numbers) || Contains(Password, Constans.similarsNumbers))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constans.symbols))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constans.similarsSymbols))
            {
                strengthScore = strengthScore + 2;
            }
            if (Contains(Password, Constans.ambiguous))
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
                StrengthStatus = Constans.veryUnsecure;
            }
            else if (strengthScore <= 5)
            {
                StrengthStatus = Constans.unsecure;
            }
            else if (strengthScore <= 7)
            {
                StrengthStatus = Constans.medium;
            }
            else if (strengthScore <= 9)
            {
                StrengthStatus = Constans.secure;
            }
            else
            {
                if (Password.Length >= 9)
                {
                    StrengthStatus = Constans.verySecure;
                }
                else if (Password.Length >= 7)
                {
                    StrengthStatus = Constans.secure;
                }
                else
                {
                    StrengthStatus = Constans.medium;
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
    }
}
