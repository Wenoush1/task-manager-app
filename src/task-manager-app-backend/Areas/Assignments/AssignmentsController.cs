using Microsoft.AspNetCore.Mvc;
using task_manager_app_backend.Areas.Tasks;
using task_manager_app_backend.Models;

namespace NetGlade.Onboarding.DummyDevice.Areas.Telemetries;

[ApiController]
public class AssignmentsController : ControllerBase
{




  /*public TasksController(TelemetriesHandler loader)
  {
    _telemetriesLoader = loader;
  }

  */
  [HttpGet]
  [Route("assignment")]
  public async Task<ActionResult<IEnumerable<Assignment>>> GetAssigments(AssignmentsHandler handler)
  {
    return Ok(await handler.GetAssignments());
  }

  [HttpPut]
  [Route("assignment")]
  public async Task<ActionResult> CreateAssignment(AssignmentsHandler handler, [FromQuery] int? parentId)
  {
    return Ok(handler.CreateAnAssigment(parentId));
  }
}

