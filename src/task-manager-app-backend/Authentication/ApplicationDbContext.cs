using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task_manager_app_backend.Models;

namespace task_manager_app_backend.Authentication
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public virtual DbSet<Assignment> Assignments { get; set; }
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
    }
  }
}