using Autofac;
using QuesAnsLib.Repositories.Implementation;
using QuesAnsLib.Repositories.IRepository;
using QuesAnsLib.Services.Implementations;
using QuesAnsLib.Services.IServices;
using QuesAnsLib.UnitOfWorks.Implementations;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;

namespace QuesAnsLib
{
    public class QuesAnsLibModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public QuesAnsLibModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //-----------Repositories--------------------------------------------
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            //-------------------UnitOfWorks---------------------------------------
            builder.RegisterType<QuesAnsUnitOfWork>().As<IQuesAnsUnitOfWork>().InstancePerLifetimeScope();

            //------------------Services------------------------------------------
            builder.RegisterType<QuesAnsService>().As<IQuesAnsService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CashService<,>)).As(typeof(ICashService<,>)).InstancePerLifetimeScope();


            //builder.RegisterType<IndexModel>().AsSelf();
            base.Load(builder);
        }

    }
}
