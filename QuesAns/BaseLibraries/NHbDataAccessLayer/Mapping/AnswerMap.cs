using NHbDataAccessLayer.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace NHbDataAccessLayer.Mapping
{
    public class AnswerMap : ClassMapping<Answer>
    {
        public AnswerMap()
        {
            Schema("[dbo]");
            Table("[Answers]");
            //Lazy(true);
            Id(i => i.Id, map => map.Generator(Generators.GuidComb));
            Property(x => x.AnswerDescription, m => { m.NotNullable(true); });
            Property(x => x.AnswerTime, m => { m.NotNullable(false); });
            Property(x => x.QuestionId, m => { m.NotNullable(true); });
            Property(x => x.AnswerById, m => { m.NotNullable(true); });

            //Property(x => x.QuesBy, m => { m.Column("QuesById"); });
            //OneToOne(x => x.QuesBy, c => c.ForeignKey("QuesById"));
            //ManyToOne(x => x.QuesBy, c => c.ForeignKey("QuesById"));
        }
    }
}
