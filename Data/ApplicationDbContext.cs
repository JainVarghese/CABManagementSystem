using CSM.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSM.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<ApplicationUser> ApplicationUsers { get; set; }
            public DbSet<Detail> Details { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Routes> Routes { get; set; }

    }
}
