using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Models;
using NHibernate;

namespace RepositoryBase.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        T Save<T>(T model) where T : BaseModel;
        T GetById<T>(Guid id) where T : BaseModel;
    }
}
