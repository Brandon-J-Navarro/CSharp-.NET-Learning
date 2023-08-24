using Caliburn.Micro;
using System.Windows;
using PasswordGeneratorV2.Repository;
using System.Windows.Input;
using Prism.Commands;

namespace PasswordGeneratorV2.ViewModels
{
    internal class MainViewModel :Screen
    {
        private string _password;
        private string _strength;
        private string _passwordInputLength = "10";
        private bool _chkIncludeLowerChar = true;
        private bool _chkIncludeUpperChar = true;
        private bool _chkIncludeNumbers = true;
        private bool _chkIncludeSymbols = true;
        private bool _chkExcludeAmbiguous = false;
        private bool _chkExcludeSimilar = false;
        private ICommand _onKeyInputLength;

        public MainViewModel()
        {
            Generate();
        }

        public ICommand OnKeyInputLength
        {
            get
                {
                if (_onKeyInputLength == null)
                {
                    _onKeyInputLength = new DelegateCommand(delegate ()
                    {
                        Generate();
                    });
                }
                return _onKeyInputLength;
            }
        }

        public void Copy()
        {
            Clipboard.SetText(_password);
        }

        public void Generate()
        {
            if (float.TryParse(_passwordInputLength, out float _passwordLength))
            {
                if (_passwordLength < 4 || _passwordLength > 40)
                {
                    _strength = Constans.error;
                }
                else
                {
                    _password = PasswordGenerateCommand.GetPassword(
                        _passwordLength,
                        _chkIncludeLowerChar,
                        _chkIncludeUpperChar,
                        _chkIncludeNumbers,
                        _chkIncludeSymbols,
                        _chkExcludeAmbiguous,
                        _chkExcludeSimilar);
                    _strength = PasswordStrengthCommand.GetPasswordStrength(_password);
                }
            }
            else
            {
                _strength = Constans.invalidInput;
            }
            UpdatePassword(_password);
            UpdateStrength(_strength);
        }

        private void UpdatePassword(string password)
        {
            Password = password;
            NotifyOfPropertyChange(() => Password);
        }

        private void UpdateStrength(string strength)
        {
            Strength = strength;
            NotifyOfPropertyChange(() => Strength);
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }
        public string PasswordLength
        {
            get { return _passwordInputLength; }
            set { _passwordInputLength = value; }
        }
        public bool ChkIncludeLowerChar
        {
            get { return _chkIncludeLowerChar; }
            set { _chkIncludeLowerChar = value; }
        }
        public bool ChkIncludeUpperChar
        {
            get { return _chkIncludeUpperChar; }
            set { _chkIncludeUpperChar = value; }
        }
        public bool ChkIncludeNumbers
        {
            get { return _chkIncludeNumbers; }
            set { _chkIncludeNumbers = value; }
        }
        public bool ChkIncludeSymbols
        {
            get { return _chkIncludeSymbols; }
            set { _chkIncludeSymbols = value; }
        }
        public bool ChkExcludeAmbiguous
        {
            get { return _chkExcludeAmbiguous; }
            set { _chkExcludeAmbiguous = value; }
        }
        public bool ChkExcludeSimilar
        {
            get { return _chkExcludeSimilar; }
            set { _chkExcludeSimilar = value; }
        }
    }
}
