
using GalaSoft.MvvmLight.Command;

namespace SisLands.ViewModels
{
    using System;
    using System.Windows.Input;
    public class LoginViewModel
    {

        #region Properties

        public string Email
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public bool IsRunning
        {
            get; set;
        }

        public bool IsRemembered
        {
            get; set;
        }
        #endregion

        #region Contructor
        public LoginViewModel()
        {
                     this.IsRemembered = true;
        } 
        #endregion

        #region Commands
        public ICommand LoginCommand => new RelayCommand(Login());

        #endregion

        #region Methods

        private Action Login()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
