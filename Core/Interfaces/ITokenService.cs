using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Signup signedUser);
    }
}
