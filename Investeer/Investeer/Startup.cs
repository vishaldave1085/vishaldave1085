using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Investeer.Models;
using Investeer.DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Investeer.DataAccess.Repository.IRepository;
using Investeer.DataAccess.Repository;
using Investeer.Utility;
using Investeer.Models.ViewModels;
using Investeer.Models.Models;
using AutoMapper;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace Investeer
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("InvestConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
            })

               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Investeer.Utility.AutoMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<EmailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("en-US");
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ErrorHandlingFilter));
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            //serviceProvider.SeedRoles().Wait();
            //serviceProvider.SeedUser().Wait();

            app.UseAuthentication();
            app.UseRequestLocalization();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
