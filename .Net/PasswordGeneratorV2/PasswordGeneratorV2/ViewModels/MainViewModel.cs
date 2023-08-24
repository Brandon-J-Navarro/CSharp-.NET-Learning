using Caliburn.Micro;
using PasswordGeneratorV2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using PasswordGeneratorV2.Repository;
using System.Net.NetworkInformation;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;
using System.Security.RightsManagement;

namespace PasswordGeneratorV2.ViewModels
{
    internal class MainViewModel :Screen
    {
        private string _password;
        private string _strength;
        private string _passwordInputLength;
        private bool _chkIncludeLowerChar;
        private bool _chkIncludeUpperChar;
        private bool _chkIncludeNumbers;
        private bool _chkIncludeSymbols;
        private bool _chkExcludeAmbiguous;
        private bool _chkExcludeSimilar;


        public MainViewModel()
        {
            Generate();
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
                UpdatePassword(_password );
                UpdateStrength(_strength );
            }
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

        private void OnKeyInputLength(object sender, KeyEventArgs Enter)
        {
            if (Enter.Key == Key.Return && _passwordInputLength != string.Empty)
            {
                Generate();
            }
        }
    }
}
