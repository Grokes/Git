using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Git
{
    internal class DataBase: DbContext
    {
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<GrowthOfShares> GrowthOfShares { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = new SqliteConnectionStringBuilder();
                connectionString.DataSource = "GoodInvest.db";
                optionsBuilder.UseSqlite(connectionString.ConnectionString);
            }
        }
    }

    
}
