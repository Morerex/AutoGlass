using AutoMapper;
using Autoglass.Architecture.Application.Models;
using Autoglass.Architecture.Domain.Entities;
using Autoglass.Architecture.Domain.Interfaces;
using Autoglass.Architecture.Infra.Data.Context;
using Autoglass.Architecture.Infra.Data.Repository;
using Autoglass.Architecture.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Autoglass.Architecture.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MySqlContext>(options =>
            {
                var server = Configuration["database:mysql:server"];
                var port = Configuration["database:mysql:port"];
                var database = Configuration["database:mysql:database"];
                var username = Configuration["database:mysql:username"];
                var password = Configuration["database:mysql:password"];

                options.UseMySql($"Server={server};Port={port};Database={database};Uid={username};Pwd={password}", opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });



            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateProdutoModel, Produto>();
                config.CreateMap<UpdateProdutoModel, Produto>();
                config.CreateMap<Produto, ProdutoModel>();
            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
