using System;

namespace NHbDataAccessLayer.Entities
{
    public class Question : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }

        public virtual string QuesTitle { get; set; }
        public virtual string QuesDescription { get; set; }
        public virtual DateTime QuesTime { get; set; }

        public virtual Guid QuesById { get; set; }
        //public virtual User QuesBy { get; set; }
    }
}
