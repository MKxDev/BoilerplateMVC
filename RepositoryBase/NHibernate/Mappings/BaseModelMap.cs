using DomainModels;
using FluentNHibernate.Mapping;

namespace RepositoryBase.NHibernate.Mappings
{
    public class BaseModelMap<T> : ClassMap<T> where T : BaseModel
    {
        public BaseModelMap()
        {
            Id(x => x.Id).Unique().GeneratedBy.Guid();
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedDate);
        }
    }
}
