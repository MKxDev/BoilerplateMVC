using System;

namespace DomainModels
{
    public abstract class BaseModel
    {
        public virtual Guid Id { get; private set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
    }
}
