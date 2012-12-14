using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using RepositoryBase.Models;

namespace RepositoryBase.NHibernate.Mappings
{
    public class BaseModelMap<T> : ClassMap<T> where T : BaseModel
    {
        public BaseModelMap()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.CreatedDate);
            Map(x => x.ModifiedDate);
        }
    }
}
