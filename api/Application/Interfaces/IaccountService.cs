using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Models;

namespace api.Interfaces
{
    public interface IaccountService
    {
        Task<UserDto> LoginAsync(LoginDto request);
        Task<UserDto> RegisterAsync(RegisterDto request);
        Task<AppUser?> FindByname(string name);
    }
}