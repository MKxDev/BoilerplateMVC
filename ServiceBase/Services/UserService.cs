using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryBase.Repositories;

namespace ServiceBase.Services
{
    public class UserService : BaseRepositoryService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
