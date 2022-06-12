using cwiczenie6.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace cwiczenie6.DataAcces
{

    public class MyDbContext : DbContext 
    {
        public MyDbContext()
        {
        }
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
 
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s20271;Integrated Security=True ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Birthdate).IsRequired();

                p.HasData(
                    new Patient { IdPatient = 1, FirstName = "Joanna", LastName = "Maliszewska", Birthdate= DateTime.Parse("1990-12-05")},
                    new Patient { IdPatient = 2, FirstName = "Kazimiera", LastName = "Kata", Birthdate= DateTime.Parse("1902-01-10")}
                );
            });    
            
            modelBuilder.Entity<Doctor>(p =>
            {
                p.HasKey(e => e.IdDoctor);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.Email).IsRequired().HasMaxLength(100);

                p.HasData(
                    new Doctor { IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "jkowalski@gugle.com" },
                    new Doctor { IdDoctor = 2, FirstName = "Kamil", LastName = "Doczesny", Email = "kdoczesny@gugle.com" }
                    );
            });

            modelBuilder.Entity<Prescription>(p =>
            {
                p.HasKey(e => e.IdPrescription);
                p.Property(e => e.Date).IsRequired();
                p.Property(e => e.DueDate).IsRequired();

                p.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                p.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);

                p.HasData(
                    new Prescription {IdPrescription = 1, Date = DateTime.Parse("2022-01-01"), DueDate = DateTime.Parse("2022-03-15"), IdDoctor = 1 , IdPatient = 2 },
                    new Prescription {IdPrescription = 2, Date = DateTime.Parse("2022-12-05"), DueDate = DateTime.Parse("2022-01-10"), IdDoctor = 2 , IdPatient = 2 }
                    );
            });

            modelBuilder.Entity<Medicament>(p =>
            {
                p.HasKey(e => e.IdMedicament);
                p.Property(e => e.Name).IsRequired().HasMaxLength(100);
                p.Property(e => e.Description).IsRequired().HasMaxLength(100);
                p.Property(e => e.Type).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Prescription_Medicament>(p =>
            {
                p.HasKey(e => new { e.IdMedicament, e.IdPresciption });
                p.HasOne(e => e.Medicament).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdMedicament);
                p.HasOne(e => e.Prescription).WithMany(e => e.Prescription_Medicaments).HasForeignKey(e => e.IdMedicament);
                p.Property(e => e.Details).IsRequired().HasMaxLength(100);
            });
        }
    }
}
