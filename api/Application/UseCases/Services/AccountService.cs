using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Account;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Auth
{
    public class AccountService : IaccountService
    {
        private readonly UserManager<AppUser> _UserManager;
        private readonly ITokenService _Tokenservice;
        private readonly SignInManager<AppUser> _Signinmanager;

        public AccountService(UserManager<AppUser> usermanager, ITokenService tokenService, SignInManager<AppUser> signIn)
        {
            _UserManager = usermanager;
            _Tokenservice = tokenService;
            _Signinmanager = signIn;
        }

        public async Task<AppUser?> FindByname(string name)
        {
            var user = await _UserManager.FindByNameAsync(name);

            if (user == null) return null;

            return user;
        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var User = await _UserManager.FindByNameAsync(loginDto.UserName.ToLower());

            if (User == null) return new UserDto { errormessage = "user not found" };

            var result = await _Signinmanager.CheckPasswordSignInAsync(User, loginDto.Password, false);

            if (!result.Succeeded) return new UserDto { errormessage = "username or password incorrects" };

            return new UserDto
            {
                UserName = User.UserName!,
                Email = User.Email!,
                token = _Tokenservice.CreateToken(User)
            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var AppUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createduser = await _UserManager.CreateAsync(AppUser, registerDto.Password!);

                if (createduser.Succeeded)
                {
                    var role = await _UserManager.AddToRoleAsync(AppUser, "User");

                    if (role.Succeeded)
                    {
                        return new UserDto
                        {
                            UserName = AppUser.UserName!,
                            Email = AppUser.Email!,
                            token = _Tokenservice.CreateToken(AppUser)
                        };
                    }
                    else
                    {
                        return new UserDto { errormessage = role.Errors.ToString() };
                    }
                }
                else
                {
                    return new UserDto { errormessage = createduser.Errors.ToString() };
                }
            }
            catch (Exception ex)
            {
                return new UserDto { errormessage = ex.ToString() };
            }
        }
    }
}