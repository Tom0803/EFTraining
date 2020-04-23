using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DbFirst.Models;

namespace DbFirst.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssemblyStep> AssemblyStep { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartDefinition> PartDefinition { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Round> Round { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<StationAssemblyStep> StationAssemblyStep { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=Data/lean-training.db;foreign keys=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssemblyStep>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.PartDefintion)
                    .WithMany()
                    .HasForeignKey(d => d.PartDefintionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PartDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Text).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Start).IsRequired();

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Round>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Start).IsRequired();
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Position).IsRequired();

                entity.HasOne(d => d.Round)
                    .WithMany(p => p.Station)
                    .HasForeignKey(d => d.RoundId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<StationAssemblyStep>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.AssemblyStep)
                    .WithMany()
                    .HasForeignKey(d => d.AssemblyStepId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Station)
                    .WithMany()
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
