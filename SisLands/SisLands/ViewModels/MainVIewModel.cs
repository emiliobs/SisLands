namespace SisLands.ViewModels
{   
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SisLands.Models;
    public class MainVIewModel
    {
        #region Properties

        public TokenResponse Token { get; set; }

        public List<Lands> LandsList { get; set; }

        #endregion

        #region ViewModels

        public LoginViewModel Login { get; set; }
        public LandsViewModel Lands { get; set; }
        public LandViewModel Land { get; set; }

       

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
