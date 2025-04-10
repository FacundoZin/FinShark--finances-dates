using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Account
{

    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
        public string errormessage { get; set; } = string.Empty;
        public bool Success => string.IsNullOrEmpty(errormessage);
    }
}