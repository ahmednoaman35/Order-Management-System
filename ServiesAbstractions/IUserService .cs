using Sheared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiesAbstractions
{
    public interface IUserService
    {
        public Task<UserResultDto> RegisterAsync(UserRegisterDto dto);
        public Task<UserResultDto>  LoginAsync(LoginDto dto);  // returns JWT token

    }
}
