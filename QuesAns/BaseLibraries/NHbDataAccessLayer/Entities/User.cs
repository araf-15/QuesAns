using System;

namespace NHbDataAccessLayer.Entities
{
    public class User : IEntity<Guid>
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserType { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string InstituteName { get; set; }
        public virtual string InstituteId { get; set; }
    }
}
