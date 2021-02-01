using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Data;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeterinarySystems.Data.Doctors;
using VeterinarySystems.Data.Users;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using VeterinarySystems.Data.Addresses;
using VeterinarySystems.Data.Review;

namespace VeterinarySystems
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


            ///Enable CORS
            ///
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddCors(c =>
            {
            c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
            });


            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:5001"));
            });


            //line-1
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver =
                new DefaultContractResolver());


            services.AddDbContext<UserContext>(opt => opt.UseMySQL
            (Configuration.GetConnectionString("DatabaseConnection")                
                ));

           services.AddDbContext<DoctorContext>(opt1 => opt1.UseMySQL
            (Configuration.GetConnectionString("DatabaseConnection")));


            services.AddDbContext<AddressContext>(opt2 => opt2.UseMySQL
            (Configuration.GetConnectionString("DatabaseConnection")));



            services.AddDbContext<ReviewsContext>(opt3 => opt3.UseMySQL
            (Configuration.GetConnectionString("DatabaseConnection")));



            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });




            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepo, MysqlUserRepo>();

            services.AddScoped<IDoctorsRepo, MySqlDoctorRepo>();

            services.AddScoped<IAddressRepo, MySqlAddressRepo>();

            services.AddScoped<IReviewsRepo, MySqlReviewsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(options => options.AllowAnyOrigin());
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseCors(options => options.WithOrigins("https://localhost:5001"));



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
