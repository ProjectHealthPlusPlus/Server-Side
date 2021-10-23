using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HealthPlusPlus_AW.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

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
            
            //Relationships
            
            
            //**********//
            //Appointment//
            //**********//
            
            //Constraints
            builder.Entity<Appointment>().ToTable("Appointment");
            builder.Entity<Appointment>().HasKey(p => p.Id);
            builder.Entity<Appointment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.StartAt).IsRequired();

            //Relationships

            //**********//
            //Clinic//
            //**********//
            
            //Constraints
            builder.Entity<Clinic>().ToTable("Clinic");
            
            //Relationships
            
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
            
            //Relationships
            
            //**********//
            //Diagnostic//
            //**********//
            
            //Constraints
            builder.Entity<Diagnostic>().ToTable("Diagnostic");
            builder.Entity<Diagnostic>().HasKey(p => p.Id);
            builder.Entity<Diagnostic>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Diagnostic>().Property(p => p.PublishDate).IsRequired();
            builder.Entity<Diagnostic>().Property(p => p.Description).IsRequired();
            
            //Relationships
            
            //**********//
            //Doctor//
            //**********//
            
            //Constraints
            builder.Entity<Doctor>().ToTable("Doctor");

            //Relationships
            
            //**********//
            //Medical History//
            //**********//
            
            //Constraints
            builder.Entity<MedicalHistory>().ToTable("Medical History");
            builder.Entity<MedicalHistory>().HasKey(p => p.Id);
            builder.Entity<MedicalHistory>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            //Relationships
            
            //**********//
            //Patient//
            //**********//
            
            //Constraints
            builder.Entity<Patient>().ToTable("Patient");
            builder.Entity<Patient>().Property(p => p.Address).IsRequired();

            //Relationships
            
            //**********//
            //Specialty//
            //**********//
            
            //Constraints
            builder.Entity<Specialty>().ToTable("Specialty");
            builder.Entity<Specialty>().HasKey(p => p.Id);
            builder.Entity<Specialty>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Specialty>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Specialty>().Property(p => p.Description).IsRequired().HasMaxLength(30);

            //Relationships
            
            builder.Entity<Specialty>().HasData
            (
                new Specialty() {Id = 100, Name = "No", Description = "No"},
                new Specialty() {Id = 101, Name = "Yes", Description = "Yes"}
            );
            
            //**********//
            //User//
            //**********//
            
            //Constraints
            builder.Entity<User>().ToTable("User");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Dni).IsRequired().HasMaxLength(2);
            builder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Lastname).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Age).IsRequired();

            builder.Entity<User>().HasData
            (
                new User() {Id = 100, Dni = "73386178", Name = "Diego", Lastname = "HZ", Age = 21}
            );

            //Relationships
            
            builder.UseSnakeCaseNamingConvention(); 
        }
    }
}