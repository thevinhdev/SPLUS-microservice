using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SPLUS.Common.Application.Entities;

public partial class CommonContext : DbContext
{
    public CommonContext()
    {
    }

    public CommonContext(DbContextOptions<CommonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feature> Features { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feature>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
