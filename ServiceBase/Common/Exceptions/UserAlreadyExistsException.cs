using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBase.Common.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public virtual string Email { get; private set; }

        public UserAlreadyExistsException(string email)
        {
            Email = email;
        }
    }
}
