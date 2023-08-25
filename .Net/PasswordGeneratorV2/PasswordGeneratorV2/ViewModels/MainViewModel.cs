using Caliburn.Micro;
using System.Windows;
using PasswordGeneratorV2.Repository;
using PasswordGeneratorV2.Views;
using System.Windows.Input;
using Prism.Commands;
using System.Windows.Media;
using System.Windows.Controls;

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
        private Brush _color;
        private int _size;

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

        public void UpdatePassword(string password)
        {
            Password = password;
            NotifyOfPropertyChange(() => Password);
        }

        public void UpdateStrength(string strength)
        {

            if (strength == Constans.error)
            {
                _color = Brushes.Red;
                _size = 12;
            }
            if (strength == Constans.invalidInput)
            {
                _color = Brushes.Red;
                _size = 12;
            }
            if (strength == Constans.veryWeak)
            {
                _color = Brushes.Red;
                _size = 16;
            }
            if (strength == Constans.veryUnsecure)
            {
                _color = Brushes.Red;
                _size = 16;
            }
            if (strength == Constans.unsecure)
            {
                _color = Brushes.OrangeRed;
                _size = 16;
            }
            if (strength == Constans.medium)
            {
                _color = Brushes.Orange;
                _size = 16;
            }
            if (strength == Constans.secure)
            {
                _color = Brushes.Green;
                _size = 16;
            }
            if (strength == Constans.verySecure)
            {
                _color = Brushes.DarkGreen;
                _size = 16;
            }
            Strength = strength;
            ColorFont = _color;
            SizeFont = _size;
            NotifyOfPropertyChange(() => Strength);
            NotifyOfPropertyChange(() => ColorFont);
            NotifyOfPropertyChange(() => SizeFont);
        }

        public Brush ColorFont
        {
            get { return _color; }
            set { _color = value; }
        }
        public int SizeFont
        {
            get { return _size; }
            set { _size = value; }
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
