using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBase.Services.Interfaces
{
    public interface IEncryptionService
    {
        string GenerateSalt(int size = 10);
        string GenerateHash(string input);
    }
}
