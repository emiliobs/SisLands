using System;
using System.Collections.Generic;
using System.Text;
using SisLands.Models;

namespace SisLands.ViewModels
{
    public class LandViewModel
    {
        #region Properties

        public Lands Land { get; set; }

        #endregion

        #region COnstructor
        public LandViewModel(Lands land)
        {
            this.Land = land;
        } 
        #endregion
    }
}
