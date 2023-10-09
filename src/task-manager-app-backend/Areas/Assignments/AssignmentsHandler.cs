﻿using Microsoft.AspNetCore.Mvc;
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
      return await _dbContext.Assignments.Include(x=>x.TasksRequiredToFinish).ToListAsync();
    }

    public async Task<ActionResult> CreateAnAssigment(CancellationToken token,AssignmentModel model)
    {
      if (model.ParentAssignmentId == null)
      {
        var assignment = new Assignment{ 
          Name = model.Name,
          Description = model.Description,
          ExpectedTimeToFinish = model.ExpectedTimeToFinish,
          DateCreated = DateTime.Now,
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
          ParentAssignment = parentAssignment
        };
        parentAssignment.TasksRequiredToFinish.Add(assignment);
        await _dbContext.SaveChangesAsync();
        return new OkResult();
      }
      return new OkResult();
    }
  }
}
