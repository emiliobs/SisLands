namespace SisLands.ViewModels
{   
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MainVIewModel
    {
        #region ViewModels

        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }   
        #endregion

        #region Contructor

        public MainVIewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }

        #endregion

        #region Singleton

        private static MainVIewModel instance;

        public static MainVIewModel GetInstance()
        {
            if (instance == null)
            {
              return   new MainVIewModel();
            }

            return instance;
        }

        #endregion

        #region Properties

        #endregion
    }
}
