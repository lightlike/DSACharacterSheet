﻿using DSACharacterSheet.Core.Lang;
using DSACharacterSheet.Core.Settings;
using DSACharacterSheet.Core.Settings.Update;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace DSACharacterSheet.Core.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Properties

        private ISettings _settings;

        public ISettings Settings
        {
            get { return _settings; }
            set
            {
                if (_settings == value)
                    return;
                _settings = value;
                RaisePropertyChanged();
            }
        }

        private bool _isCheckingUpdate = false;

        public bool IsCheckingUpdate
        {
            get { return _isCheckingUpdate; }
            private set
            {
                if (_isCheckingUpdate == value)
                    return;
                _isCheckingUpdate = value;
                RaisePropertyChanged();
            }
        }

        private IDialogService DialogService { get; set; }

        #endregion Properties

        #region c'tor

        public SettingsViewModel(ISettings settings, IDialogService dialogService)
        {
            Settings = settings;

            DialogService = dialogService;

            InitializeCommands();
        }

        #endregion c'tor

        #region Commands

        private void InitializeCommands()
        {
            CheckForUpdate = new RelayCommand(ExecuteCheckForUpdate);
        }

        public RelayCommand CheckForUpdate { get; private set; }

        private void ExecuteCheckForUpdate()
        {
            IsCheckingUpdate = true;
            Settings.CheckUpdateAsync(UpdateCheckFinished);
        }

        private void UpdateCheckFinished(object sender, UpdateCheckedEventArgs args)
        {
            IsCheckingUpdate = false;

            var text = LanguageManager.Translate(args.IsUpdateAvailable ? "Update.CheckForUpdate.Finished.Successful" : "Update.CheckForUpdate.Finished.Failed");

            DialogService.ShowMessageBox(text, LanguageManager.Translate("Update.CheckForUpdate.Finished.Caption"));
        }

        #endregion Commands
    }
}