using Microsoft.EntityFrameworkCore;
using task_manager_app_backend.Authentication;
using task_manager_app_backend.Models;
using task_manager_app_backend.Services.Abstractions;

namespace task_manager_app_backend.Areas.Tasks
{
  public class AssignmentsHandler : IHandler
  {
    private ApplicationDbContext _dbContext;
    public AssignmentsHandler(ApplicationDbContext context) 
    {
      _dbContext = context;
    }

    public async Task<ICollection<Assignment>> GetAssignments()
    {

      return await _dbContext.Assignments.ToListAsync();
    }
  }
}
