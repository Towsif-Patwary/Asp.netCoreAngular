
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TravelAssistbyTowsif.Entity.Models
{
    public class AuthenticationContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<PreferenceModel> Preferences { get; set; }
    }
}
