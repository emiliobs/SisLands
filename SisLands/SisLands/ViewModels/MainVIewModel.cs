namespace SisLands.ViewModels
{   
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MainVIewModel
    {
        #region ViewModels

        public LoginViewModel Login { get; set; }

        #endregion

        #region Contructor

        public MainVIewModel()
        {
            this.Login = new LoginViewModel();
        }

        #endregion

        #region Properties

        #endregion
    }
}
