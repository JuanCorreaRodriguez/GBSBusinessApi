using GlamBeautyApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Connections;

public class PostgreDbContext : IdentityDbContext<AppUser>
{
    public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Media> Media { get; set; }
    public DbSet<Brand> Brand { get; set; }

    public DbSet<UserCourse> UserCourses { get; set; }
    public DbSet<BrandMedia> BrandMedia { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var roles = new List<IdentityRole>
        {
            new()
            {
                Id = "Admin",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new()
            {
                Id = "User",
                Name = "User",
                NormalizedName = "USER"
            },
            new()
            {
                Id = "Customer",
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            }
        };

        builder.Entity<IdentityRole>().HasData(roles);

        builder.Entity<Category>()
            .HasOne(e => e.Parent)
            .WithMany(e => e.SubCategories)
            .HasForeignKey(e => e.ParentId)
            .IsRequired(false);

        // Ignore actual entities // Used for migration at creation Jwt AppUser: removed after AspNet tables
        // builder.Ignore<BusinessModel>();
        // builder.Ignore<Category>();
        // builder.Ignore<Course>();
        // builder.Ignore<Course>();
        // builder.Ignore<MultimediaModel>();
        // builder.Ignore<PromoModel>();
        // builder.Ignore<User>();
        // builder.Ignore<UserCourse>();

        // builder.Entity<UserCourse>(m => m.HasKey(n => new { n.user_id, n.CourseId }));

        // builder.Entity<AppUser>()
        //     .HasMany(e => e.Course)
        //     .WithMany(o => o.AppUser)
        //     .UsingEntity<UserCourse>();

        builder.Entity<Course>()
            .HasMany(e => e.AppUser)
            .WithMany(o => o.Course)
            .UsingEntity<UserCourse>(
                l => l.HasOne<AppUser>().WithMany().HasForeignKey(e => e.UserId),
                r => r.HasOne<Course>().WithMany().HasForeignKey(e => e.CourseId)
            );

        builder.Entity<Brand>()
            .HasMany(e => e.Media)
            .WithMany(e => e.Brand)
            .UsingEntity<BrandMedia>(
                l => l.HasOne<Media>().WithMany().HasForeignKey(e => e.MediaId),
                r => r.HasOne<Brand>().WithMany().HasForeignKey(e => e.BrandId)
            );

        // builder.Entity<UserCourse>()
        //     .HasOne(o => o.AppUser)
        //     .WithMany(o => o.UserCourses)
        //     .HasForeignKey(o => o.user_id);
        //
        // builder.Entity<UserCourse>()
        //     .HasOne(o => o.Course)
        //     .WithMany(o => o.UserCourses)
        //     .HasForeignKey(o => o.CourseId);
    }
}