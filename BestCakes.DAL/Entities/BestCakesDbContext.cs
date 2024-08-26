using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BestCakes.DAL.Entities
{
    public partial class BestCakesDbContext : DbContext
    {
        public BestCakesDbContext()
        {
        }

        public BestCakesDbContext(DbContextOptions<BestCakesDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBccategory> TblBccategories { get; set; } = null!;
        public virtual DbSet<TblBcitem> TblBcitems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Dependency injection and configuration settings is used to handle connection strings.
            //Not needed as configuration options will be added from DI
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Add_Connection_String");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBccategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_BCCategories");

                entity.ToTable("tblBCCategories");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBcitem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK_BCItems");

                entity.ToTable("tblBCItems");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OfferPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblBcitems)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_BCItems_BCCategories_CategoryId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
