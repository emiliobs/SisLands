

namespace SisLands.Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SisLands.Domain;
    public class LocalDataContext    : DataContext
    {
        public System.Data.Entity.DbSet<SisLands.Domain.User> Users { get; set; }
    }
}