using System;
using AutoMapper.Configuration;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Extensions;
using HealthPlusPlus_AW.Security.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace HealthPlusPlus_AW.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppointmentDetails> AppointmentsDetails { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicLocation> ClinicLocations { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSec> UserSecs { get; set; }
        
        protected readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(_configuration.GetConnectionString("DefaultConnection"));
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //**********//
            //Categories//
            //**********//
            
            // Constraints
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            
            // Relationships
            builder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            //See Data
            builder.Entity<Category>().HasData
            (
                new Category {Id = 100, Name = "Fruits and Vegetables"},
                new Category {Id = 101, Name = "Dairy"}
            );
            
            //**********//
            //Products//
            //**********//
            
            // Constraints
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData(
                new Product {Id = 100, Name = "Apple", QuantityPackage = 1, UnitOfMeasurement = EUnitOfMeasurement.Unit, CategoryId = 100},
                new Product {Id = 101, Name = "Milk", QuantityPackage = 2, UnitOfMeasurement = EUnitOfMeasurement.Liter, CategoryId = 101},
                new Product {Id = 102, Name = "Lettuce", QuantityPackage = 2, UnitOfMeasurement = EUnitOfMeasurement.Liter, CategoryId = 101}
                );
                
            // ///////////
            // ///////////
            // /Health Plus Plus
            
            //**********//
            //Appointment Details//
            //**********//
            
            //Constraints
            builder.Entity<AppointmentDetails>().ToTable("Appointment Details");
            builder.Entity<AppointmentDetails>().HasKey(p => p.Id);
            builder.Entity<AppointmentDetails>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<AppointmentDetails>().Property(p => p.UserStartAt).IsRequired();
            builder.Entity<AppointmentDetails>().Property(p => p.DoctorStartAt).IsRequired();
            builder.Entity<AppointmentDetails>().Property(p => p.UserEndAt).IsRequired();
            builder.Entity<AppointmentDetails>().Property(p => p.DoctorEndAt).IsRequired();
            
            // Relationships
            builder.Entity<AppointmentDetails>()
                .HasMany(p => p.Appointments)
                .WithOne(p => p.AppointmentDetails)
                .HasForeignKey(p => p.AppointmentDetailsId);
            
            //Data
            builder.Entity<AppointmentDetails>().HasData
            (
                new AppointmentDetails {Id = 100, UserStartAt = DateTime.Now, DoctorStartAt = DateTime.Now, UserEndAt = DateTime.Now, DoctorEndAt = DateTime.Now, DiagnosticId = 100},
                new AppointmentDetails {Id = 101, UserStartAt = DateTime.Now, DoctorStartAt = DateTime.Now, UserEndAt = DateTime.Now, DoctorEndAt = DateTime.Now, DiagnosticId = 101}
            );

            //**********//
            //Appointment//
            //**********//
            
            //Constraints
            builder.Entity<Appointment>().ToTable("Appointment");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.StartAt).IsRequired();

            //Relationships

            //Data
            builder.Entity<Appointment>().HasData
            (
                new Appointment {Id = 100, StartAt = DateTime.Now, AppointmentDetailsId = 100, PatientId = 100, DoctorId= 102},
                new Appointment {Id = 101, StartAt = DateTime.Now, AppointmentDetailsId = 101, PatientId= 101, DoctorId= 103}
            );
            
            //**********//
            //Clinic//
            //**********//
            
            //Constraints
            builder.Entity<Clinic>().ToTable("Clinic");
            
            //Relationships
            builder.Entity<Clinic>()
                .HasMany(p => p.Doctors)
                .WithOne(p => p.Clinic)
                .HasForeignKey(p => p.ClinicId);
            builder.Entity<Clinic>()
                .HasMany(p => p.MedicalHistories)
                .WithOne(p => p.Clinic)
                .HasForeignKey(p => p.ClinicId);
            
            //DATA
            builder.Entity<Clinic>().HasData
            (
                new Clinic {Id = 104, Dni = "000000", Name = "Ricardo", Lastname = "Palma", Age = 10, ClinicLocationId = 100},
                new Clinic {Id = 105, Dni = "000000", Name = "San", Lastname = "Pablo", Age = 16, ClinicLocationId = 100}
            );
            
            //**********//
            //Clinic Location//
            //**********//
            
            //Constraints
            builder.Entity<ClinicLocation>().ToTable("Clinic Location");
            builder.Entity<ClinicLocation>().HasKey(p => p.Id);
            builder.Entity<ClinicLocation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ClinicLocation>().Property(p => p.Address).IsRequired();
            builder.Entity<ClinicLocation>().Property(p => p.CapitalCity).IsRequired();
            builder.Entity<ClinicLocation>().Property(p => p.Country).IsRequired();
            
            // Relationships
            builder.Entity<ClinicLocation>()
                .HasMany(p => p.Clinics)
                .WithOne(p => p.ClinicLocation)
                .HasForeignKey(p => p.ClinicLocationId);
            
            //DATA
            builder.Entity<ClinicLocation>().HasData
            (
                new ClinicLocation {Id = 100, Address = "My", CapitalCity = "Home", Country = "Jelou :)"},
                new ClinicLocation {Id = 101, Address = "My", CapitalCity = "Home", Country = "Bye :("}
            );
            
            //**********//
            //Diagnostic//
            //**********//
            
            //Constraints
            builder.Entity<Diagnostic>().ToTable("Diagnostic");
            builder.Entity<Diagnostic>().HasKey(p => p.Id);
            builder.Entity<Diagnostic>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Diagnostic>().Property(p => p.PublishDate).IsRequired().HasMaxLength(30);
            builder.Entity<Diagnostic>().Property(p => p.Description).IsRequired().HasMaxLength(30);

            //Relationships
            
            builder.Entity<Diagnostic>()
                .HasMany(p => p.AppointmentDetails)
                .WithOne(p => p.Diagnostic)
                .HasForeignKey(p => p.DiagnosticId);
            
            //DATA
            builder.Entity<Diagnostic>().HasData
            (
                new Diagnostic {Id = 100,PublishDate = DateTime.Now, Description = "New Diagnostic", SpecialtyId = 100},
                new Diagnostic {Id = 101,PublishDate = DateTime.Now, Description = "New Diagnostic 2", SpecialtyId = 101}
            );
            
            //**********//
            //Doctor//
            //**********//

            //Constraints
            builder.Entity<Doctor>().ToTable("Doctor");

            //Relationships
            builder.Entity<Doctor>()
                .HasMany(p => p.Appointments)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId);
            
            //DATA
            builder.Entity<Doctor>().HasData
            (
                new Doctor {Id = 102, Dni = "000000", Name = "Ricardo", Lastname = "Palma", Age = 10, SpecialtyId = 100, ClinicId = 104},
                new Doctor {Id = 103, Dni = "000000", Name = "San", Lastname = "Pablo", Age = 16, SpecialtyId = 101, ClinicId = 104}
            );
            
            //**********//
            //Medical History//
            //**********//
            
            //Constraints
            builder.Entity<MedicalHistory>().ToTable("Medical History");
            builder.Entity<MedicalHistory>().HasKey(p => p.Id);
            builder.Entity<MedicalHistory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            //Relationships
            builder.Entity<MedicalHistory>()
                .HasMany(p => p.Diagnostics)
                .WithOne(p => p.MedicalHistory)
                .HasForeignKey(p => p.MedicalHistoryId);

            //DATA
            builder.Entity<MedicalHistory>().HasData
            (
                new MedicalHistory {Id = 100, PatientId = 100, ClinicId = 100},
                new MedicalHistory {Id = 101, PatientId = 101, ClinicId = 101}
            );
            
            //**********//
            //Patient//
            //**********//
            
            //Constraints
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Patient>().Property(p => p.Address).IsRequired();

            //Relationships
            builder.Entity<Patient>()
                .HasMany(p => p.MedicalHistories)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);
            builder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);
            
            //DATA
            builder.Entity<Patient>().HasData
            (
                new Patient {Id = 100, Dni = "000000", Name = "Rick", Lastname = "Sanchez", Age = 10, Address = "Home"},
                new Patient {Id = 101, Dni = "000000", Name = "Morty", Lastname = "Smith", Age = 10, Address = "Home"}
            );
            
            //**********//
            //Specialty//
            //**********//
            
            //Constraints
            builder.Entity<Specialty>().ToTable("Specialty");
            builder.Entity<Specialty>().HasKey(p => p.Id);
            builder.Entity<Specialty>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Specialty>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Specialty>().Property(p => p.Description).IsRequired().HasMaxLength(30);

            // Relationships
            builder.Entity<Specialty>()
                .HasMany(p => p.Diagnostics)
                .WithOne(p => p.Specialty)
                .HasForeignKey(p => p.SpecialtyId);
            builder.Entity<Specialty>()
                .HasMany(p => p.Doctors)
                .WithOne(p => p.Specialty)
                .HasForeignKey(p => p.SpecialtyId);
            
            //DATA
            builder.Entity<Specialty>().HasData
            (
                new Specialty {Id = 100, Name = "Cardiology", Description = "Beep beep"},
                new Specialty {Id = 101, Name = "Yes", Description = "Yes"}
            );
            
            // builder.Entity<Diagnostic>()
            //     .HasOne(p => p.Specialty)
            //     .WithMany(p => p.Diagnostics)
            //     .HasForeignKey(p => p.SpecialtyId);
            
            //**********//
            //User//
            //**********//
            
            //Constraints
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Dni).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Lastname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Age).IsRequired();
            
            builder.Entity<UserSec>().ToTable("UserSec");
            builder.Entity<UserSec>().HasKey(p => p.Id);
            builder.Entity<UserSec>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserSec>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<UserSec>().Property(p => p.LastName).IsRequired().HasMaxLength(30);
            builder.Entity<UserSec>().Property(p => p.Username).IsRequired().HasMaxLength(30);

            builder.UseSnakeCaseNamingConvention(); 
        }
    }
}