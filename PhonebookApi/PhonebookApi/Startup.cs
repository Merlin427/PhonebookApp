using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhonebookApi.Data;
using PhonebookApi.Repositories;
using PhonebookApi.Services;

namespace PhonebookApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql("Host=localhost; Database=phoneApp; Username=postgres; Password=Danie427*; port=5432;"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPhonebookRepo, PhonebookRepo>();
            services.AddScoped<IPhoneBookEntryRepo, PhoneBookEntryRepo>();
            services.AddScoped<IPhonebookService, PhoneBookService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection(); 

            app.UseRouting();

            app.UseEndpoints(endpoints => {endpoints.MapControllers();});
        }
    }
}