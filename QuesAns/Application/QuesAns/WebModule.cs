using Autofac;
using QuesAns.Models;
using QuesAns.Models.AccountModels;
using QuesAns.Services.Contracts;
using QuesAns.Services.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuesAns.Areas.Admin.Models;

namespace QuesAns
{
    public class WebModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public WebModule(string connectionString, string migrationAssemblyName, IWebHostEnvironment webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmailService>().As<IEmailService>().InstancePerLifetimeScope();


            //builder.RegisterType<IndexModel>().AsSelf();
            builder.RegisterType<UserEmailOptionsModel>().AsSelf();
            builder.RegisterType<Areas.Admin.Models.UserVM>().AsSelf();
            builder.RegisterType<Models.AccountModels.UserVM>().AsSelf();
            base.Load(builder);
        }
    }
}
