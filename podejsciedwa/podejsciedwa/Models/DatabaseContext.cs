using podejsciedwa.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace podejsciedwa.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("podejsciedwaConnectionString") { }
        public DbSet<Film> Filmy { get; set; }
        public DbSet<Aktor> Aktorzy { get; set; }
        public DbSet<Biblioteka> Biblioteki { get; set; }
    }
}