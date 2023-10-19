using Microsoft.AspNetCore.Mvc;
using task_manager_app_backend.Areas.Assignments;
using task_manager_app_backend.Areas.Tasks;
using task_manager_app_backend.Models;

namespace NetGlade.Onboarding.DummyDevice.Areas.Telemetries;

[ApiController]
public class AssignmentsController : ControllerBase
{

  [HttpGet]
  [Route("assignment")]
  public async Task<ActionResult<IEnumerable<Assignment>>> GetAssigments(AssignmentsHandler handler)
  {
    return Ok(await handler.GetAssignments());
  }

  [HttpPut]
  [Route("assignment")]
  public async Task<ActionResult> CreateAssignment(AssignmentsHandler handler,CancellationToken token, [FromBody] AssignmentModel model)
  {
    return Ok(await handler.CreateAnAssigment(token,model));
  }

  [HttpPut]
  [Route("assignment-type")]
  public async Task<ActionResult> CreateType(TypeHandler handler, CancellationToken token, [FromBody] string name)
  {
    return Ok(await handler.CreateType(token,name));
  }
  [HttpGet]
  [Route("assignment-type")]
  public async Task<ActionResult<ICollection<AssignmentType>>> GetTypes(TypeHandler handler, CancellationToken token)
  {
    return Ok(await handler.GetTypes(token));
  }
}

