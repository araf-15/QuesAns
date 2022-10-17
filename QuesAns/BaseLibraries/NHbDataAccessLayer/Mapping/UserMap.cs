using NHbDataAccessLayer.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHbDataAccessLayer.Mapping
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Schema("[dbo]");
            Table("[User]");
            Id(i => i.Id, map => map.Generator(Generators.Increment));
            Property(x => x.FirstName, m => { m.NotNullable(true); });
            Property(x => x.LastName, m => { m.NotNullable(true); });
        }
    }
}
