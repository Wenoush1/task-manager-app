using System.ComponentModel.DataAnnotations;

namespace task_manager_app_backend.Areas.Assignments.Models
{
    public class AssignmentResquest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpectedTimeToFinish { get; set; }
        public int typeId { get; set; }
        public int? ParentAssignmentId { get; set; }
    }
}
