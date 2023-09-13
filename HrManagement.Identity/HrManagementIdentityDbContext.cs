using HrManagement.EfCore;
using HrManagement.Identity.Configurations;
using HrManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Identity
{
    public class HrManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HrManagementIdentityDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
        }
    }
}
