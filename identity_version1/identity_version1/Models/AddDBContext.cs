using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity_version1.Models
{
    public class AddDBContext : IdentityDbContext<AppUser>
    {
        public AddDBContext(DbContextOptions<AddDBContext> options) : base(options) { }
    }
}
