using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class IESYazilimContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ITSPTS;Trusted_Connection=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Carrier> carrier { get; set; }
        public DbSet<ProductList> productList { get; set; }
        public DbSet<SerialNumber> serialNumber { get; set; }
        public DbSet<Transfer> transfer { get; set; }
    }
}
