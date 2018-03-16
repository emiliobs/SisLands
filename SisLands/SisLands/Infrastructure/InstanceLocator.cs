using System;
using System.Collections.Generic;
using System.Text;
using SisLands.ViewModels;

namespace SisLands.Infrastructure
{
    
    public class InstanceLocator
    {
        #region Properties         
        public MainVIewModel Main{ get; set; }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
              this.Main = new MainVIewModel();
        } 
        #endregion
    }
}
