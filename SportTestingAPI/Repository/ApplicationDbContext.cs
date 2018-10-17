using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportTestingAPI.Models;
namespace SportTestingAPI.Repository
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Athlete_metrics> Athlete_metrics { get; set; }

        public DbSet<Combine_athlete_metrics> Combine_athlete_metrics { get; set; }
        public DbSet<Combine_drills> Combine_drills { get; set; }
        public DbSet<Combine_metrics> Combine_metrics { get; set; }
        public DbSet<Combines> Combines { get; set; }

        public DbSet<Drill_data> Drill_data { get; set; }
        public DbSet<Drills> Drills { get; set; }

        public DbSet<Participants> Participants { get; set; }
        public DbSet<Sports> Sports { get; set; }
        public DbSet<Users> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // EF will use names of the DbSets to determine the table name.
            // Here we use the singular form of the object 
            modelBuilder.Entity<Combine_athlete_metrics>().ToTable(nameof(Combine_athlete_metrics));
            modelBuilder.Entity<Combine_drills>().ToTable(nameof(Combine_drills));
            modelBuilder.Entity<Combine_metrics>().ToTable(nameof(Combine_metrics));
            modelBuilder.Entity<Combines>().ToTable(nameof(Combines));
            modelBuilder.Entity<Drill_data>().ToTable(nameof(Drill_data));
            modelBuilder.Entity<Drills>().ToTable(nameof(Drills));
            modelBuilder.Entity<Participants>().ToTable(nameof(Participants));
            modelBuilder.Entity<Sports>().ToTable(nameof(Sports));
            modelBuilder.Entity<Users>().ToTable(nameof(Users));



            //modelBuilder.Entity<Users >()
            //.HasOne<Participants>(e => e.Participants)
            //.WithMany(d => d.Users)
            
            //.HasForeignKey(e => e.user_id  );



            //modelBuilder.Entity<Employee>()
            //            .HasOne<Department>(e => e.Department)
            //            .WithMany(d => d.Employees)
            //            .HasForeignKey(e => e.DeptID);


        }

    }


}
