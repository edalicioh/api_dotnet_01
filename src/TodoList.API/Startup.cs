using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using TodoList.API.ViewModels;
using TodoList.Domain.Entities;
using TodoList.Infra.Context;
using TodoList.Infra.Interfaces;
using TodoList.Infra.Repositories;
using TodoList.Services.DTO;
using TodoList.Services.Interfaces;
using TodoList.Services.Services;

namespace TodoList.API
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

            #region AutoMapper
                var autoMapperConfig = new MapperConfiguration(cfg => {
                    cfg.CreateMap<User, UserDto >().ReverseMap();
                    cfg.CreateMap<CreateUserViewModel, UserDto >().ReverseMap();
                });
                services.AddSingleton(autoMapperConfig.CreateMapper());
            #endregion
            

            #region DI
                services.AddSingleton(d => Configuration);
                services.AddDbContext<TodoContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default")));
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoList.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoList.API v1"));
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
