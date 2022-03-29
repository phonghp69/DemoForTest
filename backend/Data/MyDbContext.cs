using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<ReturningRequest> ReturningRequests { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e => e.ToTable("User"));
            modelBuilder.Entity<Assignment>(e => e.ToTable("Assignment"));
            modelBuilder.Entity<ReturningRequest>(e => e.ToTable("ReturningRequest"));
            modelBuilder.Entity<Asset>(e => e.ToTable("Asset"));
            modelBuilder.Entity<Category>(e => e.ToTable("Category"));

            modelBuilder.Entity<Assignment>()
                .HasOne(u => u.User)
                .WithMany(u => u.Assignments)
                .HasForeignKey(b => b.UserId)
                .IsRequired();
            modelBuilder.Entity<Assignment>()
                .HasOne<Asset>(a => a.Asset)
                .WithOne(a => a.Assignment)
                .HasForeignKey<Asset>(b => b.AssetId)
                .IsRequired();
            modelBuilder.Entity<ReturningRequest>()
            .HasOne(b => b.RequestedBy)
            .WithMany(u => u.Requests)
            .HasForeignKey(b => b.RequestedByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(true);

            modelBuilder.Entity<ReturningRequest>()
            .HasOne(b => b.ProcessedBy)
            .WithMany(c => c.Processed)
            .HasForeignKey(b => b.ProcessedByUserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(false);
            modelBuilder.Entity<ReturningRequest>()
                .HasOne<Assignment>(r => r.Assignment)
                .WithOne(a => a.ReturningRequest)
                .HasForeignKey<Assignment>(b => b.AssignmentId)
        .OnDelete(DeleteBehavior.Restrict)
        .IsRequired();
            modelBuilder.Entity<Asset>()
                .HasOne<Category>(a => a.Category)
                .WithOne(c => c.Asset)
                .HasForeignKey<Category>(a => a.CategoryId)
                .IsRequired();
            modelBuilder.Entity<Asset>()
                .HasOne<Assignment>(a => a.Assignment)
                .WithOne(a => a.Asset)
                .HasForeignKey<Assignment>(a => a.AssignmentId)
                .IsRequired();
            modelBuilder.Entity<Category>()
                .HasOne<Asset>(c => c.Asset)
                .WithOne(a => a.Category)
                .HasForeignKey<Asset>(a => a.AssetId)
                .IsRequired();

            modelBuilder.Entity<Category>().HasData(SeedingData.SeedingCategories);
            modelBuilder.Entity<Asset>().HasData(SeedingData.SeedingAssets);
            modelBuilder.Entity<User>().HasData(SeedingData.SeedingUsers);
        }
    }
}