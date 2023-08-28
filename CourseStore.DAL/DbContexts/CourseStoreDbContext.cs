using CourseStore.Model.Courses.Entities;
using CourseStore.Model.Orders.Entities;
using CourseStore.Model.Tags.Entities;
using CourseStore.Model.Teachers.Entities;
using CourseWebApi.Model.Student.Entities;
using CourseWebApi.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL.Contexts;

public class CourseStoreDbContext : DbContext
{

    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseComment> CourseComments { get; set; }
    public DbSet<CourseTeacher> CourseTeachers { get; set; }    
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<CourseStudent> CourseStudents { get; set; }
    public CourseStoreDbContext(DbContextOptions<CourseStoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Audit fields
        foreach (var item in modelBuilder.Model.GetEntityTypes())
        {
            modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<DateTime>("CreateDate").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasMaxLength(50);
        }
        #endregion

        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        #region Config Entity
        modelBuilder.Entity<Course>().ToTable(c => c.IsTemporal());
        modelBuilder.Ignore<Address>();
        modelBuilder.Ignore<Car>();
        modelBuilder.Entity<Teacher>().OwnsOne(t => t.Address, a =>
         {
             a.Property(p => p.Street).HasMaxLength(50);
             a.Property(p => p.City).HasMaxLength(50);
             a.Property(p => p.State).HasMaxLength(50);
             a.Property(p => p.ZipCode).HasMaxLength(10);
         });

        modelBuilder.Entity<Teacher>().OwnsMany(t => t.Cars, a =>
        {
            a.Property(p => p.CarName).HasMaxLength(100);
        });
        modelBuilder.Ignore<PhoneNumber>();
        modelBuilder.Entity<Student>().OwnsMany(t => t.PhoneNumbers, a =>
        {
            a.Property(p => p.Number).HasMaxLength(11).IsUnicode(false);
        });
        #endregion



    }

}