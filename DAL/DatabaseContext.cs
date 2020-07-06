using Microsoft.EntityFrameworkCore;
using SkcCurrencyApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkcCurrencyApi.DAL
{
    public class DatabaseContext: DbContext 
    { 
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyDetail> CurrencyDeatil { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DatabaseContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Currency>(eb =>
            {
                if (!Database.IsSqlite())
                {
                    eb.HasNoKey();
                }

                {
                    eb.HasKey(e => e.Id);
                }
            })
            .Entity<CurrencyDetail>(eb=> 
            
            { if(!Database.IsSqlite())
                {
                    eb.HasNoKey();
                }
                {
                    eb.HasKey(e => e.Id);
                    eb.Property(e => e.LastUpdateTime).HasConversion<DateTime>();
                }
            });
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite(@"Data Source=.\SQLITEDB\Test.db");
}
}
