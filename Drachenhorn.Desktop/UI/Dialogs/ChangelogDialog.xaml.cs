﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Drachenhorn.Desktop.UI.Dialogs
{
    /// <summary>
    /// Interaktionslogik für ChangelogDialog.xaml
    /// </summary>
    public partial class ChangelogDialog : Window
    {
        #region Properties

        private string _currentVersion;

        public string CurrentVersion
        {
            get => _currentVersion;
            set
            {
                if (_currentVersion == value)
                    return;
                _currentVersion = value;
            }
        }

        private string _newVersion;

        public string NewVersion
        {
            get => _newVersion;
            set
            {
                if (_newVersion == value)
                    return;
                _newVersion = value;
            }
        }

        private IEnumerable<string> _changes;

        public IEnumerable<string> Changes
        {
            get => _changes;
            set
            {
                if (_changes == value)
                    return;
                _changes = value;
            }
        }

        #endregion Properties


        public ChangelogDialog(IEnumerable<string> changes, Action updateAction)
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}