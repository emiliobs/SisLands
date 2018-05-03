using System.Threading;

namespace SisLands.Domain
{
    using System.Data.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class DataContext  : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
           
        }
    }
}
