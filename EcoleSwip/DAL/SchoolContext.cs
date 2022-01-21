using System;
using EcoleSwip.Models.School;
using Microsoft.EntityFrameworkCore;

namespace EcoleSwip.DAL
{
    public class SchoolContext : Microsoft.EntityFrameworkCore.DbContext
    {

        //BDD
        public DbSet<School> DbSchools { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseMySQL("server=localhost;database=dbschool;User Id=root;Password=Iwtbr@School-d");

        }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.SchoolID);
                entity.Property(e => e.Nom).IsRequired();
            });
        }
    }
}
