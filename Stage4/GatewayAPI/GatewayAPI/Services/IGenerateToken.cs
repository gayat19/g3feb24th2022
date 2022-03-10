using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayAPI.Services
{
    public interface IGenerateToken<T>
    {
        string CreateToken(T user);
    }
}
