namespace SisLands.Backend.Models
{
    using System.Data.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using SisLands.Domain;
    public class LocalDataContext : DataContext
    {
        public LocalDataContext()
        {
        }

        public System.Data.Entity.DbSet<SisLands.Domain.User> Users { get; set; }
    }
}