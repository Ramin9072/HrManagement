using HrManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Identity.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "71e38b69-d09a-49f1-b6b3-99a751bd6d1c",
                        Email = "admin@localhost.local",
                        NormalizedEmail = "ADMIN@LOCALHOST.LOCAL",
                        FirstName = "Administrator",
                        LastName = "Administrator",
                        UserName = "admin@localhost.local",
                        NormalizedUserName = "ADMIN@LOCALHOST.LOCAL",
                        PasswordHash = hasher.HashPassword(null, "Password"),
                        EmailConfirmed = true

                    },
                    new ApplicationUser
                    {
                        Id = "04bef0f7-87b1-403c-93a1-e04a9c1beb0b",
                        Email = "user1@localhost.local",
                        NormalizedEmail = "USER1@LOCALHOST.LOCAL",
                        FirstName = "ramin",
                        LastName = "navabian",
                        UserName = "ramin.navabian@localhost.local",
                        NormalizedUserName = "RAMIN.NAVABIAN@LOCALHOST.LOCAL",
                        PasswordHash = hasher.HashPassword(null, "R@min9072"),
                        EmailConfirmed = true
                    }
                );
        }
    }

}
