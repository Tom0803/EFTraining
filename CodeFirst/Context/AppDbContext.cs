using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CodeFirst.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Round> Rounds { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PartDefinition> PartDefinitions { get; set; }
        public DbSet<AssemblyStep> AssemblySteps { get; set; }
        public DbSet<StationAssemblyStep> StationAssemblyStep { get; set; }
        public DbSet<Part> Part { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // string connectionString = "Server=h2833128.stratoserver.net,14333;Initial Catalog=TF_TestDB;User ID=TFritz;Password=Start123456!;Integrated Security=False;";
                // optionsBuilder.UseSqlServer(connectionString);
                string connectionString = "DataSource=d:/Code/EFTraining/CodeFirst/Data/lean-training-codefirst.db;";
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // Round
            //
            var round = Build<Round>(modelBuilder);
            round.Property(x => x.Start)
                // .HasDefaultValueSql("datetime('now')")
                .IsRequired();
            round.Property(x => x.End);
            //
            // Station
            //
            var station = Build<Station>(modelBuilder);
            station.Property(x => x.Position)
                .IsRequired();
            station.HasOne(x => x.Round)
                .WithMany(x => x.Stations);
            //
            // Product
            //
            var product = Build<Product>(modelBuilder);
            product.Property(x => x.Start)
                // .HasDefaultValueSql("datetime('now')")
                .IsRequired();
            product.Property(x => x.End);
            product.HasOne(x => x.Round)
                .WithMany(x => x.Products);
            product.HasOne(x => x.Station)
                .WithMany(x => x.Products);
                // .HasForeignKey(x => x.StationId);
            //
            // PartDefinition
            //
            var partDefinition = Build<PartDefinition>(modelBuilder);
            partDefinition.Property(x => x.Cost)
                .IsRequired();
            partDefinition.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            //
            // AssemblyStep
            //
            var assemblyStep = Build<AssemblyStep>(modelBuilder);
            assemblyStep.Property(x => x.Cost)
                .IsRequired();
            assemblyStep.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            assemblyStep.Property(x => x.Mandatory)
                .HasDefaultValue(false);
            //
            // StationAssemblyStep
            //
            var stationAssemblyStep = Build<StationAssemblyStep>(modelBuilder);
            stationAssemblyStep.HasOne(x => x.AssemblyStep)
                .WithMany(x => x.StationAssemblySteps);
            stationAssemblyStep.HasOne(x => x.Station)
                  .WithMany(x => x.StationAssemblySteps);
            //
            // Part
            //
            var part = Build<Part>(modelBuilder);
            part.HasOne(x => x.PartDefintion)
                .WithMany(x => x.Parts);
            part.HasOne(x => x.Product)
                .WithMany(x => x.Parts);

        }

        private EntityTypeBuilder<T> Build<T>(ModelBuilder modelBuilder) where T : Entity
        {
            var entity = modelBuilder.Entity<T>();
            entity.HasKey(x => x.Id);
            entity.ToTable(typeof(T).Name);

            entity.Property<DateTime>("CreatedAt");
            entity.Property<DateTime>("UpdatedAt");
            entity.Property<string>("LatestUser");

            return entity;
        }
    }
}
