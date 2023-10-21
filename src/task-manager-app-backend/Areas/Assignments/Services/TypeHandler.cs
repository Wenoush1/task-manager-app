using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_manager_app_backend.Abstractions;
using task_manager_app_backend.Data;
using task_manager_app_backend.Models;

namespace task_manager_app_backend.Areas.Assignments.Services;

public class TypeHandler : IHandler
{
    private ApplicationDbContext _dbContext;
    public TypeHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<AssignmentType>> GetTypes(CancellationToken token)
    {
        return await _dbContext.AssignmentTypes.ToListAsync(token);
    }

    public async Task<ActionResult> CreateType(CancellationToken token, string typeName)
    {
        var type = _dbContext.AssignmentTypes.Where(x => x.Name == typeName).FirstOrDefault();
        if (type != default)
        {
            //TODO middleware
            throw new Exception();
        }
        AssignmentType newType = new() { Name = typeName };
        _dbContext.AssignmentTypes.Add(newType);
        await _dbContext.SaveChangesAsync(token);
        return new OkResult();

    }

}

