using System.ComponentModel.DataAnnotations;

namespace Hr_management.MVC.Models.LeaveType
{
    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DefaultDay { get; set; }
    }
}
