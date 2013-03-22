namespace DomainModels
{
    public class User : BaseModel
    {
        public virtual string Email { get; set; }
        public virtual string Salt { get; set; }
        public virtual string Hash { get; set; }
    }
}
