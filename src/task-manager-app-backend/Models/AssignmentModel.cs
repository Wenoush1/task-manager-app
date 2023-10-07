using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace task_manager_app_backend.Models
{
  public class AssignmentModel
  {
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public string Description { get; set; }
    public int ExpectedTimeToFinish { get; set; }
    public DateTime DateCreated { get; set; }
    public int? ParentAssignmentId { get; set; }
    public Assignment ParentAssignment { get; set; }
    [JsonIgnore]
    public ICollection<Assignment> TasksRequiredToFinish { get; set; }
  }
}
