using Microsoft.EntityFrameworkCore;
using ParcelDeliveryService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Data
{


    public class DataContext : DbContext
    {

        public DbSet<Locker> Lockers { get; set; }
        public DbSet<Parcel> Parcels { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Locker>()
                .HasMany(x => x.Parcels)
                .WithOne(a => a.Locker)
                .HasForeignKey(b => b.LockerId);
        }

    }
}
