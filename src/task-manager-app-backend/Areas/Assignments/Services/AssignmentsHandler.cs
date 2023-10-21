using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager_app_backend.Abstractions;
using task_manager_app_backend.Areas.Assignments.Models;
using task_manager_app_backend.Data;
using task_manager_app_backend.Models;

namespace task_manager_app_backend.Areas.Assignments.Services;

public class AssignmentsHandler : IHandler
{
    private ApplicationDbContext _dbContext;
    public AssignmentsHandler(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public async Task<ICollection<Assignment>> GetAssignments()
    {
        return await _dbContext.Assignments.Include(x => x.TasksRequiredToFinish).Include(x => x.Type).ToListAsync();
    }

    public async Task<ActionResult> CreateAnAssigment(CancellationToken token, AssignmentResquest model)
    {
        var type = _dbContext.AssignmentTypes.Where(x => x.Id == model.typeId).FirstOrDefault();
        if (type == null)
        {
            //TODO add middleware and custom exception
            throw new Exception();
        }
        if (model.ParentAssignmentId == null)
        {
            var assignment = new Assignment
            {
                Name = model.Name,
                Description = model.Description,
                ExpectedTimeToFinish = model.ExpectedTimeToFinish,
                DateCreated = DateTime.Now,
                Type = type,
                TypeId = type.Id
            };
            _dbContext.Assignments.Add(assignment);
            await _dbContext.SaveChangesAsync(token);
            return new OkResult();
        }
        else
        {
            var parentAssignment = await _dbContext.Assignments.FindAsync(model.ParentAssignmentId);
            var assignment = new Assignment
            {
                Name = model.Name,
                Description = model.Description,
                ExpectedTimeToFinish = model.ExpectedTimeToFinish,
                DateCreated = DateTime.Now,
                ParentAssignmentId = model.ParentAssignmentId,
                ParentAssignment = parentAssignment,
                Type = type,
                TypeId = type.Id
            };
            parentAssignment.TasksRequiredToFinish.Add(assignment);
            await _dbContext.SaveChangesAsync();
            return new OkResult();
        }
    }
}

