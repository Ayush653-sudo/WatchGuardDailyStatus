using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tooth_Booth_API.BusinessLogic;
using Tooth_Booth_API.BusinessLogic.Interface;
using Tooth_Booth_API.Data;
using Microsoft.OpenApi.Models;
using Tooth_Booth_API.UOW.Interface;
using Tooth_Booth_API.UOW;
using Tooth_Booth_API.Helper;
using System.Diagnostics.CodeAnalysis;




namespace Tooth_Booth_API
{

    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public async void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false; 
            }).AddNewtonsoftJson();
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToothBooth",
                    Description = "Clean mouth nourish future",
                });
            });
            services.AddDbContext<ApiDBContext>(
               options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
              );
          

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApiDBContext>();
            services.AddScoped<IAuthBusiness, AuthBusiness>();
              services.AddScoped<IClinicsBusiness,ClinicsBusinesscs>();
            services.AddScoped<IDentistBusiness,DentistBusiness>();
            services.AddScoped<IAppointmentBusiness, AppointmentBusiness>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

          //  app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
                });
            }
            

            app.UseHttpsRedirection();
           

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {



                endpoints.MapControllers();
                  
            });
        }
    }
}
