using System.Text.Json.Serialization;

namespace task_manager_app_backend.Models;

public class AssignmentType
{
  public int Id { get; set; }
  public string Name { get; set; }
  [JsonIgnore]
  public ICollection<Assignment> Assignments { get; set;}

}

