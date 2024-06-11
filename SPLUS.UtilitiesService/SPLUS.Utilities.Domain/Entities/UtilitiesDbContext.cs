using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SPLUS.Utilities.Domain.Entities;

public partial class UtilitiesDbContext : DbContext
{
    public UtilitiesDbContext(DbContextOptions<UtilitiesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RequestCleaningService> RequestCleaningService { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestCleaningService>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RequestC__3214EC0729EDF82C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
