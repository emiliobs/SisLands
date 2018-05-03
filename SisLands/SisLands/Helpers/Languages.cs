using System;
using System.Collections.Generic;
using System.Text;
using SisLands.Interfaces;
using SisLands.Resources;
using Xamarin.Forms;

namespace SisLands.Helpers
{
    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get => Resource.Accept;
           
        }

        public static string EmailValidator
        {                               
            get => Resource.EmailValidator;

        }

        public static string PasswordVaidator
        {
            get => Resource.PasswordValidator;

        }

        public static string Error
        {
            get => Resource.Error;

        }

        public static string SomethingWasWrong
        {
            get => Resource.SomethingWasWrong;

        }

        public static string Rememberme
        {
            get => Resource.Rememberme;

        }

        public static string EmailPlaceHolder
        {
            get => Resource.EmailPlaceHolder;

        }

        public static string PasswordPlaceHolder
        {
            get => Resource.PasswordPlaceHolder;

        }

        public static string Menu
        {
            get => Resource.Menu;

        }
    }
}
