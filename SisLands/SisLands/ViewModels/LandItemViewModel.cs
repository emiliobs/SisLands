 namespace SisLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using SisLands.Models;
    using SisLands.Views;
    using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
    using Application = Xamarin.Forms.Application;

    public class LandItemViewModel  : Lands
    {

        #region Commands 
        public ICommand SelectLandCommand
        {
            get => new RelayCommand(SelectLand);
        }
        #endregion
        #region Methods
        private async void SelectLand()
        {
            //con la palabra reservada this traigo todos los datos que viene con la seleccion del mismo.
            MainVIewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandTabbedPAge());
        } 
        #endregion
    }
}
