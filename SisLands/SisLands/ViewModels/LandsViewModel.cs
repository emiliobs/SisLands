using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SisLands.Models;
using SisLands.Services;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Application = Xamarin.Forms.Application;

namespace SisLands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {

        #region Services

        private ApiService apiService;

        #endregion

        #region Atributes

        private ObservableCollection<Lands> lands;

        #endregion

        #region Properties

        public ObservableCollection<Lands> Lands
        {
            get => lands;
            set
            {
                if (lands == value) return;
                {
                    lands = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Contructor

        public LandsViewModel()
        {
            apiService = new ApiService();

            LoadLands();
        }

        #endregion

        #region Methods


        private async void LoadLands()
        {
            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");

                //si i hay ningun tipo de red, regreso al main dela app
                await Application.Current.MainPage.Navigation.PopAsync();

                return;

            }

            var response = await apiService.GetList<Lands>("http://restcountries.eu", "/rest", "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");

                return;
            }

            var list = (List<Lands>) response.Result;
            this.Lands = new ObservableCollection<Lands>(list);
        }

        #endregion

    }
}
