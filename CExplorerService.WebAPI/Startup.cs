﻿using CExplorerService.WebAPI.Data;
using CExplorerService.WebAPI.Repositories;
using CExplorerService.WebAPI.Services.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CExplorerService.WebAPI
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
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<CExplorerServiceContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CExplorerService")));

            services.AddScoped<CocktailRepository>();
            services.AddScoped<IngredientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                //    .CreateScope())
                //{
                //    var context = serviceScope.ServiceProvider.GetService<CExplorerServiceContext>(); //get DbContext 
                //    //Seeder.Seed(context);
                //}
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseMvc();
        }
    }
}
