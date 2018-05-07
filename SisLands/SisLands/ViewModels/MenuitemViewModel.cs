using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SisLands.Helpers;
using SisLands.Views;
using Xamarin.Forms;

namespace SisLands.ViewModels
{
    public class MenuitemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }



        #endregion

        #region Commands

        public ICommand NavigateCommand
        {
            get => new RelayCommand(Navigate);
        }

        private void Navigate()
        {
            if (PageName == "LoginPage")
            {
                Settings.Token = string.Empty;
                Settings.TokenTypeId = string.Empty;

                var mainViewModel = MainVIewModel.GetInstance();
                mainViewModel.TokenType = string.Empty;
                mainViewModel.Token = string.Empty;

                Application.Current.MainPage = new LoginPage();
            }
        }

        #endregion


    }
}
