using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
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

        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filter;
        //private List<Lands> landsList;

        #endregion

        #region Properties

        public ObservableCollection<LandItemViewModel> Lands
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

        public bool IsRefreshing
        {
            get => isRefreshing;

            set
            {
                if (isRefreshing == value) return;
                {
                    isRefreshing = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Filter
        {
            get => filter;

            set
            {
                if (filter == value) return;
                {
                    filter = value;
                    OnPropertyChanged();

                    Search();
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

        #region Command

        public ICommand RefreshCommand
        {
            get => new RelayCommand(LoadLands);
        }

        public ICommand SearchCommand
        {
            get => new RelayCommand(Search);   
        }

        #endregion

        #region Methods

        private void Search()
        {
            if (string.IsNullOrEmpty(Filter))
            {
                   Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel());
            }
            else
            {
                //aqui utilizo el linquiu
                Lands = new ObservableCollection<LandItemViewModel>(ToLandItemViewModel().Where(
                    l=>l.Name.ToLower().Contains(Filter.ToLower()) || 
                       l.Capital.ToLower().Contains(Filter.ToLower())));
            }
        }

        private async void LoadLands()
        {
            IsRefreshing = true;

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRefreshing = false;

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

            MainVIewModel.GetInstance().LandsList = (List<Lands>) response.Result;

            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());

            IsRefreshing = false;
        }

        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainVIewModel.GetInstance().LandsList.Select(l => new LandItemViewModel()
            {
                 Name = l.Name,
                Capital = l.Capital,
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }

        #endregion

    }
}
