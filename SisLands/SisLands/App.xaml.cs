
using SisLands.Helpers;
using SisLands.ViewModels;

namespace SisLands
{
    using SisLands.Views;
    using Xamarin.Forms;
    public partial class App : Application
	{
        #region Properties


	    public static NavigationPage Navigator { get; set; }


        #endregion

        #region Contructor
        public App()
        {
            InitializeComponent();

           // MainPage = new MasterPage();
            //aqui pregunto si ahya token o no:
            if (string.IsNullOrEmpty(Settings.Token))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModel = MainVIewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenTypeId;

                MainPage = new MasterPage();

            }

           
        }

	   

	    #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
