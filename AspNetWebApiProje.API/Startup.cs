using AspNetWebApiProje.Core.Interfaces;
using AspNetWebApiProje.Data.Contexts;
using AspNetWebApiProje.Data.Repositories;
using AspNetWebApiProje.Service.Interfaces;
using AspNetWebApiProje.Service.Services;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebApiProje.API
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
            services.AddCors(opt =>
            {
                opt.AddPolicy("UdemyCors", o =>
                {
                    o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(RepositoryService<>));
            services.AddScoped<IPersonRepo,PersonRepo>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUow, Uow>();
            services.AddDbContext<PersonelContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database = PersonelAdresVTDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetWebApiProje.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetWebApiProje.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("UdemyCors");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
