using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.sqlite;
using Microsoft.EntityFrameworkCore.InMemory;
using TODO.Models;
using TODO.Helpers;

namespace TODO
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
            services.AddDbContext<DataContext>(options => options.UseSqlite("Filename=TODO.db"));
            // services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}

            // var context = app.ApplicationServices.GetService<DataContext>();
            // AddTestData(context);
            
            // app.UseHttpsRedirection();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            app.UseMvc();
        }

        private static void AddTestData(DataContext context)
        {
            context.Todos.Add(new Todo
            {
                Id = 1,
                TodoItem = "first item",
                DateAdded = DateTime.Now.AddDays(-10),
                DateFinished = DateTime.Now.AddDays(-8)
            });
            context.Todos.Add(new Todo
            {
                Id = 2,
                TodoItem = "second item",
                DateAdded = DateTime.Now.AddDays(-7),
                DateFinished = DateTime.Now.AddDays(-3)
            });
            context.Todos.Add(new Todo
            {
                Id = 3,
                TodoItem = "coding...",
                DateAdded = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}
