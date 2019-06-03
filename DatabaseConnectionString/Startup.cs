using DatabaseConnectionString.Data;
using DatabaseConnectionString.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace DatabaseConnectionString
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ConnectionStringsDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("LocalConnectionStringsDbContext")));
            services.AddScoped<IConnectionString, ConnectionStringRepository>();
            services.AddSwaggerGen(x =>
                x.SwaggerDoc("v1", new Info {Title = "CCCOne Connection String API", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "API for CCCOne Connection Strings"));
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
