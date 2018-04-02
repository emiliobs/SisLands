

using System.Linq;

namespace SisLands.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using SisLands.Models;
    public class LandViewModel  : BaseViewModel
    {

        #region Atributes

        private ObservableCollection<Border> _borders;
        private ObservableCollection<Currency> _currencies;

        #endregion

        #region Properties

        public Lands Land { get; set; }

        public ObservableCollection<Currency> Currencies
        {
            get => _currencies;
            set
            {
                if (_currencies == value) return;
                {
                    _currencies = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Border> Borders
        {
            get => _borders;
            set
            {
                if (_borders == value) return;
                {
                    _borders = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region COnstructor
        public LandViewModel(Lands land)
        {
            this.Land = land;

            LoadBorders();
            Currencies = new ObservableCollection<Currency>(Land.Currencies);
        }

        #endregion

        #region Methods

        private void LoadBorders()
        {
            Borders = new ObservableCollection<Border>();

            foreach (var border in Land.Borders)
            {
                var land = MainVIewModel.GetInstance().LandsList.FirstOrDefault(l => l.Alpha3Code == border);

                if (land != null)
                {
                    this.Borders.Add(new Border()
                    {
                        Code = land.Alpha3Code,
                        Name = land  .Name,
                    });
                }
            }
        }

        #endregion
    }
}
