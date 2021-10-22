using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Repositories;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Persistence.Contexts;
using HealthPlusPlus_AW.Persistence.Repositories;
using HealthPlusPlus_AW.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace HealthPlusPlus_AW
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("healthPlusPlus-api-in-memory");
            });
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "HealthPlusPlus_AW", Version = "v1"});
            });
            
            //Database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Startup));
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            
            
            services.AddScoped<IAppointmentDetailsRepository, AppointmentDetailsRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IClinicLocationRepository, ClinicLocationRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IMedicalHistoryRepository, MedicalHistoryRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IAppointmentDetailsService, IAppointmentDetailsService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IClinicLocationService, ClinicLocationService>();
            services.AddScoped<IClinicService, ClinicService>();
            services.AddScoped<IDiagnosticService, DiagnosticService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<IUserService, UserService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthPlusPlus_AW v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}