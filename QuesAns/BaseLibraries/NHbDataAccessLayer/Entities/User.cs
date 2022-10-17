namespace NHbDataAccessLayer.Entities
{
    public class User : IEntity<int>
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
