using HealthPlusPlus_AW.Example.Domain.Repositories;
using HealthPlusPlus_AW.Example.Domain.Services;
using HealthPlusPlus_AW.Example.Persistence.Repositories;
using HealthPlusPlus_AW.Example.Services;
using HealthPlusPlus_AW.Heal.Domain.Repositories;
using HealthPlusPlus_AW.Heal.Domain.Services;
using HealthPlusPlus_AW.Heal.Persistance;
using HealthPlusPlus_AW.Heal.Services;
using HealthPlusPlus_AW.meeting.Domain.Repositories;
using HealthPlusPlus_AW.meeting.Domain.Services;
using HealthPlusPlus_AW.meeting.Persistance;
using HealthPlusPlus_AW.meeting.Services;
using HealthPlusPlus_AW.Profile.Domain.Repositories;
using HealthPlusPlus_AW.Profile.Domain.Services;
using HealthPlusPlus_AW.Profile.Persistance;
using HealthPlusPlus_AW.Profile.Services;
using HealthPlusPlus_AW.Shared.Domain.Repositories;
using HealthPlusPlus_AW.Shared.Persistance.Contexts;
using HealthPlusPlus_AW.Shared.Persistance.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            
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
            
            services.AddScoped<IAppointmentDetailsService, AppointmentDetailsService>();
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