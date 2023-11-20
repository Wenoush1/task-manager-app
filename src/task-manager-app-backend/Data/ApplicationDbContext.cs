using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task_manager_app_backend.Areas.Users.Services;
using task_manager_app_backend.Models;

namespace task_manager_app_backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentType> AssignmentTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.AssignmentId);
                entity.HasOne(e => e.ParentAssignment)
                .WithMany(e => e.TasksRequiredToFinish)
                .HasForeignKey(e => e.ParentAssignmentId);
                entity.ToTable("Assignments");
            });

            builder.Entity<AssignmentType>(entity =>
            {
                entity.HasMany(e => e.Assignments)
                .WithOne(e => e.Type)
                .HasForeignKey(e => e.TypeId)
                .IsRequired();
                entity.ToTable("TaskTypes");
            });
        }
    }
}