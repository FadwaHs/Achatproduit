﻿using AchatProduit.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AchatProduit.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        private class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            void IEntityTypeConfiguration<ApplicationUser>.Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.Property(u => u.FirstName).HasMaxLength(255);
                builder.Property(u => u.LastName).HasMaxLength(255);
            }
        }
    }
}
