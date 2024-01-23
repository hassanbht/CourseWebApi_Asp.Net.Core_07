using CourseWebApi.Model.Courses.Entities;
using CourseWebApi.Model.Orders.Entities;
using CourseWebApi.Model.Student.Entities;
using CourseWebApi.Model.Tags.Entities;
using CourseWebApi.Model.Teachers.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseWebApi.DAL.DbContexts;

public class CourseStoreDbContext : DbContext
{

    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<CourseComment> CourseComments { get; set; }
    public virtual DbSet<CourseTeacher> CourseTeachers { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<CourseStudent> CourseStudents { get; set; }
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

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        #region Config Entity
        //modelBuilder.Entity<Course>().ToTable(c => c.IsTemporal());
        //modelBuilder.Ignore<Address>();
        //modelBuilder.Ignore<Car>();
        //modelBuilder.Entity<Teacher>().OwnsOne(t => t.Address, a =>
        // {
        //     a.Property(p => p.Street).HasMaxLength(50);
        //     a.Property(p => p.City).HasMaxLength(50);
        //     a.Property(p => p.State).HasMaxLength(50);
        //     a.Property(p => p.ZipCode).HasMaxLength(10);
        // });

        //modelBuilder.Entity<Teacher>().OwnsMany(t => t.Cars, a =>
        //{
        //    a.Property(p => p.CarName).HasMaxLength(100);
        //});
        //modelBuilder.Ignore<PhoneNumber>();
        //modelBuilder.Entity<Student>().OwnsMany(t => t.PhoneNumbers, a =>
        //{
        //    a.Property(p => p.Number).HasMaxLength(11).IsUnicode(false);
        //});
        #endregion



    }

}