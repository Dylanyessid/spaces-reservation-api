using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SpacesReservation.API.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Space> Spaces { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SpaceReservations;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profiles__3214EC07A577329B");

            entity.HasIndex(e => e.UserId, "UQ__Profiles__1788CC4D54E546FF").IsUnique();

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.User).WithOne(p => p.Profile)
                .HasForeignKey<Profile>(d => d.UserId)
                .HasConstraintName("FK__Profiles__UserId__4CA06362");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC070C6863C7");

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Space).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.SpaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Space__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__534D60F1");
        });

        modelBuilder.Entity<Space>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spaces__3214EC07325A0B41");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image)
                .HasMaxLength(2048)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PricePerHour).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Owner).WithMany(p => p.Spaces)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Spaces__OwnerId__5070F446");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC071A2FDDDB");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
