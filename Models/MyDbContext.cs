using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Microsoft.EntityFrameworkCore;

namespace dotnet2.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){}

        public DbSet<Pessoa> Pessoas{get;set;}
        public DbSet<Fisica> Fisicas{get;set;}
        public DbSet<Juridica> Juridicas{get;set;}
        public DbSet<ReservaHotel> ReservaHotels{get;set;}
        public DbSet<Parceiro> Parceiros{get;set;}



    }
}