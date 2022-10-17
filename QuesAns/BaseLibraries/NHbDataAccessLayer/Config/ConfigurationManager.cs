using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Reflection;

namespace NHbDataAccessLayer.Config
{
    public static class ConfigurationManager
    {

        public static string ConnectionString { get; set; }
        public static Configuration SetConfiguration()
        {
            var mapper = new ModelMapper();
            var config = new Configuration();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            config.DataBaseIntegration(x =>
            {
                //x.ConnectionString = "Data Source=U6031005-TPL-A;Initial Catalog=NHibernateExample;Integrated Security=True";
                //x.ConnectionString = "Server=DESKTOP-A5JEOLQ\\SQLEXPRESS;Database=SampleDB;User Id=Araf;Password=araf.hasan;";
                x.ConnectionString = ConnectionString;
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2008Dialect>();
            });
            config.AddAssembly(Assembly.GetExecutingAssembly());
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
            return config;
        }
    }
}
