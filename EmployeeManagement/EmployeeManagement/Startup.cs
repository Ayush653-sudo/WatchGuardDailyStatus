using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
namespace EmployeeManagement
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
            services.AddMvc(x => {
                x.EnableEndpointRouting = false;
               
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                x.Filters.Add(new AuthorizeFilter(policy));
                });

            services.AddIdentity<ApplicationUser, IdentityRole>(options=>
                {
                    options.Password.RequiredLength = 10;
                    options.Password.RequiredUniqueChars = 3;
            }
                
                ).AddEntityFrameworkStores<AppDbContext>(); 
            
            //  services.AddSingleton<IEmployeeRepository, MockEmployeeRespository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            //AddSingleton will create only one instance  throughout lifetime of application 
            //AddTransient will create new instance everytime it is requested
            //AddScoped
            services.AddDbContextPool<AppDbContext>(
                options=>options.UseSqlServer(Configuration.GetConnectionString("EmployeeDBConnection"))
                );
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {

                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute(   
            );

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
