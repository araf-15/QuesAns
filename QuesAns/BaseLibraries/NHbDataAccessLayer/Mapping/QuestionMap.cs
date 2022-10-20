using NHbDataAccessLayer.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace NHbDataAccessLayer.Mapping
{
    public class QuestionMap : ClassMapping<Question>
    {
        public QuestionMap() 
        {
            Schema("[dbo]");
            Table("[Questions]");
            Id(i => i.Id, map => map.Generator(Generators.GuidComb));
            Property(x => x.QuesTitle, m => { m.NotNullable(true); });
            Property(x => x.QuesDescription, m => { m.NotNullable(false); });
            Property(x => x.QuesTime, m => { m.NotNullable(true); });
            Property(x => x.QuesById, m => { m.NotNullable(true); });

            ////OneToOne(x => x.QuesBy, c => c.ForeignKey("Id"));
            //ManyToOne(x => x.QuesById.ToString(), c => c.ForeignKey("FK_Questions_User"));
        }
    }
}
