using Autofac;
using Autofac.Extensions.DependencyInjection;
using Membership;
using Membership.BussinessObjects;
using Membership.Context;
using Membership.Entities;
using Membership.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHbDataAccessLayer.Config;
using QuesAns;
using QuesAns.Models.AccountModels;
using QuesAnsLib;
using System;

namespace QuesAns
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
            WebHostEnvironment = env;

        }

        public IConfiguration Configuration { get; }
        public static ILifetimeScope AutofacContainer { get; private set; }
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionStringName = "DefaultConnection";
            var connectionString = Configuration.GetConnectionString(connectionStringName);
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;

            builder.RegisterModule(new WebModule(connectionString, migrationAssemblyName, WebHostEnvironment));
            //builder.RegisterModule(new FoundationModule(connectionString, migrationAssemblyName));
            //builder.RegisterModule(new MembershipModule(connectionString, migrationAssemblyName));
            builder.RegisterModule(new QuesAnsLibModule(connectionString, migrationAssemblyName));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionStringName = "DefaultConnection";
            var connectionString = Configuration.GetConnectionString(connectionStringName);
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;

            ConfigurationManager.ConnectionString = connectionString;


            services.Configure<SMTPConfigModel>(Configuration.GetSection("SMTPConfig"));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName)));

            //services.AddDbContext<ShoppingDbContext>(options =>
            //    options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationAssemblyName)));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            // Identity Customization started here
            services
                .AddIdentity<ApplicationUser, Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<UserManager>()
                .AddRoleManager<RoleManager>()
                .AddSignInManager<SignInManager>()
                //.AddDefaultUI()
                .AddDefaultTokenProviders();

            // Identity Customization ended here


            services.Configure<IdentityOptions>(options =>
            {
                //Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                //Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                //User Settings
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;

                //Signin Settings
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddAuthentication()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                    options.LogoutPath = new PathString("/Account/Logout");
                    options.Cookie.Name = "CustomerPortal.Identity";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                });


            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "285613095745-sa0aigp4simhn1bc5q4ht39t3erd7mkc.apps.googleusercontent.com";
                    googleOptions.ClientSecret = "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";
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = "1633511590350843";
                    facebookOptions.AppSecret = "285c4f31000c89de4c53ddad89b70c02";
                });


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(4);
            });



            /*.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"]
                };
            });
            */

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("RequireImage", policy =>
                //{
                //    policy.AuthenticationSchemes.Clear();
                //    policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
                //    policy.RequireAuthenticatedUser();
                //    policy.Requirements.Add(new ImageRequirement());
                //});

                options.AddPolicy("AccessRequirement", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.Requirements.Add(new AccessRequirement());
                });

                options.AddPolicy("AdminAccess", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Admin");
                    //policy.RequireRole("SuperAdmin");
                });
            });
            services.AddSingleton<IAuthorizationHandler, AccessRequirementHandler>();
            //services.AddSingleton<IAuthorizationHandler, AgeRequirementHandler>();


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
