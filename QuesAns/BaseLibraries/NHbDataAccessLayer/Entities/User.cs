namespace NHbDataAccessLayer.Entities
{
    public class User
    {
        public virtual int Id { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
    }
}
