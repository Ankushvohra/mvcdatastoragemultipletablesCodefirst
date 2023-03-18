using mvcregister.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcregister.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("cns")
        {
            
        }
        public DbSet<Country> countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Register> registers { get; set; }
    }
}