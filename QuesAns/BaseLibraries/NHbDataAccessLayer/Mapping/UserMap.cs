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
            Id(i => i.Id, map => map.Generator(Generators.GuidComb));
            Property(x => x.FirstName, m => { m.NotNullable(true); });
            Property(x => x.LastName, m => { m.NotNullable(false); });
            Property(x => x.UserName, m => { m.NotNullable(true); });
            Property(x => x.UserType, m => { m.NotNullable(true); });
            Property(x => x.PasswordHash, m => { m.NotNullable(true); });
            Property(x => x.InstituteName, m => { m.NotNullable(true); });
            Property(x => x.InstituteId, m => { m.NotNullable(false); });
        }
    }
}
