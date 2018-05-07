using System.Collections.ObjectModel;
using SisLands.Helpers;

namespace SisLands.ViewModels
{   
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SisLands.Models;
    public class MainVIewModel
    {
        #region Properties   
        //public TokenResponse Token { get; set; }

        public string Token { get; set; }
        public string TokenType { get; set; }
        public List<Lands> LandsList { get; set; }

        public ObservableCollection<MenuitemViewModel> Menus { get; set; }

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
            this.LoadMenu();
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

        #region Methods

        private void LoadMenu()
        {
            Menus = new ObservableCollection<MenuitemViewModel>();

              Menus.Add(new MenuitemViewModel()
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile,
                 
            });

            Menus.Add(new MenuitemViewModel()
            {
                Icon = "ic_insert_chart",
                PageName = "StatisticPage",
                Title = Languages.Statistic,

            });

            Menus.Add(new MenuitemViewModel()
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,

            });

        }

        #endregion
    }
}
