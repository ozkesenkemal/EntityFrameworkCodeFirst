using EntityFrameworkCodeFirst.Entity;
using EntityFrameworkCodeFirst.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkCodeFirst.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductExt> ProductExt { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DbContextInitializer.Build();
            optionsBuilder.UseNpgsql(DbContextInitializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Product>().ToTable("Product", "public");
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired().HasMaxLength(100);

            //modelBuilder.Entity<Category>().HasMany<Product>().WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            //modelBuilder.Entity<Product>()
            //    .HasOne<ProductExt>()
            //    .WithOne(x => x.Product)
            //    .HasForeignKey<ProductExt>(x => x.Id);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Teachers)
                .WithMany(x => x.Students)
                .UsingEntity<Dictionary<string, object>>(
                "StudentManyToMany", 
                x => x.HasOne<Teacher>().WithMany().HasForeignKey("Teacher_Id").HasConstraintName("FK_TeacherId"),
                x => x.HasOne<Student>().WithMany().HasForeignKey("Student_Id").HasConstraintName("FK_StudentId")
                );
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().ToList())
            {
                if(item.Entity is IAuditable auditable)
                {
                    if(item.State == EntityState.Added)
                    {
                        auditable.InsertDateTime = DateTime.UtcNow;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        auditable.UpdateDateTime = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
