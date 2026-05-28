using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Models;

public partial class CustomerAppDbContext : DbContext
{
    public CustomerAppDbContext()
    {
    }

    public CustomerAppDbContext(DbContextOptions<CustomerAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07D84DEB5F");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.ContactPersonEmail).HasMaxLength(254);
            entity.Property(e => e.ContactPersonName).HasMaxLength(200);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.TelephoneNumber).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getutcdate())");
            entity.Property(e => e.Vatnumber)
                .HasMaxLength(50)
                .HasColumnName("VATNumber");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
