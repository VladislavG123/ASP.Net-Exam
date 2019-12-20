using EarthquakeSite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeSite.DataAccess
{
    public class EarthquakeContext : DbContext
    {
        public EarthquakeContext(DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
    }
}
