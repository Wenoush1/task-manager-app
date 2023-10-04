using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Authorization;
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
  [Route("assigment")]
  public async Task<ActionResult<IEnumerable<Assignment>>> GetData(AssignmentsHandler handler)
  {
    return Ok(await handler.GetAssignments());
  }

}

