namespace task_manager_app_backend.Areas.Assignments.Models;
public class FullAssignmentResponse
{
    public int AssignmentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ExpectedTimeToFinish { get; set; }
    public DateTime DateCreated { get; set; }
    public string TypeName { get; set; }
    public int? ParentAssignmentId { get; set; }
    public string? ParentAssignmentName { get; set; }
    public ICollection<Tuple<int, string>> ChildAssignments { get; set; }

}
