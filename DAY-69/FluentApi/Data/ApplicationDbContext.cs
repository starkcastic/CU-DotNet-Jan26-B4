using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentApi.Data;
using FluentApi.Models;
using System.Reflection.Metadata;

namespace FluentApi.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<StudentCourse> StudentCourses => Set<StudentCourse>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            entity.Property(e => e.Email)
                .IsRequired();
            
            entity.HasIndex(e => e.Email)
                .IsUnique();
            
            entity.Property(e => e.Age)
                .IsRequired();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Courses");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            entity.Property(e => e.Credit)
                .IsRequired();
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.ToTable("StudentCourses");  

            entity.HasKey(e => new { e.StudentId, e.CourseId });

            entity.HasOne(e => e.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(e => e.StudentId);

            entity.HasOne(e => e.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(e => e.CourseId);
        });
    }
}