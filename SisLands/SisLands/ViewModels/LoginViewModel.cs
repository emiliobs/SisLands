

using System.ComponentModel;
using System.Runtime.CompilerServices;
using SisLands.Annotations;

namespace SisLands.ViewModels
{
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;
    using GalaSoft.MvvmLight.Command;


    public class LoginViewModel : BaseViewModel 
    {
        

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
            IsRemembered = true;
            IsEnabled = true;

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

            if (this.Email != "eabs@hotmail.com" || this.Password != "Eabs123.")
            {

                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", "Email or Password Incorrect.!", "Accept");

               
                this.Password = string.Empty;

                return;
            }

            this.IsRunning =  false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert("OK", "Fuck Yeaaah", "Accept");

            
        }

        #endregion


    }
}
