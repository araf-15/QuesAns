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
            //Lazy(true);
            Id(i => i.Id, map => map.Generator(Generators.GuidComb));
            Property(x => x.QuesTitle, m => { m.NotNullable(true); });
            Property(x => x.QuesDescription, m => { m.NotNullable(false); });
            Property(x => x.QuesTime, m => { m.NotNullable(true); });
            Property(x => x.QuesById, m => { m.NotNullable(true); });

            //Property(x => x.QuesBy, m => { m.Column("QuesById"); });
            OneToOne(x => x.QuesBy, c => c.ForeignKey("QuesById"));
            //ManyToOne(x => x.QuesBy, c => c.ForeignKey("QuesById"));
        }
    }
}
