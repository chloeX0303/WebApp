﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Areas.Identity.Data;
using WebApp.Models;

namespace WebApp.Areas.Identity.Data;

public class WebAppDbContext : IdentityDbContext<WebAppUser>
{
    public WebAppDbContext(DbContextOptions<WebAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new WebAppUserEntityConfiguration());
    }

    public DbSet<WebApp.Models.Department> Department { get; set; } = default!;

    public DbSet<WebApp.Models.Staff> Staff { get; set; } = default!;

    public DbSet<WebApp.Models.Subject> Subject { get; set; } = default!;

    public DbSet<WebApp.Models.Student> Student { get; set; } = default!;

   
    
}

public class WebAppUserEntityConfiguration : IEntityTypeConfiguration<WebAppUser>
{
    public void Configure(EntityTypeBuilder<WebAppUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.MidName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}