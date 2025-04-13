using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public List<Holding> Holdings { get; set; } = new List<Holding>();
    }
}