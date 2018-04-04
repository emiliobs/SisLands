  


using System;

namespace SisLands.ViewModels
{
    using SisLands.Services;
    using SisLands.Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;


    public class LoginViewModel : BaseViewModel 
    {

        #region Services

        private ApiService apiServices;

        #endregion

        #region Atributes

        private string email;
        private string password;
        private bool isRunning;
        private bool isRemembered;
        private bool isEnabled;

        #endregion

        #region Properties

        public string Email
        {
            get => this.email;
            set
            {
                if (this.email == value) return;
                this.email = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => this.password;
            set
            {
                if (this.password == value) return;
                this.password = value;
                OnPropertyChanged();
            }
        }

        public bool IsRunning
        {
            get => this.isRunning;
            set
            {
                if (this.isRunning == value) return;

                this.isRunning = value;
                OnPropertyChanged();
            }
        }

        public bool IsRemembered
        {
            get => this.isRemembered;
            set
            {
                if (this.isRemembered == value) return;

                this.isRemembered = value;
                OnPropertyChanged();
            }
        }

        public bool IsEnabled
        {
            get => this.isEnabled;
            set
            {
                if (this.isEnabled == value) return;

                this.isEnabled = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Contructor
        public LoginViewModel()
        {
            apiServices = new ApiService();

            IsRemembered = true;
            IsEnabled = true;

            //Email = "eabs@hotmail.com";
            //Password = "Eabs123.";

        }
        #endregion

        #region Commands
        public ICommand LoginCommand => new RelayCommand(Login);



        #endregion

        #region Methods

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must an E-Mail.", "Accept");

                return;
            }


            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You must an Password.", "Accept");

                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            //if (this.Email != "eabs@hotmail.com" || this.Password != "Eabs123.")
            //{

            //    this.IsRunning = false;
            //    this.IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert("Error", "Email or Password Incorrect.!", "Accept");


            //    this.Password = string.Empty;

            //    return;
            //}

            //aqui valido que haya conexion:
            var connection = await apiServices.CheckConnection();

            //Si no hay conexion:
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Eccept");

                return;
            }

            //Si hay Conexión:
            //Aqui utlizo el token:
            //var token = await apiServices.GetToken("http://localhost:57505/", Email, Password);
            var token = await apiServices.GetToken("http://landsapi1.azurewebsites.net", Email, Password);


            //aqui pregunto si el objeto token es nulo:
            if (token == null)
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Something was wrong, Please try Again.!!",
                    "Accept");
                return;

            }

            //Aqui pregunto si no viene token:
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", token.ErrorDescription, "Accept");

                Password = String.Empty;

                return;
            }

            //Si llego aqui ya tengo token:(seguridad)
            //genero un apuntador:
            var mainViewModel = MainVIewModel.GetInstance();

            mainViewModel.Token = token;
            mainViewModel.Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            //await Application.Current.MainPage.DisplayAlert("OK", "Fuck Yeaaah", "Accept");
            this.IsRunning = true;
            this.IsEnabled = false;

            this.IsRunning =  false;
            this.IsEnabled = true;

            Email = string.Empty;
            Password = string.Empty;

           


        }

        #endregion


    }
}
